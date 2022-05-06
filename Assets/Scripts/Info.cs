using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 現在ステージの情報など、共有ステータス
/// </summary>
public static class Info
{
   public static int StageNum = 1;
   public static bool IsSceneChanging = false;
   public static List<int> ClearStageNum = new List<int>();
   public static int CanReturnNum = 1;
}
