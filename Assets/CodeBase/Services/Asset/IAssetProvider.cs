using UnityEngine;

namespace CodeBase.Services.Asset
{
   public interface IAssetProvider
   {
      TValue LoadAs<TValue>(string path) where TValue : Component;
      GameObject Load(string path);
   }
}