using LD54.Enums;
using UniMediator;

namespace LD54.Requests
{
    public record PressGamepadButtonCommand(GamepadButton GamepadButton) : IMulticastMessage { }
}