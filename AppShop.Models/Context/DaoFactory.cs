using AppShop.Models.Context.Interfaces;

namespace AppShop.Models.Context
{
    public abstract class DaoFactory
    {
        public static DaoFactory GetDaoFatory(string connection)
        {
            AccessDao.ConnectionString = connection;
            return new AccessDao();
        }

        #region Transactional Interfaces

        public abstract ITransactionDao GetTransactionDao();
        public abstract IProductDao GetProductDao();
        public abstract IOrderDao GetOrderDao();

        #endregion
    }
}
