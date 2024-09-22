using UnityEngine;

public static class Extersion
{
      public static float InverseLerp(this Vector3 value, Vector3 a, Vector3 b)
      {
            Vector3 AB = b - a;
            Vector3 AV = value - a;
            return Vector3.Dot(AB, AV) / Vector3.Dot(AB,AB );
      }
}
