using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class SpawnedBlockPositioner : MonoBehaviour
    {
        [SerializeField] private BlockFactory _factory;
        [SerializeField] private UIContainer _uiContainer;

        private void OnEnable()
        {
            _factory.OnBuild += OnBlockBuild;
        }

        private void OnBlockBuild(Block block)
        {
            _uiContainer.Calculate();
        }

        private void OnDisable()
        {
            _factory.OnBuild -= OnBlockBuild;
        }
    }
}
