using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    //タイル全般を扱う。
    [SerializeField] MapCreator _mapcreator;
    private TilePresenter[,] presenters;

    public int length
    {
        get => presenters.GetLength(0);
    }
    private void Awake()
    {
        presenters = _mapcreator.CreateMap();
    }
}
