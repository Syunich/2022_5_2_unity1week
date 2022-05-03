using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using SyunichTool;

namespace SyunichSample
{
    /// <summary>
    /// 一枚絵でシーン遷移するシーン遷移エフェクター
    /// </summary>
    public sealed class SampleFeedOneImage : SceneChangeEffector
    {
        [SerializeField] Image _feedimage;
        private readonly float _fadespeed = 1.0f;

        public override IEnumerator RunBefore()
        {
            _feedimage.raycastTarget = true;
            yield return _feedimage.DOFade(1, _fadespeed).Play().WaitForCompletion();
        }

        public override IEnumerator RunAfter()
        {
            yield return _feedimage.DOFade(0, _fadespeed).Play().WaitForCompletion();
            _feedimage.raycastTarget = false;
            Debug.Log($"{typeof(SampleFeedOneImage).FullName}:シーン遷移完了");
            Destroy(this.gameObject);
        }
    }
}
