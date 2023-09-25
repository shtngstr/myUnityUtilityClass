using UnityEngine;

public static class MathUtil
{
    ///<summary>角度から正規化されたVector2を得る。</summary>
    public static Vector2 GetVelocity2FromAngle(float degree) {
        return new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad));
    }
}
