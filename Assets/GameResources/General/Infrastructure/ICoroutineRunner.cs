using System.Collections;
using UnityEngine;

namespace GameResources.General.Infrastructure
{
   public interface ICoroutineRunner
   {
      public Coroutine StartCoroutine(IEnumerator coroutine);
   }
}