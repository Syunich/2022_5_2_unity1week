using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 受け取った入力をタイルマネージャーへ流す
/// </summary>
public class TileEvent : MonoBehaviour , IPointerClickHandler
{
    private TilePresenter presenter;
    private void Awake()
    {
        presenter = GetComponent<TilePresenter>();
    }

    //タイルがクリックされた時の動作
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.X))
            return;
        
        if (Input.GetKey(KeyCode.Z))
        {
            TilesManager.Instance.Reverse(presenter , ReverseType.Cross);
            return;
        }

        if (Input.GetKey(KeyCode.X))
        {
            TilesManager.Instance.Reverse(presenter, ReverseType.Square);
            return;
        }
        
        TilesManager.Instance.Reverse(presenter, ReverseType.One);
    }
}

public enum ReverseType
{
    One,
    Cross,
    Square
}
