using LD54.Abstractions;
using LD54.Enums;
using LD54.Managers;
using UniMediator;
using UnityEngine;
using Zenject;

namespace LD54.Behaviors
{
    public class PlaySoundOnStart : MonoBehaviour
    {
        [Inject] private IMediator _mediator;
        [SerializeField] private SoundName _soundName;
        [SerializeField] private bool _loop;

        private void Start() => StartCoroutine(CoroutineTemplate.DelayAndFireRoutine(0.1f, () => AudioManager.Instance.Play(_soundName)));
    }
}