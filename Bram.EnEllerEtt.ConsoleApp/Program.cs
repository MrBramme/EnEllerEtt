using Bram.EnEllerEtt.Boundary;
using Bram.EnEllerEtt.Core.Interface.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bram.EnEllerEtt.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = ConsoleConfigurator.Setup();

            var wordLookupService = serviceProvider.GetService<IWordLookupService>();

            await GetInput(wordLookupService);
        }

        private static async Task GetInput(IWordLookupService wordLookupService)
        {
            while (true)
            {
                Console.WriteLine("Insert word (exit to stop)");
                var word = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(word) || word.ToLower().Equals("exit"))
                {
                    break;
                }

                var result = await wordLookupService.GetResultForWordAsync(word, CancellationToken.None);
                Console.WriteLine($"{result.WordType} {result.SingleNominativObestämd}: {result.SingleNominativBestämd}, {result.PluralNominativObestämd}, {result.PluralNominativBestämd}");
                Console.WriteLine();
            }
        }
    }
}
