using Cinemachine;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Services.Factory
{
   public interface IGameFactory
   {
      HeroMove CreateHero();
      CinemachineVirtualCamera CreateFollowCamera(Transform target);
   }
}