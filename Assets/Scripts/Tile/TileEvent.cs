using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TileEvent : MonoBehaviour , IPointerClickHandler
{
    private TilePresenter presenter;
    private void Awake()
    {
        presenter = GetComponent<TilePresenter>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       StartCoroutine( presenter.Reverse());
    }
}
