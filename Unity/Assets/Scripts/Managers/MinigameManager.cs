using System;
using LD54.Abstractions;
using LD54.Enums;
using LD54.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD54.Managers
{
    public sealed class MinigameManager : SceneSingleton<MinigameManager>
    {
        private const int MAX_NUMBER_OF_FILES = 255;
        
        public GameState GameState { get; private set; } = new();

        private void OnEnable()
        {
            EventManager.OnFileCreated += OnFileCreated;
            EventManager.OnFileDeleted += OnFileDeleted;
        }

        protected override void InitSingletonInstance()
        {
            ResetMinigame();
        }

        private void OnDisable()
        {
            EventManager.OnFileCreated -= OnFileCreated;
            EventManager.OnFileDeleted -= OnFileDeleted;
        }

        private void Update()
        {
            if (!GameState.GameOver) return;
            if (GameState.HighscoreWindowOpen) return;
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                GameState.HighscoreWindowOpen = true;
                EventManager.RefreshUI();
            }
        }

        private void OnFileCreated()
        {
            GameState.FilesCreated++;
            AudioManager.Instance.Play(SoundName.Click);
            if (GameState.CurrentFiles > MAX_NUMBER_OF_FILES)
            {
                GameState.GameOver = true;
                GameState.TimeEnded = DateTime.UtcNow;
                EventManager.GameOver();
            }
        }

        private void OnFileDeleted()
        {
            GameState.FilesDeleted++;
            AudioManager.Instance.Play(SoundName.Delete);
            EventManager.RefreshUI();
        }

        private void ResetMinigame()
        {
            GameState = new();
        }
    }
}