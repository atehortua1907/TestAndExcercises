using CentralInvestmentUploadProductDescription;
using System;

namespace CentralInvestment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appsettings = Utils.GetAppSettings();
            var productEnrichment = Utils.GetProductEnrichmentFromFile(appsettings.PathFile, appsettings.DelimiterFile);
            Utils.UpdateProductEnrichments(productEnrichment, appsettings.ConnectionString);
        }
    }
}
