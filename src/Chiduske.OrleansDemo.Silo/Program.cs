using Chiduske.OrleansDemo.Grains;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

try
{
    var host = await StartSilo();
    Console.WriteLine("\n\n Press Enter to terminate...\n\n");

    Console.ReadLine();
    await host.StopAsync();

    return 0;
}
catch (Exception e)
{
    Console.WriteLine(e);
    return 1;
}

static async Task<ISiloHost> StartSilo()
{
    // define the cluster configuration
    var builder = new SiloHostBuilder().UseLocalhostClustering().Configure<ClusterOptions>(
            options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "OrleansBasics";
            }).ConfigureApplicationParts(
            parts => parts.AddApplicationPart(typeof(HelloGrain).Assembly).WithReferences())
        .ConfigureLogging(logging => logging.AddConsole());

    var host = builder.Build();
    await host.StartAsync();
    return host;
}