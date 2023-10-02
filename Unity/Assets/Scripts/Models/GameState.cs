namespace LD54.Models
{
    public class GameState
    {
        public bool IsPaused { get; set; }
        public float TimeElapsed { get; set; }
        public int FilesCreated { get; set; }
        public int FilesDeleted { get; set; }
        public int CurrentFiles => FilesCreated - FilesDeleted;
    }
}