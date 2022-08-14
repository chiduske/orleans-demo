using Chiduske.OrleansDemo.GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;

namespace Chiduske.OrleansDemo.Grains;

public class HelloGrain : Grain, IHello
{
    private readonly ILogger<HelloGrain> _log;

    public HelloGrain(ILogger<HelloGrain> log)
    {
        _log = log;
    }

    public Task<string> SayHello(string greeting)
    {
        _log.LogInformation("{GrainMethod} received message: {Greeting}", nameof(SayHello), greeting);
        return Task.FromResult($"Client said: {greeting}, so {nameof(HelloGrain)} says: Hello!");
    }
}