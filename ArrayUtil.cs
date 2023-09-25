public static class ArrayUtil
{
    ///<summary>一次元配列を指定の値で埋める。</summary>
    public static void Fill<T>(this T[] list, T t) {
        for(int i = 0;i < list.Length;i++) {
            list[i] = t;
        }
    }

    ///<summary>二次元配列を指定の値で埋める。</summary>
    public static void Fill<T>(this T[][] list, T t) {
        for(int y = 0;y < list.Length; y++) {
            for(int x = 0;x < list[y].Length; x++) {
                list[y][x] = t;
            }
        }
    }

    ///<summary>一次元配列を文字列にして返す。</summary>
    public static string GetString<T>(this T[] list) {
        string str = "[";
        foreach(T x in list) str += x + ", ";
        return str.Remove(str.Length - 2) + "]";
    }

    ///<summary>二次元配列を文字列にして返す。</summary>
    public static string GetString<T>(this T[][] list) {
        string str;
        str = "[";
        foreach(T[] y in list) {
            str += "[";
            foreach(T x in y) {
                str += x + ", ";
            }
            str = str.Remove(str.Length - 2) + "], ";
        }
        return str.Remove(str.Length - 2) + "]";
    }
}
