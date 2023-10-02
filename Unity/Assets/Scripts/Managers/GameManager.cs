using LD54.Abstractions;
using LD54.Models;
using LD54.Requests;
using UniMediator;
using UnityEngine;
using Zenject;

namespace LD54.Managers
{
    public class GameManager : MonoBehaviour,
        ISingleMessageHandler<GetGameStateQuery, GameState>,
        IMulticastMessageHandler<FinishGamepadSequenceCommand>
    {
        [Inject] private IMediator _mediator;
        private readonly GameState _gameState = new();

        private void Start()
        {
            StartCoroutine(CoroutineTemplate.DelayAndFireLoopRoutine(1, () =>
            {
                if (!_gameState.IsPaused)
                {
                    _gameState.SecondsElapsed++;
                    _mediator.Publish(new UpdateGameStateCommand(_gameState));
                }
            }));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _gameState.IsPaused = !_gameState.IsPaused;
                _mediator.Publish(new UpdateGameStateCommand(_gameState));
            }
        }
        
        public GameState Handle(GetGameStateQuery message) => _gameState;

        public void Handle(FinishGamepadSequenceCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}