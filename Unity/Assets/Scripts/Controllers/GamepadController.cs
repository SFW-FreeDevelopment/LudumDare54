using System;
using LD54.Enums;
using LD54.Requests;
using UniMediator;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LD54.Controllers
{
    public class GamepadController : MonoBehaviour
    {
        [Inject] private IMediator _mediator;
        [SerializeField] private Button _aButton, _bButton, _xButton, _yButton;

        private void Start()
        {
            _aButton.onClick.AddListener(() => PressGamepadButton(GamepadButton.A));
            _bButton.onClick.AddListener(() => PressGamepadButton(GamepadButton.B));
            _xButton.onClick.AddListener(() => PressGamepadButton(GamepadButton.X));
            _yButton.onClick.AddListener(() => PressGamepadButton(GamepadButton.Y));
        }

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) PressGamepadButton(GamepadButton.A);
            if (Input.GetKeyDown(KeyCode.B)) PressGamepadButton(GamepadButton.B);
            if (Input.GetKeyDown(KeyCode.X)) PressGamepadButton(GamepadButton.X);
            if (Input.GetKeyDown(KeyCode.Y)) PressGamepadButton(GamepadButton.Y);
        }

        private void PressGamepadButton(GamepadButton gamepadButton) =>
            _mediator.Publish(new PressGamepadButtonCommand(gamepadButton));
    }
}