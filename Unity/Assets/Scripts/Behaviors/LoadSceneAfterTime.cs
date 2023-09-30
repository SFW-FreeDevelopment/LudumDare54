using LD54.Abstractions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD54.Behaviors
{
    public class LoadSceneAfterTime : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private float _time;

        private void Start() =>
            StartCoroutine(CoroutineTemplate.DelayAndFireRoutine(_time, () =>
                SceneManager.LoadScene(_sceneName)));
    }
}