using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneChangeTileManager : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private bool IsClicked = false;
    [SerializeField] private string sceneName;
    [SerializeField] private TileView view;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Info.IsSceneChanging)
            return;

        if (!IsClicked)
        {
            IsClicked = true;
            StartCoroutine(SceneChange());
        }
    }

    private IEnumerator SceneChange()
    {
        yield return StartCoroutine(view.Reverse());
        SyunichTool.SceneChanger.Instance.ChangeScene(sceneName, 0);
    }
    
}
