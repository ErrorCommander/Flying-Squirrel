using UnityEngine;

namespace GameResources.Services.AssetProvider
{
   public interface IAssetProvider
   {
      TValue InstantiateAs<TValue>(string path, Transform parent = null) where TValue : Component;
      TValue InstantiateAs<TValue>(string path, Vector3 at, Transform parent = null) where TValue : Component;
      GameObject Instantiate(string path, Transform parent = null);
      GameObject Instantiate(string path, Vector3 at, Transform parent = null);
   }
}