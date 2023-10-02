using LD54.Abstractions;
using LD54.Requests;
using UniMediator;
using UnityEngine;
using Zenject;

namespace LD54.Controllers
{
    [RequireComponent(typeof(Light))]
    public class FlashlightController : MonoBehaviour,
        ISingleMessageHandler<GetFlashlightChargeQuery, byte>,
        IMulticastMessageHandler<CollectBatteryCommand>
    {
        [Inject] private IMediator _mediator;
        [SerializeField] private float _drainInterval = 3;
        [SerializeField] private Light _light;
        
        private byte _currentCharge = 20;

        private void Awake()
        {
            if (_light == null) _light = GetComponent<Light>();
        }

        private void Start() =>
            StartCoroutine(CoroutineTemplate.DelayAndFireLoopRoutine(_drainInterval, () =>
            {
                if (_currentCharge <= 0) return;
                var gameState = _mediator.Send(new GetGameStateQuery());
                if (!gameState.IsPaused) _currentCharge--;
                if (_currentCharge == 0) _light.enabled = false;
            }));

        public byte Handle(GetFlashlightChargeQuery message) => _currentCharge;

        public void Handle(CollectBatteryCommand message) => _currentCharge += 5;
    }
}