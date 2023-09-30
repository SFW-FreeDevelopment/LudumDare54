using LD54.Enums;
using UniMediator;

namespace LD54.Requests
{
    public record PlayAudioCommand(
        SoundName SoundName,
        bool Loop = false
    ) : IMulticastMessage { }
}