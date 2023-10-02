using LD54.Abstractions;
using UnityEngine;

namespace LD54.Managers
{
    public class MinigameUIManager : SceneSingleton<MinigameUIManager>
    {
        [SerializeField] private GameObject _blueScreenOfDeath;
        
        private void Awake()
        {
            EventManager.OnGameOver += OnGameOver;
        }

        protected override void InitSingletonInstance()
        {
            // do nothing
        }

        private void OnDestroy()
        {
            EventManager.OnGameOver -= OnGameOver;
        }

        private void OnGameOver()
        {
            _blueScreenOfDeath.SetActive(true);
        }
    }
}