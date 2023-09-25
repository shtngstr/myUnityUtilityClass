using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomUtil
{
    ///<summary>trueかfalseを返す。</summary>
    public static bool Bool() {
        return UnityEngine.Random.Range(0, 2) == 0;
    }

    ///<summary>配列のシャッフル。</summary>
    public static void Shuffle<T>(T[] list) {
        for(int i = 0;i < list.Length; i++) {
            int rndIndex = UnityEngine.Random.Range(0, list.Length);
            T tmp = list[i];
            list[i] = list[rndIndex];
            list[rndIndex] = tmp;
        }
    }

    ///<summary>リストのシャッフル。</summary>
    public static void Shuffle<T>(List<T> list) {
        for(int i = 0;i < list.Count; i++) {
            int rndIndex = UnityEngine.Random.Range(0, list.Count);
            T tmp = list[i];
            list[i] = list[rndIndex];
            list[rndIndex] = tmp;
        }
    }

    ///<summary>配列から1つランダムに返す。</summary>
    public static T Choice<T>(T[] list) {
        return list[UnityEngine.Random.Range(0, list.Length)];
    }

    ///<summary>リストから1つランダムに返す。</summary>
    public static T Choice<T>(List<T> list) {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    ///<summary>2点からなる矩形内のランダムな座標を返す。</summary>
    public static Vector2 GetPointInRect(Vector2 start, Vector2 end) {
        //大小を逆に入れた時の対策
        Vector2 s = new Vector2(Mathf.Min(start.x, end.x), Mathf.Min(start.y, end.y));
        Vector2 e = new Vector2(Mathf.Max(start.x, end.x), Mathf.Max(start.y, end.y));
        return new Vector2(UnityEngine.Random.Range(s.x, e.x), UnityEngine.Random.Range(s.y, e.y));
    }

    ///<summary>2点からなる立方体内のランダムな座標を返す。</summary>
    public static Vector3 GetPointInCube(Vector3 start, Vector3 end) {
        //大小を逆に入れた時の対策
        Vector3 s = new Vector3(Mathf.Min(start.x, end.x), Mathf.Min(start.y, end.y), Mathf.Min(start.z, end.z));
        Vector3 e = new Vector3(Mathf.Max(start.x, end.x), Mathf.Max(start.y, end.y), Mathf.Max(start.z, end.z));
        return new Vector3(UnityEngine.Random.Range(s.x, e.x), UnityEngine.Random.Range(s.y, e.y), UnityEngine.Random.Range(s.z, e.z));
    }

    ///<summary>2点からなる線分上のランダムな座標を返す。</summary>
    public static Vector2 GetPointOnLine(Vector2 start, Vector2 end) {
        return Vector2.Lerp(start, end, UnityEngine.Random.Range(0f, 1f));
    }

    ///<summary>2点からなる線分上のランダムな座標を返す。</summary>
    public static Vector3 GetPointOnLine(Vector3 start, Vector3 end) {
        return Vector3.Lerp(start, end, UnityEngine.Random.Range(0f, 1f));
    }
 
    ///<summary>円内のランダムな座標を返す。</summary>
    public static Vector2 GetPointInCircle(Vector2 center, float radius) {
        return center + UnityEngine.Random.insideUnitCircle * radius;
    }

    ///<summary>球内のランダムな座標を返す。</summary>
    public static Vector3 GetPointInSphere(Vector3 center, float radius) {
        return center + UnityEngine.Random.insideUnitSphere * radius;
    }

    ///<summary>各範囲からランダムな整数値を返す。</summary>
    ///<param name="range">Vector2(min, max)</param>
    public static int MultipleRandInt(params Vector2[] range)
    {
        //どの範囲かのインデックス
        int i = UnityEngine.Random.Range(0, range.Length);
        //Range<int>で使うため、minは切り上げ、maxは切り捨てて+1
        int value = UnityEngine.Random.Range(Mathf.CeilToInt(range[i].x), (int)(range[i].y) + 1);
        return value;
    }

    ///<summary>各範囲からランダムな少数値を返す。</summary>
    public static float MultipleRandFloat(params Vector2[] range)
    {
        int i = UnityEngine.Random.Range(0, range.Length);
        float value = UnityEngine.Random.Range(range[i].x, range[i].y);
        return value;
    }
}
