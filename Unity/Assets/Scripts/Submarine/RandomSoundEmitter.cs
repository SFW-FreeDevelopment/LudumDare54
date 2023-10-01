using System;
using LD54.Abstractions;
using LD54.Enums;
using LD54.Requests;
using UniMediator;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace LD54.Submarine
{
    public class RandomSoundEmitter : MonoBehaviour
    {
        [Inject] private IMediator _mediator;
        [SerializeField] private float _intervalMinimum = 5;
        [SerializeField] private float _intervalMaximum = 10;
        [SerializeField] private SoundName[] _soundNames = Array.Empty<SoundName>();

        private void Start() =>
            StartCoroutine(CoroutineTemplate.RandomDelayAndFireLoopRoutine(_intervalMinimum, _intervalMaximum, () =>
                _mediator.Publish(new PlayAudioCommand(_soundNames[Random.Range(0, _soundNames.Length)]))));
    }
}