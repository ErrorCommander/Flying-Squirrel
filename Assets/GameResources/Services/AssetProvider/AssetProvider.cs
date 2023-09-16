using UnityEngine;
using Zenject;

namespace GameResources.Services.AssetProvider
{
   public class AssetProvider : IAssetProvider
   {
      private readonly DiContainer _container;

      public AssetProvider(DiContainer container)
      {
         _container = container;
      }

      public TValue InstantiateAs<TValue>(string path, Transform parent = null) where TValue : Component
      {
         var heroPrefab = Resources.Load<TValue>(path);
         return _container.InstantiatePrefabForComponent<TValue>(heroPrefab, parent);
      }

      public TValue InstantiateAs<TValue>(string path, Vector3 at, Transform parent = null) where TValue : Component
      {
         var heroPrefab = Resources.Load<TValue>(path);
         return _container.InstantiatePrefabForComponent<TValue>(heroPrefab, at, Quaternion.identity, parent);
      }

      public GameObject Instantiate(string path, Transform parent = null)
      {
         var heroPrefab = Resources.Load<GameObject>(path);
         return Object.Instantiate(heroPrefab, parent);
      }

      public GameObject Instantiate(string path, Vector3 at, Transform parent = null)
      {
         var heroPrefab = Resources.Load<GameObject>(path);
         return Object.Instantiate(heroPrefab, at, Quaternion.identity, parent);
      }
   }
}