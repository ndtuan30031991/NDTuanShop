namespace NDTuanShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NDTuanShopDbContext dbContext;

        public NDTuanShopDbContext Init()
        {
            return dbContext ?? (dbContext = new NDTuanShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}