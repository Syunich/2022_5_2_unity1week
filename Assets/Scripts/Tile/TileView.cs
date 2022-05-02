using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileView : MonoBehaviour
{
    [SerializeField] private float ScaleSize;
    [SerializeField] private float ScaleChangeTime;
    [SerializeField] private float RotateChangeTime;
   
    public IEnumerator Reverse()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        var localEulerAngles = transform.localEulerAngles;
        Debug.Log(localEulerAngles);
        var baseScale = transform.localScale;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(new Vector3(transform.localScale.x + ScaleSize, transform.localScale.y + ScaleSize,
            transform.localScale.z), ScaleChangeTime).SetEase(Ease.OutQuart));
        seq.Join(transform.DOLocalRotate(new Vector3((int)localEulerAngles.x + 360, (int)localEulerAngles.y + 180, 0), RotateChangeTime
            , RotateMode.FastBeyond360));
        seq.Append(transform.DOScale(baseScale, ScaleChangeTime).SetEase(Ease.InQuart));

        yield return seq.Play().WaitForCompletion();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

}
