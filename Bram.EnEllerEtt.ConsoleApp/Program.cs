﻿using Bram.EnEllerEtt.Boundary;
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
            ShowIntro();

            var serviceProvider = ConsoleConfigurator.Setup();
            var wordLookupService = serviceProvider.GetService<IWordLookupService>();

            await GetInput(wordLookupService);
        }

        private static void ShowIntro()
        {
            var asciiText =
                "\r\n    ______         __________             ________  __ \r\n   / ____/___     / ____/ / /__  _____   / ____/ /_/ /_\r\n  / __/ / __ \\   / __/ / / / _ \\/ ___/  / __/ / __/ __/\r\n / /___/ / / /  / /___/ / /  __/ /     / /___/ /_/ /_  \r\n/_____/_/ /_/  /_____/_/_/\\___/_/     /_____/\\__/\\__/  \r\n                                                       \r\n";
            Console.WriteLine(asciiText);
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
