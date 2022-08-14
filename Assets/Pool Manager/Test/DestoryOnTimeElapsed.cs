using Un1T3G.Pool;
using UnityEngine;

public class DestoryOnTimeElapsed : MonoBehaviour, IPoolable
{
    [SerializeField] private float _time;

    private float _t;
    private bool _isDestoryed;

    public void OnDespawn()
    {
    }

    public void OnSpawn()
    {
        _t = _time;
        _isDestoryed = false;
    }

    private void Update()
    {
        if (_isDestoryed)
            return;

        _t -= Time.deltaTime;

        if (_t <= 0)
        {
            _isDestoryed = true;
            PoolManager.Despawn(gameObject);
        }
    }
}
