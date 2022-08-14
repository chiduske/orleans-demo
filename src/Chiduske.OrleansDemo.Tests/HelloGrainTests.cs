using Chiduske.OrleansDemo.GrainInterfaces;
using FluentAssertions;
using Orleans.TestingHost;
using Xunit;

namespace Chiduske.OrleansDemo.Tests;

public class HelloGrainTests
{
    [Fact]
    public async Task SaysHelloCorrectly()
    {
        var builder = new TestClusterBuilder();
        var cluster = builder.Build();
        await cluster.DeployAsync();

        var hello = cluster.GrainFactory.GetGrain<IHello>(0);
        var greeting = await hello.SayHello("Hi there!");
        
        await cluster.StopAllSilosAsync();

        greeting.Should().Be("Hello, World");
    }
}