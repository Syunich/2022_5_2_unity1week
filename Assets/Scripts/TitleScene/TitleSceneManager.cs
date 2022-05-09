using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
   [SerializeField] private GameObject TitleDisplay;
   [SerializeField] private GameObject FirstTile;
   [SerializeField] private GameObject FirstDisplay;

   private void Awake()
   {
      Info.IsTutorial = false;
   }

   private void Start()
   {
      if (Info.IsFirstLoaded)
      {
         Instantiate(TitleDisplay);
         FirstTile.SetActive(false);
         FirstDisplay.SetActive(false);
      }
   }
}
