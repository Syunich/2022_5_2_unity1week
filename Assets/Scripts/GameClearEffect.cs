using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameClearEffect : MonoBehaviour
{
   [SerializeField] private ParticleSystem ClearParticle;
   [SerializeField] private CanvasGroup ClearCG;
   [SerializeField] private Image whiteBackGround;


   public IEnumerator GameClearUIMoving()
   {
      Instantiate(ClearParticle);
      whiteBackGround.enabled = true;
      yield return new WaitForSeconds(0.8f);
      yield return StartCoroutine(UpAndFadeIn(ClearCG , 2.5f));
      ClearCG.interactable = true;
   }

   private IEnumerator UpAndFadeIn(CanvasGroup CG, float time)
   {
      CG.DOFade(1, time).SetEase(Ease.OutQuart).Play();
      yield return CG.transform.DOLocalMoveY(transform.localPosition.y + 40, time).SetEase(Ease.OutQuart).Play().WaitForCompletion();
   }
}
