using LD54.Abstractions;
using UnityEngine;

namespace LD54.Managers
{
    public class FileSpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _desktop;
        [SerializeField] private GameObject _filePrefab;
        private Coroutine _coroutine;
        
        private void Start()
        {
            _coroutine = StartCoroutine(CoroutineTemplate.FireAndDelayLoopRoutine(0.1f, () =>
            {
                var position = new Vector2(Random.Range(0f, 1500f), Random.Range(100f, 750f));
                Instantiate(_filePrefab, position, Quaternion.identity, _desktop.transform);
                EventManager.FileCreated();
            }));
            EventManager.OnGameOver += OnGameOver;
        }

        private void OnDestroy()
        {
            EventManager.OnGameOver -= OnGameOver;
        }

        private void OnGameOver()
        {
            StopCoroutine(_coroutine);
        }
    }
}