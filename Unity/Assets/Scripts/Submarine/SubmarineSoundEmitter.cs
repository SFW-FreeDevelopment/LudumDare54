using LD54.Abstractions;
using LD54.Enums;
using LD54.Requests;
using UniMediator;
using UnityEngine;
using Zenject;

namespace LD54.Submarine
{
    public class SubmarineSoundEmitter : MonoBehaviour
    {
        [Inject] private IMediator _mediator;
        [SerializeField] private float _intervalMinimum = 5;
        [SerializeField] private float _intervalMaximum = 10;
        
        private void Start() =>
            StartCoroutine(CoroutineTemplate.RandomDelayAndFireLoopRoutine(_intervalMinimum, _intervalMaximum, () =>
            {
                _mediator.Publish(new PlayAudioCommand(Random.Range(1, 7) switch
                {
                    1 => SoundName.SubCreak1,
                    2 => SoundName.SubCreak2,
                    3 => SoundName.SubCreak3,
                    4 => SoundName.SubCreak4,
                    5 => SoundName.SubCreak5,
                    6 => SoundName.SubCreak6,
                    _ => SoundName.SubCreak1
                }));
            }));
    }
}