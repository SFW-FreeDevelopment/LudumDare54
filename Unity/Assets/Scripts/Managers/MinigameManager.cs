using LD54.Abstractions;
using LD54.Models;
using UnityEngine;

namespace LD54.Managers
{
    public sealed class MinigameManager : SceneSingleton<MinigameManager>
    {
        private const int MAX_NUMBER_OF_FILES = 100;
        
        public GameState GameState { get; private set; } = new();

        private void Awake()
        {
            EventManager.OnFileCreated += OnFileCreated;
            EventManager.OnFileDeleted += OnFileDeleted;
        }

        protected override void InitSingletonInstance()
        {
            ResetMinigame();
        }

        private void OnDestroy()
        {
            EventManager.OnFileCreated -= OnFileCreated;
            EventManager.OnFileDeleted -= OnFileDeleted;
        }

        private void OnFileCreated()
        {
            GameState.FilesCreated++;
            if (GameState.CurrentFiles > MAX_NUMBER_OF_FILES)
            {
                EventManager.GameOver();
            }
        }

        private void OnFileDeleted()
        {
            GameState.FilesDeleted++;
            EventManager.RefreshUI();
        }

        private void ResetMinigame()
        {
            GameState = new();
        }
    }
}