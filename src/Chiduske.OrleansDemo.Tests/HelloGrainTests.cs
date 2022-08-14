using Chiduske.OrleansDemo.GrainInterfaces;
using Chiduske.OrleansDemo.Tests.Fixtures;
using FluentAssertions;
using Orleans.TestingHost;
using Xunit;

namespace Chiduske.OrleansDemo.Tests;

[Collection(ClusterCollection.Name)]
public class HelloGrainTests
{
    private readonly TestCluster _cluster;

    public HelloGrainTests(ClusterFixture fixture)
    {
        _cluster = fixture.Cluster;
    }

    [Fact]
    public async Task SaysHelloCorrectly()
    {
        var hello = _cluster.GrainFactory.GetGrain<IHello>(0);
        var greeting = await hello.SayHello("Hi there!");

        greeting.Should().Be("Hello, World");
    }
}