using System;

namespace LD54.Managers
{
    public static class EventManager
    {
        public static event Action OnFileCreated;
        public static void FileCreated() => OnFileCreated?.Invoke();
        
        public static event Action OnFileDeleted;
        public static void FileDeleted() => OnFileDeleted?.Invoke();

        public static event Action OnGameOver;
        public static void GameOver() => OnGameOver?.Invoke();

        
        public static event Action OnRefreshUI;
        public static void RefreshUI() => OnRefreshUI?.Invoke();
    }
}