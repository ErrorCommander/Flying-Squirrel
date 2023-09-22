using UnityEngine;

namespace CodeBase.Services.AssetProvider
{
   public interface IAssetProvider
   {
      TValue LoadAs<TValue>(string path) where TValue : Component;
      GameObject Load(string path);
   }
}