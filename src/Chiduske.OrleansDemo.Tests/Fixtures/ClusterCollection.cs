using Xunit;

namespace Chiduske.OrleansDemo.Tests.Fixtures;

[CollectionDefinition(Name)]
public class ClusterCollection : ICollectionFixture<ClusterFixture>
{
    public const string Name = "ClusterCollection";
}