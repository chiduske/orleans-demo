using Microsoft.Extensions.Hosting;
using Orleans.Hosting;


using var host = new HostBuilder().UseOrleans(builder => builder.UseLocalhostClustering()).Build();

await host.StartAsync();
Console.WriteLine("\n\n Press Enter to terminate...\n\n");

Console.ReadLine();
await host.StopAsync();