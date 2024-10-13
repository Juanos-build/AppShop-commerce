using AppShop.Models.Context.Access;
using AppShop.Models.Context.Interfaces;
using AppShop.Models.Context.Model;
using Microsoft.EntityFrameworkCore;

namespace AppShop.Models.Context
{
    internal class AccessDao : DaoFactory
    {

        #region Static Access Members

        public static string ConnectionString { get; set; }

        public static DbContextOptions<DataContext> OptionsBuilder
        {
            get
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(ConnectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .Options;
                return options;
            }
        }

        #endregion


        #region Transactional Interfaces

        public override ITransactionDao GetTransactionDao()
        {
            return new TransactionDao();
        }

        public override IProductDao GetProductDao()
        {
            return new ProductDao();
        }

        public override IOrderDao GetOrderDao()
        {
            return new OrderDao();
        }

        #endregion
    }
}
