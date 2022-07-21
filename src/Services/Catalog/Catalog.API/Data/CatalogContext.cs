using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        #region Properties
        public IMongoCollection<Product> Products { get; private set; }
        #endregion

        #region Constructor
        public CatalogContext(IOptions<DatabaseSettings> databaseSettings)
        {
            Initialize(databaseSettings.Value);
        }

        #endregion

        #region Methods
        private void Initialize(DatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            Products = database.GetCollection<Product>(databaseSettings.CollectionName);

            CatalogContextSeed.SeedData(Products);
        }
        #endregion

    }
}
