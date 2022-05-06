using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class FistTileManager : MonoBehaviour , IPointerClickHandler
{
   [SerializeField] private TileView view;
   [SerializeField] private TitleMoving TM;
   private bool IsClicked;

   public void OnPointerClick(PointerEventData eventData)
   {
       if (!IsClicked)
       {
           IsClicked = true;
           StartCoroutine(MoveTitle());
       }
   }

   private IEnumerator MoveTitle()
   {
       yield return StartCoroutine(view.Reverse());
     yield return StartCoroutine(TM.IndicateTitle());
   }
}
