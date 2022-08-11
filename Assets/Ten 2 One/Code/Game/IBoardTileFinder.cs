using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BoardTileFinder : MonoBehaviour
    {
        private UIGridContainer _uiGridContainer;

        public void Init(UIGridContainer uiGridContainer)
        {
            _uiGridContainer = uiGridContainer;
        }

        public BoardTile Find(Vector2 position)
        {
            return null;
        }
    }
}
