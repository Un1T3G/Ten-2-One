using System;
using System.Collections.Generic;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class Block : DragableBehaviour, IBlock
    {
        private Transform _parent;
        private Transform _boardRoot;
        private List<IBlockTile> _children;

        public IEnumerable<IBlockTile> Tiles => _children;

        public event Action<IBlock> OnPointerUpEvent;
        public event Action<IBlock> OnDragEvent;
        public event Action<IBlock> OnPointerDownEvent;

        protected override void PointerDown()
        {
            _transform.SetParent(_boardRoot);

            OnPointerDownEvent?.Invoke(this);
        }

        protected override void Draging()
        {
            OnDragEvent?.Invoke(this);
        }

        protected override void PointerUp()
        {
            _transform.SetParent(_parent);

            OnPointerUpEvent?.Invoke(this);
        }

        public void Init(List<IBlockTile> children, Transform boardRoot,float scaleFactor)
        {
            _children = children;
            _parent = _transform;
            _boardRoot = boardRoot;
            base.Init(scaleFactor);
        }
    }
}
