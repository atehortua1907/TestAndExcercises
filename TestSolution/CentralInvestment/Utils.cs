using CentralInvestmentUploadProductDescription.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CentralInvestmentUploadProductDescription
{
    public class Utils
    {
        public static Appsettings GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            return config.GetSection("Appsettings").Get<Appsettings>();
        }

        public static List<ProductEnrichment> GetProductEnrichmentFromFile(string pathFile, char delimiter)
        {
            List<ProductEnrichment> productEnrichments = new List<ProductEnrichment>();

            var file = File
              .ReadLines(pathFile, Encoding.UTF8)
              .Skip(1)
              .Where(line => !string.IsNullOrEmpty(line))
              .Select(line => line.Split(delimiter));

            file.ToList().ForEach(line => 
            {
                productEnrichments.Add(
                        new ProductEnrichment 
                            { 
                                ProductId = line[0],
                                ProductEnrichmentData = new ProductEnrichmentData
                                            {
                                                Description = line[1].Replace("|", ",")
                                                .Replace("\"", "")
                                                .Replace("'","")
                                            }
                            });
            });

            Console.WriteLine($"{productEnrichments.Count} records retrieved from file");
            return productEnrichments;
        }

        public static void UpdateProductEnrichments(List<ProductEnrichment> productEnrichments, string connectionString)
        {
            try
            {
                Console.WriteLine("Start data saving...");
                productEnrichments.ForEach(prodEnrich =>
                {
                    var productEnrichmenet = DataAccess.GetProductEnrichment(prodEnrich.ProductId, connectionString);
                    if(productEnrichmenet == null)
                    { 
                        DataAccess.InsertProductEnrichment(prodEnrich, connectionString);
                        Console.WriteLine($"New product => {prodEnrich.ProductId}");
                    }
                    else
                        DataAccess.UpdateProductEnrichment(productEnrichmenet, connectionString);
                });
                Console.WriteLine("Finished data saving!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
