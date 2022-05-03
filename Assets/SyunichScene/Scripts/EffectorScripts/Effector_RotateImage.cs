using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using SyunichTool;
using DG.Tweening;

public class Effector_RotateImage : SceneChangeEffector
{
    [SerializeField] RectTransform _imagetransform;

    //rotate and scaling image before scene change
    public override IEnumerator RunBefore()
    {
        _imagetransform.DOLocalRotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360).SetLoops(-1).Play();
        yield return _imagetransform.DOScale(new Vector3(30, 30, 0), 2f).Play().WaitForCompletion();
        yield return new WaitForSeconds(0.5f);
    }

    //rotate and scaling image after scene change. finally , this prefab destroyed.
    public override IEnumerator RunAfter()
    {
        yield return _imagetransform.DOScale(new Vector3(0, 0, 0), 2f).Play().WaitForCompletion();
        _imagetransform.DOKill();
        Destroy(this.gameObject);

    }
}
