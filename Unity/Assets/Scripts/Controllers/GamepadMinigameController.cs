using System;
using System.Collections;
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
        [SerializeField] private Canvas _gamepadMinigameCanvas;
        [SerializeField] private GamepadController _gamepadController;
        private GamepadButton[] _buttonValues, _currentSequence;
        private byte _currentCombo;
        private bool _showingSequence;

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
            if (_currentSequence == null || _currentSequence.Length == 0 || _currentCombo == _currentSequence.Length || _showingSequence)
                return;

            if (message.GamepadButton == _currentSequence[_currentCombo])
            {
                if (++_currentCombo == _currentSequence.Length)
                {
                    _mediator.Publish(new FinishGamepadSequenceCommand(true));
                }
            }
            else
            {
                _mediator.Publish(new FinishGamepadSequenceCommand(false));
            }
        }

        public void Handle(StartGamepadMinigameCommand message) => StartCoroutine(Routine());

        private IEnumerator Routine()
        {
            _gamepadMinigameCanvas.enabled = true;
            GenerateSequence(2);
            _showingSequence = true;
            for (var i = 0; i < 2; i++)
            {
                var currentButton = _currentSequence[i];
                if (currentButton == GamepadButton.A)
                    _gamepadController.AButtonOutline.enabled = true;
                else if (currentButton == GamepadButton.B)
                    _gamepadController.BButtonOutline.enabled = true;
                else if (currentButton == GamepadButton.X)
                    _gamepadController.XButtonOutline.enabled = true;
                else if (currentButton == GamepadButton.Y)
                    _gamepadController.YButtonOutline.enabled = true;
                
                yield return new WaitForSeconds(0.5f);
                
                if (currentButton == GamepadButton.A)
                    _gamepadController.AButtonOutline.enabled = false;
                else if (currentButton == GamepadButton.B)
                    _gamepadController.BButtonOutline.enabled = false;
                else if (currentButton == GamepadButton.X)
                    _gamepadController.XButtonOutline.enabled = false;
                else if (currentButton == GamepadButton.Y)
                    _gamepadController.YButtonOutline.enabled = false;
            }
            _showingSequence = false;
            
            
        }
    }
}