using System;
using System.Collections.Generic;
using UnityEngine;
using Un1T3G.Pool;

namespace Un1T3G.Ten2One
{
    public class Block : DragableBehaviour, IBlock, IPoolable
    {
        private Transform _parent;
        private Transform _boardRoot;
        private Vector2 _beginPosition;
        private List<IBlockTile> _children;
        public IEnumerable<IBlockTile> Tiles => _children;

        public event Action<IBlock> OnPointerUpEvent;
        public event Action<IBlock> OnDragEvent;
        public event Action<IBlock> OnPointerDownEvent;

        protected override void PointerDown()
        {
            OnPointerDownEvent?.Invoke(this);

            _beginPosition = Position;

            _transform.SetParent(_boardRoot);
        }

        protected override void Draging()
        {
            OnDragEvent?.Invoke(this);
        }

        protected override void PointerUp()
        {
            OnPointerUpEvent?.Invoke(this);

            if (gameObject.activeInHierarchy == false)
                return;

            _transform.SetParent(_parent);

            Position = _beginPosition;
        }

        public void Init(Transform boardRoot, float scaleFactor)
        {
            base.Init(scaleFactor);
            _parent = _transform.parent;
            _boardRoot = boardRoot;
        }

        public void Setup(List<IBlockTile> children)
        {
            _children = children;
        }

        public void OnSpawn()
        {
            
        }

        public void OnDespawn()
        {
            Scale = Vector2.one;
        }
    }
}
