using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SyunichTool;
using DG.Tweening;

public class Effector_fan : SceneChangeEffector
{
    [SerializeField] Transform _leftFanPivot;
    [SerializeField] Transform _rightFanPivot;
    private readonly float _rotateTime = 2.0f;
    private readonly float _stayTime = 0.7f;
    public override IEnumerator RunBefore()
    {
        //左は90 -> -45 -> -180
        //右は-90 -> 45 -> 180
        Sequence seq = DOTween.Sequence();
        seq.Append(_leftFanPivot.DOLocalRotate(new Vector3(0, 0, -45), _rotateTime).SetEase(Ease.OutCubic));
        seq.Join(_rightFanPivot.DOLocalRotate(new Vector3(0, 0, 45), _rotateTime).SetEase(Ease.OutCubic));

        yield return seq.Play().WaitForCompletion();
    }

    public override IEnumerator RunAfter()
    {
        yield return new WaitForSeconds(_stayTime);

        Sequence seq = DOTween.Sequence();
        seq.Append(_leftFanPivot.DOLocalRotate(new Vector3(0, 0, -180), _rotateTime).SetEase(Ease.InCubic));
        seq.Join(_rightFanPivot.DOLocalRotate(new Vector3(0, 0, 180), _rotateTime).SetEase(Ease.InCubic));

        yield return seq.Play().WaitForCompletion();

        _leftFanPivot.DOKill();
        _rightFanPivot.DOKill();

        Destroy(this.gameObject);
    }


}
