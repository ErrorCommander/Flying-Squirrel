using UnityEngine;

namespace GameResources.Services.AssetProvider
{
   public class AssetProvider : IAssetProvider
   {
      public TValue LoadAs<TValue>(string path) where TValue : Component => 
         Resources.Load<TValue>(path);

      public GameObject Load(string path) => 
         Resources.Load<GameObject>(path);
   }
}