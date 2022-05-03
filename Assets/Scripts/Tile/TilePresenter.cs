using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using DG.Tweening;

public class TilePresenter : MonoBehaviour
{
    private TileModel model;
    private TileView view;

    private void Awake()
    {
        view = GetComponent<TileView>();
    }

    public TileModel GetModel()
    {
        return model;
    }
    
    public void SetModel(TileModel model)
    {
        this.model = model;
    }

    public IEnumerator Reverse()
    {
        if (!CanReverse())
        {
            yield break;
        }
        model.IsMoving = true;
        yield return StartCoroutine(view.Reverse());
        model.Reverse();
        model.IsMoving = false;
        
    }

    private bool CanReverse()
    {
        if (model.IsMoving)
        {
            return false;
        }

        return true;
    }

}
