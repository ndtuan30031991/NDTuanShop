using System;

namespace NDTuanShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        NDTuanShopDbContext Init();
    }
}