﻿using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using System;
using System.Threading.Tasks;

namespace LanguageClientAsync
{
    class Program
    {
        static async Task MainAsync()
        {
            var apiKey = "YOUR-TEXT-ANALYTICS-API-SUBSCRIPTION-KEY";

            var document = new Document()
            {
                Id = "YOUR-UNIQUE-ID",
                Text = "YOUR-TEXT"
            };

            var client = new LanguageClient(apiKey);

            var request = new LanguageRequest();
            request.Documents.Add(document);

            try
            {
                var response = await client.GetLanguagesAsync(request);

                foreach (var doc in response.Documents)
                {
                    Console.WriteLine("Document Id: {0}", doc.Id);

                    foreach (var lang in doc.DetectedLanguages)
                    {
                        Console.WriteLine("--Language: {0}({1})", lang.Name, lang.Iso639Name);
                        Console.WriteLine("--Confidence: {0}%", (lang.Score * 100));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
    }
}
