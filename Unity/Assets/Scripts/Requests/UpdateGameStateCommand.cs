using LD54.Models;
using UniMediator;

namespace LD54.Requests
{
    public record UpdateGameStateCommand(GameState GameState) : IMulticastMessage { }
}