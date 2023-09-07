using System;
using Cinemachine;
using GameResources.Player;
using UnityEngine;
using Zenject;

namespace GameResources.General.Infrastructure
{
   public class SpawnPlayer : MonoBehaviour
   {
      [SerializeField] private CinemachineVirtualCamera _camera;
      [SerializeField] private PlayerMove _playerPrefab;
      [SerializeField] private Transform _spawnPoint;

      [Inject] private DiContainer _container;

      private void Start()
      {
         CreatePlayer(_camera, _playerPrefab, _spawnPoint);
      }

      public void CreatePlayer(CinemachineVirtualCamera camera, PlayerMove playerPrefab, Transform spawnPoint)
      {
         camera.Follow = _container.InstantiatePrefabForComponent<PlayerMove>(playerPrefab,
            spawnPoint.transform.position, Quaternion.identity, null).transform;
      }
   }
}