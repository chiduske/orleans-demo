using Orleans;

namespace Chiduske.OrleansDemo.GrainInterfaces;

public interface IHello : IGrainWithIntegerKey
{
    Task<string> SayHello(string greeting);
}