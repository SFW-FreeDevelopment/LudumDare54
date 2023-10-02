using LD54.Abstractions;
using UnityEngine;

namespace LD54.Managers
{
    public class MinigameUIManager : SceneSingleton<MinigameUIManager>
    {
        [SerializeField] private GameObject _blueScreenOfDeath, _submitHighscoreWindow;
        
        private void OnEnable()
        {
            EventManager.OnGameOver += OnGameOver;
            EventManager.OnRefreshUI += OnRefreshUI;
        }

        protected override void InitSingletonInstance()
        {
            // do nothing
        }

        private void OnDisable()
        {
            EventManager.OnGameOver -= OnGameOver;
            EventManager.OnRefreshUI -= OnRefreshUI;
        }

        private void OnGameOver()
        {
            _blueScreenOfDeath.SetActive(true);
        }

        private void OnRefreshUI()
        {
            var gameState = MinigameManager.Instance.GameState;
            if (gameState.HighscoreWindowOpen)
                _submitHighscoreWindow.SetActive(true);
        }
    }
}