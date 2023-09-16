using UnityEngine;

namespace GameResources.Services.Factory
{
   public interface IGameFactory
   {
      TValue Instantiate<TValue>(string path, Transform parent = null) where TValue : Component;
      TValue Instantiate<TValue>(string path, Vector3 at, Transform parent = null) where TValue : Component;
      GameObject Instantiate(string path, Transform parent = null);
      GameObject Instantiate(string path, Vector3 at, Transform parent = null);
   }
}