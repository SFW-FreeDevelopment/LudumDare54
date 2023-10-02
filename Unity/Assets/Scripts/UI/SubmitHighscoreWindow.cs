using System;
using LD54.Clients;
using LD54.Managers;
using LD54.Models;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LD54.UI
{
    public class SubmitHighscoreWindow : MonoBehaviour
    {
        [SerializeField] private Button _okButton;
        [SerializeField] private TMP_InputField _nameInput;
        [SerializeField] private TextMeshProUGUI _filesDeletedText, _timeElapsedText;
        
        private void Start()
        {
            _okButton.onClick.AddListener(PostResults);
        }

        private void OnEnable()
        {
            var gameState = MinigameManager.Instance.GameState;
            _filesDeletedText.text = $"Files Deleted: <b>{gameState.FilesDeleted}</b>";
            _timeElapsedText.text = $"Time Elapsed: <b>{gameState.TimeElapsed.Minutes}m {gameState.TimeElapsed.Seconds}s</b>";
        }

        private void OnDisable()
        {
            SceneManager.LoadScene("Startup");
        }

        private void PostResults()
        {
            try
            {
                var gameState = MinigameManager.Instance.GameState;
                ApiClient.SubmitHighscore(new HighscoreDTO
                {
                    Name = _nameInput.text,
                    TimeTaken = gameState.TimeElapsed.TotalSeconds,
                    TimeFinished = gameState.TimeEnded,
                    Items = gameState.FilesDeleted
                }, null);
            }
            catch
            {
                // do nothing
            }
            gameObject.SetActive(false);
        }
    }
}