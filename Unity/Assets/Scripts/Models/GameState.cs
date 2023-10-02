using System;

namespace LD54.Models
{
    public class GameState
    {
        public bool IsPaused { get; set; }
        public bool GameOver { get; set; }
        public DateTime TimeStarted { get; set; } = DateTime.UtcNow;
        public DateTime TimeEnded { get; set; }
        public TimeSpan TimeElapsed => TimeEnded - TimeStarted;
        public int FilesCreated { get; set; }
        public int FilesDeleted { get; set; }
        public int CurrentFiles => FilesCreated - FilesDeleted;
        public bool HighscoreWindowOpen { get; set; }
    }
}