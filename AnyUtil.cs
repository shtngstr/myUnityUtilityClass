using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class AnyUtil
{
    //transform.localEulerAnglesは0~360度だが、実行すると-180~180度になってしまうため、それを考慮した補正を行う。
    public static Vector3 ClampAngleX(Vector3 localAngle, float min, float max)
    {
        //0~360度を-180~180度に変換し、クランプ
        float vx = localAngle.x > 180 ? localAngle.x - 360 : localAngle.x;
        vx = Mathf.Clamp(vx, min, max);
        //0~180度を0~360度に直す
        localAngle.x = vx < 0 ? vx + 360 : vx;
        return localAngle;
    }
    public static Vector3 ClampAngleY(Vector3 localAngle, float min, float max)
    {
        //0~360度を-180~180度に変換し、クランプ
        float vy = localAngle.y > 180 ? localAngle.y - 360 : localAngle.y;
        vy = Mathf.Clamp(vy, min, max);
        //0~180度を0~360度に直す
        localAngle.y = vy < 0 ? vy + 360 : vy;
        return localAngle;
    }
    public static Vector3 ClampAngleZ(Vector3 localAngle, float min, float max)
    {
        //0~360度を-180~180度に変換し、クランプ
        float vz = localAngle.z > 180 ? localAngle.z - 360 : localAngle.z;
        vz = Mathf.Clamp(vz, min, max);
        //0~180度を0~360度に直す
        localAngle.z = vz < 0 ? vz + 360 : vz;
        return localAngle;
    }

    ///<summary>Assetsフォルダのパスを返す。</summary>
    public static string GetAssetsPath() {
        //if(Application.isEditor)
        return System.IO.Directory.GetCurrentDirectory() + "\\Assets";
    }

    public static string GetAndroidPath() {
        //if(Application.platform == RuntimePlatform.Android)
        using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                using (var getFilesDir = currentActivity.Call<AndroidJavaObject>("getFilesDir"))
                    return getFilesDir.Call<string>("getCanonicalPath");
    }

    ///<summary>exeと同じフォルダのパスを返す。EditorではAssetsの1つ上。</summary>
    public static string GetCurrentPathWindows() {
        //if(Application.platform == RuntimePlatform.WindowsPlayer)
        return System.IO.Directory.GetCurrentDirectory().TrimEnd('\\');
    }

    /// <summary>環境に応じて保存に適するパスを返す。</summary>
    public static string GetPlatformPath()
    {
        string path = "";

        // エディタ上
        if(Application.isEditor)
            path = Directory.GetCurrentDirectory() + "\\Assets";
        // アンドロイド
        else if(Application.platform == RuntimePlatform.Android)
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                    using (var getFilesDir = currentActivity.Call<AndroidJavaObject>("getFilesDir"))
                        path = getFilesDir.Call<string>("getCanonicalPath");
        // スタンドアロンWin
        else if(Application.platform == RuntimePlatform.WindowsPlayer)
            //path = System.AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            path = System.IO.Directory.GetCurrentDirectory().TrimEnd('\\');
        // 万が一の不一致
        else
            path = Application.persistentDataPath;

        return path;
    }

    ///<summary>2DBoxを表示</summary>
    public static void DrawBox(Vector2 leftDownPos, Vector2 rightUpPos, Color color) {
        Vector2 a = new Vector2(leftDownPos.x, rightUpPos.y);     //左上
        Vector2 b = new Vector2(leftDownPos.x, leftDownPos.y);    //左下
        Vector2 c = new Vector2(rightUpPos.x, rightUpPos.y);      //右上
        Vector2 d = new Vector2(rightUpPos.x, leftDownPos.y);     //右下
        Debug.DrawLine(a, b, color);
        Debug.DrawLine(b, d, color);
        Debug.DrawLine(d, c, color);
        Debug.DrawLine(c, a, color);
    }
}
