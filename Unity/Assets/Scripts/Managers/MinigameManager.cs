using System;
using LD54.Abstractions;
using LD54.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD54.Managers
{
    public sealed class MinigameManager : SceneSingleton<MinigameManager>
    {
        private const int MAX_NUMBER_OF_FILES = 255;
        
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

        private void Update()
        {
            if (!GameState.GameOver) return;
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Startup");
            }
        }

        private void OnFileCreated()
        {
            GameState.FilesCreated++;
            if (GameState.CurrentFiles > MAX_NUMBER_OF_FILES)
            {
                GameState.GameOver = true;
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