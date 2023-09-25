using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectTransformUtil
{
    //Anchorが中心である必要あり(?)。代入する際はrecttransform.localPositionへ。
    ///<summary>
    ///<para>スクリーン座標を、ローカルRectTransform座標へ変換して返す。</para>
    ///<para>対象のUIを含むCanvasのRenderModeはOverlay。返り値はRectTransform.localPositionへ利用。</para>
    ///</summary>
    ///<param name="targetUI targetScreenPos">後で返り値を代入するUI</param>
    ///<param name="targetScreenPos">変換するスクリーン座標</param>
    public static Vector2 GetLocalUIPosByScreenPos(RectTransform targetUI, Vector2 targetScreenPos)
    {
        RectTransform parentUI = targetUI.parent.GetComponent<RectTransform>();
        // スクリーン座標→UIローカル座標変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentUI, targetScreenPos,
            null, out var uiLocalPos
        );      // オーバーレイモードの場合はnull
        
        return uiLocalPos;
    }
    // 使用例
    // Vector2 uiLocalPos = RectTransformUtil.GetLocalUIPosByScreenPos(targetUI, Input.mousePosition);     //スクリーン座標からUIローカル座標に
    // targetUI.localPosition = uiLocalPos;    //RectTransformに代入

    //返した値を代入する際はlocalPositionではなく、recttransform.position
    ///<summary>
    ///<para>ワールド座標を、ワールド(?)RectTransform座標へ変換して返す。</para>
    ///<para>代入するUIがあるCanvasのRenderModeはOverlay。</para>
    ///<para>返り値はRectTransform.positionに利用。</para>
    ///</summary>
    public static Vector2 GetUIPosByWorldPosOverlay(Camera cam, Vector3 targetPos)
    {
        return RectTransformUtility.WorldToScreenPoint(cam, targetPos);
    }
}
