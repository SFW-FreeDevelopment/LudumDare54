using UniMediator;

namespace LD54.Requests
{
    public record FinishGamepadSequenceCommand(bool Successful) : IMulticastMessage { }
}