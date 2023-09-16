using Cinemachine;
using GameResources.Player;
using UnityEngine;

namespace GameResources.Services.Factory
{
   public interface IGameFactory
   {
      PlayerMove CreateHero();
      CinemachineVirtualCamera CreateFollowCamera();
      GameObject CreateMobileJoystick();
   }
}