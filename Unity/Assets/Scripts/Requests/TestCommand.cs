using UniMediator;

namespace Requests
{
    public class TestCommand : IMulticastMessage
    {
        public string Message { get; set; }

        public TestCommand(string message)
        {
            Message = message;
        }
    }
}