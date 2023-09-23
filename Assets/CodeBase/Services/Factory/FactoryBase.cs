using CodeBase.Services.AssetProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factory
{
   public abstract class FactoryBase
   {
      private readonly IAssetProvider _assetProvider;
      private readonly DiContainer _container;

      protected FactoryBase(DiContainer container, IAssetProvider assetProvider)
      {
         _assetProvider = assetProvider;
         _container = container;
      }

      protected GameObject Instantiate(string prefabPath, Transform parent = null)
      {
         var prefab = _assetProvider.Load(prefabPath);
         return Object.Instantiate(prefab, parent);
      }

      protected GameObject Instantiate(string prefabPath, Vector3 at)
      {
         var prefab = _assetProvider.Load(prefabPath);
         return Object.Instantiate(prefab, at, Quaternion.identity);
      }

      protected TValue Instantiate<TValue>(string prefabPath, Transform parent = null) where TValue : Component
      {
         TValue prefab = _assetProvider.LoadAs<TValue>(prefabPath);
         return Object.Instantiate(prefab, parent);
      }

      protected TValue Instantiate<TValue>(string prefabPath, Vector3 at) where TValue : Component
      {
         TValue prefab = _assetProvider.LoadAs<TValue>(prefabPath);
         return Object.Instantiate(prefab, at, Quaternion.identity);
      }

      protected TValue Inject<TValue>(TValue instance) where TValue : Component
      {
         _container.Inject(instance);
         return instance;
      }
   }
}