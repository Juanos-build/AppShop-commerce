using AppShop.Models.Context.Access;
using AppShop.Models.Context.Interfaces;
using AppShop.Models.Context.Model;

namespace AppShop.Models.Context
{
    internal class AccessDao : DaoFactory
    {

        #region Static Access Members

        public static DataContext DataBaseContext { get; set; }

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
