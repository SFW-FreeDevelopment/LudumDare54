using UniMediator;
using UnityEngine;

namespace Requests
{
    public class TestCommandHandler : MonoBehaviour, IMulticastMessageHandler<TestCommand>
    {
        public void Handle(TestCommand request)
        {
            Debug.Log(request.Message);
        }  
    }
}