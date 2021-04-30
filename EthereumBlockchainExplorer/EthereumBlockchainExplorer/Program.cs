using Nethereum.Web3;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EthereumBlockchainExplorer.Services;

namespace EthereumBlockchainExplorer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Add services to DI container
            builder.Services.AddSingleton<IWeb3>(ctx => new Web3("https://mainnet.infura.io/v3/a4b328baa17740c0a4f3c10c163347fc"));
            builder.Services.AddSingleton<IEthereumService, EthereumService>();

            await builder.Build().RunAsync();
        }
    }
}
