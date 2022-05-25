using CentralInvestmentUploadProductDescription.Models;
using System;
using System.Data.SqlClient;
using System.Text.Json;

namespace CentralInvestmentUploadProductDescription
{
    public class DataAccess
    {
        public static ProductEnrichment GetProductEnrichment(string productId, string connectionString)
        {
            ProductEnrichment productEnrichment = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT [Id]
                              ,[ProductId]
                              ,[WebsiteId]
                              ,[CreatedDate]
                              ,[ModifiedDate]
                              ,[Url]
                              ,[Data]
                          FROM [ProductEnrichments]
                          WHERE ProductId = '"+productId+"'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productEnrichment = new ProductEnrichment();
                            productEnrichment.Id = reader.GetGuid(0);
                            productEnrichment.ProductId = reader.GetString(1);
                            productEnrichment.WebsiteId = reader.GetString(2);
                            productEnrichment.CreatedDate = reader.GetDateTime(3);
                            productEnrichment.Url = reader[5] as string;
                            productEnrichment.ProductEnrichmentData = JsonSerializer.Deserialize< ProductEnrichmentData>(reader.GetString(6));
                        }
                    }
                }
            }
            return productEnrichment;
        }

        public static void InsertProductEnrichment(ProductEnrichment productEnrichment, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"INSERT ProductEnrichments (Id, ProductId, WebsiteId, CreatedDate, ModifiedDate, Data) " +
                    $"VALUES ('{Guid.NewGuid()}', '{productEnrichment.ProductId}', 'SanaStore', '{DateTime.Now}', '{DateTime.Now}'," +
                    $" '{JsonSerializer.Serialize(productEnrichment.ProductEnrichmentData)}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }

        }

        public static void UpdateProductEnrichment(ProductEnrichment productEnrichment, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = $"UPDATE ProductEnrichments SET " +
                    $"ModifiedDate = '{DateTime.Now}', Data = '{JsonSerializer.Serialize(productEnrichment.ProductEnrichmentData)}'" +
                    $"WHERE Id = '{productEnrichment.Id}' ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
