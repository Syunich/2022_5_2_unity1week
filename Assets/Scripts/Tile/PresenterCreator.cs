using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterCreator : MonoBehaviour
{
    /// <summary>
    /// TilePresenter専用Instantiate、表裏を指定する必要がある
    /// </summary>
    /// <param name="obj">生成オブジェクト</param>
    /// <param name="position">生成位置</param>
    /// <param name="isWhite">白側で置くか</param>
    /// <returns></returns>
    /// 
    public static TilePresenter Iinstantiate(GameObject obj , Vector3 position , bool isWhite)
    {
        if (obj.GetComponent<TilePresenter>() == null)
            return null;

        float rotateXvalue;
        if (isWhite)
        {
            rotateXvalue = 180;
        }
        else
        {
            rotateXvalue = 0;
        }

        var presenter = Instantiate(obj, position, Quaternion.Euler(rotateXvalue, 0, 0)).GetComponent<TilePresenter>();
        presenter.SetModel(new TileModel(isWhite));

        return presenter;
    }
}
