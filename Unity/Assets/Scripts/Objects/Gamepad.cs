using LD54.Requests;
using UniMediator;
using UnityEngine;
using Zenject;

namespace LD54.Objects
{
    public class Gamepad : MonoBehaviour
    {
        [Inject] private IMediator _mediator;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            _mediator.Publish(new StartGamepadMinigameCommand());
        }
    }
}