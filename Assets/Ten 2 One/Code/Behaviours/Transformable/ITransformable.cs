using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public interface ITransformable
    {
        Transform Root { get; }

        Vector2 Size { get; set; }

        Vector2 Position { get; set; }

        Vector2 Scale { get; set; }
    }
}
