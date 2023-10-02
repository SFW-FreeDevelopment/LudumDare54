using LD54.Requests;
using UniMediator;
using UnityEngine;

namespace LD54.Managers
{
    public class GameUIManager : MonoBehaviour,
        IMulticastMessageHandler<UpdateGameStateCommand>
    {
        public void Handle(UpdateGameStateCommand message)
        {
            // do nothing
        }
    }
}