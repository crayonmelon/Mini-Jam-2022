using UnityEngine;

public static class EvansWhackyExtensions
{
    public static Vector3 With(this Vector3 it, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? it.x, y ?? it.y, z ?? it.z);
    }
}
