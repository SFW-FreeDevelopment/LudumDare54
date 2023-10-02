using LD54.Models;
using UniMediator;

namespace LD54.Requests
{
    public record GetGameStateQuery : ISingleMessage<GameState> { }
}