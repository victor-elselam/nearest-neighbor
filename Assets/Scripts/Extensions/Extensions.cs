using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Elselam {
    public static class Extensions {
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection) => collection == null || !collection.Any();
        public static Color RandomColor => new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        public static Vector3 RandomPosition(PositionBounds bounds) {
            return new Vector3(Random.Range(-bounds.X, bounds.X), Random.Range(-bounds.Y, bounds.Y), Random.Range(-bounds.Z, bounds.Z));
        }
    }

    [Serializable]
    public class PositionBounds {
        public float X;
        public float Y;
        public float Z;
    }
}
