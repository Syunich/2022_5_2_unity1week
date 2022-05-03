using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SyunichTool;
using System.Linq;

public class TilesManager : SingletonMonovehavior<TilesManager>
{
    protected override bool IsDestroyOnLoad
    {
        get => true;
    }

    //タイル全般を扱う。
    [SerializeField] MapCreator _mapcreator;
    private TilePresenter[,] presenters;
    private float lengthBetweenTile = 0.8f;

    public int length
    {
        get => presenters.GetLength(0);
    }

    private void Awake()
    {
        presenters = _mapcreator.CreateMap();
    }

    public void Reverse(TilePresenter presenter, ReverseType type)
    {
        Debug.Log(type.ToString());
        GetElementsFromPresenter(presenter);
    }

    private (int i , int j) GetElementsFromPresenter(TilePresenter presenter)
    {
        if (!CheckPresenterInPresenters(presenter))
        {
            Debug.LogError("Cant Find" + presenter + "in Array");
        }

        var x = presenter.transform.localPosition.x;
        var y = presenter.transform.localPosition.y;
        int i = (int)Math.Round(length / 2 - y / lengthBetweenTile + 0.5f * (1 - length % 2));
        int j = (int)Math.Round(x / lengthBetweenTile + length / 2 - 0.5f * (1 - length % 2));

        Debug.Log(i);
        Debug.Log(j);

        return (i, j);
    }

    private bool CheckPresenterInPresenters(TilePresenter presenter)
    {
        bool result = false;
        foreach (var pre in presenters)
        {
            if (pre == presenter)
            {
                result = true;
                break;
            }
        }

        return result;
    }
    
}
    
