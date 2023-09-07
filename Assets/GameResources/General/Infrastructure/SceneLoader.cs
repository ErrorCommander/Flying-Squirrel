using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace GameResources.General.Infrastructure
{
   public class SceneLoader
   {
      private ICoroutineRunner _coroutineRunner;
      
      public SceneLoader(ICoroutineRunner coroutineRunner)
      {
         _coroutineRunner = coroutineRunner;
      }

      public void Load(string name, Action onLoad = null) =>
         _coroutineRunner.StartCoroutine(LoadScene(name, onLoad));
      
      private IEnumerator LoadScene(string name, Action onLoad = null)
      {
         SceneManager.LoadSceneAsync(name);
         
         yield return null;
      }
   }
}