using LD54.Abstractions;
using UnityEngine;

namespace LD54.Managers
{
    public class FileSpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform _bottomLeftCorner, _topRightCorner;
        [SerializeField] private GameObject _desktop;
        [SerializeField] private GameObject _filePrefab;
        private Coroutine _coroutine;
        
        private void Start()
        {
            _coroutine = StartCoroutine(CoroutineTemplate.FireAndDelayLoopRoutine(0.1f, () =>
            {
                var bottomLeftCornerPosition = _bottomLeftCorner.position;
                var topRightCornerPosition = _topRightCorner.position;
                var position = new Vector2(
                    Random.Range(bottomLeftCornerPosition.x, topRightCornerPosition.x),
                    Random.Range(bottomLeftCornerPosition.y, topRightCornerPosition.y));
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