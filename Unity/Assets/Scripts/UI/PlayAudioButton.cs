using LD54.Enums;
using LD54.Requests;
using UnityEngine;

namespace LD54.UI
{
    public class PlayAudioButton : CommandButton<PlayAudioCommand>
    {
        [SerializeField] private SoundName _soundName;

        protected override PlayAudioCommand Command => new(_soundName);
    }
}