using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Un1T3G.Ten2One
{
    public class BlockEvent : MonoBehaviour
    {
        public static event Action<IBlock> OnPointerDown;
        public static event Action<IBlock> OnDrag;
        public static event Action<IBlock> OnPointerUp;

        [SerializeField] private Block _block;
        private void OnEnable()
        {
            _block.OnPointerDownEvent += BlockOnPointerDown;
            _block.OnDragEvent += BlockOnDrag;
            _block.OnPointerUpEvent += BlockOnPointerUp;
        }
        private void OnDisable()
        {
            _block.OnPointerDownEvent -= BlockOnPointerDown;
            _block.OnDragEvent -= BlockOnDrag;
            _block.OnPointerUpEvent -= BlockOnPointerUp;
        }
        private void BlockOnPointerDown(IBlock block)
        {
            OnPointerDown?.Invoke(block);
        }
        private void BlockOnDrag(IBlock block)
        {
            OnDrag?.Invoke(block);
        }
        private void BlockOnPointerUp(IBlock block)
        {
            OnPointerUp?.Invoke(block);
        }
    }
}
