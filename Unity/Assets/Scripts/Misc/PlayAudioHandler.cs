using LD54.Requests;
using UniMediator;
using UnityEngine;

namespace LD54.Misc
{
    public class PlayAudioHandler : MonoBehaviour, IMulticastMessageHandler<PlayAudioCommand>
    {
        public void Handle(PlayAudioCommand request)
        {
            Debug.Log($"Playing: {request.SoundName.ToString()}");
        }  
    }
}