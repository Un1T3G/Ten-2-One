using System.Collections.Generic;
using UnityEngine;
using System;

namespace Un1T3G.Pool
{
    public class PoolManager : MonoBehaviour
    {
        private static readonly Dictionary<GameObject, PoolColection> _poolDictionary = new(64);
        private static readonly List<IPoolable> _poolables = new(32);

        static PoolManager()
        {
            var obj = new GameObject($"[{nameof(PoolManager)}]");
            obj.AddComponent<PoolManager>();
        }

        private static void CheckForSpawnEvent(GameObject obj)
        {
            if (obj.TryGetComponent<IPoolable>(out var poolable))
                poolable.OnSpawn();

            obj.GetComponentsInChildren(_poolables);

            foreach (var item in _poolables)
                item.OnSpawn();
        }

        private static void CheckForDespawnEvent(GameObject obj)
        {
            if (obj.TryGetComponent<IPoolable>(out var poolable))
                poolable.OnDespawn();

            obj.GetComponentsInChildren(_poolables);

            foreach (var item in _poolables)
                item.OnDespawn();
        }

        public static void AddPreset(PoolPreset poolPreset)
        {
            if (_poolDictionary.ContainsKey(poolPreset.Prefab))
                throw new InvalidOperationException("You are trying to create an existing preset");

            var poolColection = new PoolColection(poolPreset);
            poolColection.Init();

            _poolDictionary.Add(poolPreset.Prefab, poolColection);
        }

        public static T Spawn<T>(T component) where T : Component
        {
            return Spawn(component.gameObject).GetComponent<T>();
        }

        public static T Spawn<T>(T component, Transform parent) where T : Component
        {
            return Spawn(component.gameObject, parent).GetComponent<T>();
        }

        public static GameObject Spawn(GameObject obj)
        {
            if (_poolDictionary.ContainsKey(obj) == false)
                throw new InvalidOperationException("Pool not exists");

            var pool = _poolDictionary[obj].GetPool();
            CheckForSpawnEvent(pool);

            return pool;
        }

        public static GameObject Spawn(GameObject obj, Transform parent)
        {
            var spawnedObject = Spawn(obj);

            spawnedObject.transform.SetParent(parent);

            return spawnedObject;
        }

        public static GameObject Spawn(GameObject obj, Vector3 position)
        {
            var spawnedObject = Spawn(obj);
            spawnedObject.transform.position = position;

            return spawnedObject;
        }

        public static GameObject Spawn(GameObject obj, Vector3 position, Quaternion rotation)
        {
            var spawnedObject = Spawn(obj);

            spawnedObject.transform.SetPositionAndRotation(position, rotation);

            return spawnedObject;
        }

        public static GameObject Spawn(GameObject obj, Vector3 position, Quaternion rotation, Transform parent)
        {
            var spawnedObject = Spawn(obj, position, rotation);

            spawnedObject.transform.SetParent(parent);

            return spawnedObject;
        }

        public static void Despawn(GameObject obj)
        {
            if (obj.TryGetComponent<Poolable>(out Poolable poolable) == false)
                throw new InvalidOperationException($"{nameof(Poolable)} not exists");

            var key = poolable.Prefab;

            if (_poolDictionary.ContainsKey(key) == false)
                throw new InvalidOperationException("Pool not exists");

            CheckForDespawnEvent(obj);
            _poolDictionary[key].AddPool(obj);
        }
    }

    internal class PoolColection
    {
        private readonly GameObject _prefab;
        private readonly Transform _parent;
        private readonly int _amount;
        private readonly bool _autoExpand;
        private readonly Queue<GameObject> _pools;

        public PoolColection(PoolPreset poolPreset)
        {
            _prefab = poolPreset.Prefab;
            _parent = poolPreset.transform;
            _amount = poolPreset.Amount;
            _autoExpand = poolPreset.AutoExpand;

            _pools = _autoExpand ? new() : new(_amount);
        }

        public void Init()
        {
            for (int i = 0; i < _amount; i++)
            {
                var obj = UnityEngine.Object.Instantiate(_prefab);
                obj.AddComponent<Poolable>().Init(_prefab);

                AddPool(obj);
            }
        }

        public GameObject GetPool()
        {
            if (_pools.TryDequeue(out var obj))
            {
                obj.SetActive(true);
                return obj;
            }

            if (_autoExpand == false)
                throw new InvalidOperationException("No available pools");

            var spawnedObject = UnityEngine.Object.Instantiate(_prefab);
            spawnedObject.AddComponent<Poolable>().Init(_prefab);
            spawnedObject.transform.SetParent(_parent);

            return spawnedObject;
        }

        public void AddPool(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(_parent);
            _pools.Enqueue(obj);
        }
    }
}
