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
        if (Info.IsSceneChanging)
            return;
            
        //同時押しの場合は見過ごす
        if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.X))
            return;
        
        if (Input.GetKey(KeyCode.Z))
        {
            StartCoroutine(TilesManager.Instance.Reverse(presenter , ReverseType.Cross));
            return;
        }

        if (Input.GetKey(KeyCode.X))
        {
            StartCoroutine(TilesManager.Instance.Reverse(presenter, ReverseType.Square));
            return;
        }
        StartCoroutine(TilesManager.Instance.Reverse(presenter, ReverseType.One));
    }
}

public enum ReverseType
{
    One,
    Cross,
    Square
}
