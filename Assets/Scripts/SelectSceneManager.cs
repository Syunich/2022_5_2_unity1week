using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneManager : MonoBehaviour
{
  [SerializeField] private GameObject[] StageSelectPanels;

  public bool IsAllCleared()
  {
    foreach (var VARIABLE in StageSelectPanels)
    {
      if (VARIABLE.activeSelf)
        return false;
    }

    return true;
  }
  
  private void Awake()
  {
    foreach (var num in Info.ClearStageNum)
    {
      StageSelectPanels[num - 1].SetActive(false);
    }
  }
}
