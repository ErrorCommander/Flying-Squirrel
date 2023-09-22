using Cinemachine;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Services.Factory
{
   public interface IGameFactory
   {
      PlayerMove CreateHero();
      CinemachineVirtualCamera CreateFollowCamera(Transform target);
      GameObject CreateMobileJoystick();
      GameObject CreateMainMenu();
   }
}