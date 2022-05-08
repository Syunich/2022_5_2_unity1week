using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
   [SerializeField] private GameObject TitleDisplay;
   private void Start()
   {
      if (Info.IsFirstLoaded)
      {
         Instantiate(TitleDisplay);
      }
   }
}
