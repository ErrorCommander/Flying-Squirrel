using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Services.Curtain
{
   public class LoadingCurtain : MonoBehaviour, IProgressCurtain
   {
      [SerializeField] private CanvasGroup _canvasGroup;
      [SerializeField, Range(0, 2)] private float _fadeDuration = 0.5f;
      [SerializeField] private Slider _slider;
      [SerializeField] private TMP_Text _progressText;
      
      private Tweener _fade;

      public void Show()
      {
         _fade.Kill();
         _fade = _canvasGroup.DOFade(1, _fadeDuration);
         _canvasGroup.blocksRaycasts = true;
         SetProgress(0);
      }

      public void Hide()
      {
         _fade.Kill();
         _fade = _canvasGroup.DOFade(0, _fadeDuration);
         _canvasGroup.blocksRaycasts = false;
      }

      public void SetProgress(float progress)
      {
         _slider.normalizedValue = progress;
         _progressText.text = progress.ToString("P0");
      }
   }
}