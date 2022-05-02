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
        var baseScale = transform.localScale;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(new Vector3(transform.localScale.x + ScaleSize, transform.localScale.y + ScaleSize,
            transform.localScale.z), ScaleChangeTime).SetEase(Ease.OutQuart));
        seq.Join(transform.DOLocalRotate(new Vector3(transform.localEulerAngles.x, 0, 0), RotateChangeTime));
        seq.Append(transform.DOScale(baseScale, ScaleChangeTime));

        yield return seq.Play().WaitForCompletion();
    }

}
