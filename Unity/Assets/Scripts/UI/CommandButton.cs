using UniMediator;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LD54.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class CommandButton<TCommand> : ButtonBase where TCommand : IMulticastMessage
    {
        [Inject] protected IMediator _mediator;

        protected abstract TCommand Command { get; }
        
        protected override void OnClick() => _mediator.Publish(Command);
    }
}