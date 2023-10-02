using LD54.Abstractions;
using LD54.Enums;
using LD54.Managers;
using UnityEngine;

namespace LD54.Behaviors
{
    public class PlaySoundOnStart : MonoBehaviour
    {
        [SerializeField] private SoundName _soundName;
        [SerializeField] private bool _loop;

        private void Start() => StartCoroutine(CoroutineTemplate.DelayAndFireRoutine(0.1f, () => AudioManager.Instance.Play(_soundName)));
    }
}