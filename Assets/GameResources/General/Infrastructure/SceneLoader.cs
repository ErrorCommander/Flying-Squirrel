using System;
using System.Collections;
using GameResources.Services.Curtain;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameResources.General.Infrastructure
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
         Debug.Log("Load Scene " + name);
         _coroutineRunner.StartCoroutine(LoadScene(name, onLoad));
      }

      private IEnumerator LoadScene(string name, Action onLoad = null)
      {
         _progressCurtain.Show();
         var loadScene = SceneManager.LoadSceneAsync(name);
         while (!loadScene.isDone)
         {
            yield return null;
            _progressCurtain.SetProgress(loadScene.progress);
         }
         onLoad?.Invoke();
         _progressCurtain.Hide();
      }
   }
}