using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameResources.General.Infrastructure
{
   public class SceneLoader
   {
      private readonly ICoroutineRunner _coroutineRunner;
      
      public SceneLoader(ICoroutineRunner coroutineRunner)
      {
         _coroutineRunner = coroutineRunner;
      }

      public void Load(string name, Action onLoad = null)
      {
         Debug.Log("Load Scene " + name);
         _coroutineRunner.StartCoroutine(LoadScene(name, onLoad));
      }

      private IEnumerator LoadScene(string name, Action onLoad = null)
      {
         yield return SceneManager.LoadSceneAsync(name);
         onLoad?.Invoke();
      }
   }
}