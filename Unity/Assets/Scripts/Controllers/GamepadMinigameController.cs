using System;
using System.Linq;
using LD54.Enums;
using LD54.Requests;
using UniMediator;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace LD54.Controllers
{
    public class GamepadMinigameController : MonoBehaviour,
        IMulticastMessageHandler<PressGamepadButtonCommand>,
        IMulticastMessageHandler<StartGamepadMinigameCommand>
    {
        [Inject] private IMediator _mediator;
        private GamepadButton[] _buttonValues, _currentSequence;
        private byte _currentCombo;

        private void Awake()
        {
            _buttonValues = Enum.GetValues(typeof(GamepadButton)).Cast<GamepadButton>().ToArray();
        }

        private void GenerateSequence(int length)
        {
            _currentSequence = new GamepadButton[length];
            _currentCombo = 0;
            for (var i = 0; i < length; i++)
            {
                _currentSequence[i] = _buttonValues[Random.Range(0, _buttonValues.Length)];
            }
        }
        
        public void Handle(PressGamepadButtonCommand message)
        {
            if (_currentSequence == null || _currentSequence.Length == 0 || _currentCombo == _currentSequence.Length)
                return;

            if (message.GamepadButton == _currentSequence[_currentCombo])
            {
                if (++_currentCombo == _currentSequence.Length)
                    _mediator.Publish(new FinishGamepadSequenceCommand(true));
            }
            else
            {
                _mediator.Publish(new FinishGamepadSequenceCommand(false));
            }
        }

        public void Handle(StartGamepadMinigameCommand message)
        {
            throw new NotImplementedException();
        }
    }
}