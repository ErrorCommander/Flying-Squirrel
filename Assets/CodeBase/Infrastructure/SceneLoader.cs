using System;
using System.Collections;
using CodeBase.Services.Curtain;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
   public class SceneLoader
   {
      private readonly ICoroutineRunner _coroutineRunner;
      private readonly IProgressCurtain _progressCurtain;

      public SceneLoader(ICoroutineRunner coroutineRunner, IProgressCurtain progressCurtain)
      {
         _coroutineRunner = coroutineRunner;
         _progressCurtain = progressCurtain;
      }

      public void Load(string name, Action onLoad = null)
      {
         if (SceneManager.GetActiveScene().name == name)
         {
            onLoad?.Invoke();
            _progressCurtain.Hide();
            return;
         }

         Debug.Log("Load Scene " + name);
         _coroutineRunner.StartCoroutine(LoadScene(name, onLoad));
      }

      private IEnumerator LoadScene(string name, Action onLoad = null)
      {
         _progressCurtain.Show();
         yield return new WaitForSecondsRealtime(0.2f);
         var loadScene = SceneManager.LoadSceneAsync(name);
         while (!loadScene.isDone)
         {
            yield return null;
            _progressCurtain.SetProgress(loadScene.progress);
         }
         yield return new WaitForSecondsRealtime(0.2f);
         _progressCurtain.Hide();
         onLoad?.Invoke();
      }
   }
}