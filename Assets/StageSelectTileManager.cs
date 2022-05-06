using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageSelectTileManager : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private bool IsClicked = false;
    [SerializeField] private int StageNumber;
    [SerializeField] private TileView view;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Info.IsSceneChanging)
            return;
        
        if (!IsClicked)
        {
            IsClicked = true;
            StartCoroutine(StageChange());
        }
        
    }
    
    private IEnumerator StageChange()
    {
        yield return StartCoroutine(view.Reverse());
        Info.StageNum = StageNumber;
        SyunichTool.SceneChanger.Instance.ChangeScene("GameScene", 0);
    }
}