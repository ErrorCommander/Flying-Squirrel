using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI
{
    public class LoadGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [Inject] private Game _game;
    
        private void Awake()
        {
            _button.onClick.AddListener(LoadGameScene);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(LoadGameScene);
        }

        private void LoadGameScene()
        {
            _game.StateMachine.Enter<LoadGameState, string>("Game");
        }
    }
}
