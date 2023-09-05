using Cinemachine;
using GameResources.Player;
using UnityEngine;
using Zenject;

namespace GameResources.General.Infrastructure
{
   public class GameBootstrapper : MonoBehaviour
   {
      public Transform _spawnPoint;
      public PlayerMove _playerPrefab;
      public CinemachineVirtualCamera _Camera;

      [Inject] private DiContainer _container;
      private Game _game;

      private void Awake()
      {
         _game = new Game(_container);

         CreatePlayer();

         DontDestroyOnLoad(this);
      }


      private void CreatePlayer()
      {
         _Camera.Follow = _container.InstantiatePrefabForComponent<PlayerMove>(_playerPrefab,
            _spawnPoint.transform.position, Quaternion.identity, null).transform;
      }
   }
}