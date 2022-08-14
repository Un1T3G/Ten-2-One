using UnityEngine;
using System;

namespace Un1T3G.Pool
{
    public class Poolable : MonoBehaviour
    {
        private bool _initalized;

        public GameObject Prefab { get; private set; }

        public void Init(GameObject prefab)
        {
            if (_initalized)
                throw new InvalidOperationException($"{nameof(Poolable)} already initalized");

            Prefab = prefab;

            _initalized = true;
        }
    }
}
