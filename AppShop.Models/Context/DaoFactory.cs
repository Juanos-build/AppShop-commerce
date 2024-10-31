using AppShop.Models.Context.Interfaces;
using AppShop.Models.Context.Model;

namespace AppShop.Models.Context
{
    public abstract class DaoFactory
    {
        public static DaoFactory GetDaoFatory(DataContext dataContext)
        {
            AccessDao.DataBaseContext = dataContext;
            return new AccessDao();
        }

        #region Transactional Interfaces

        public abstract ITransactionDao GetTransactionDao();
        public abstract IProductDao GetProductDao();
        public abstract IOrderDao GetOrderDao();

        #endregion
    }
}
