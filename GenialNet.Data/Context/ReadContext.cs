using Microsoft.EntityFrameworkCore;

namespace GenialNet.Data.Context
{
    public class ReadContext : GenialNetContext
    {
        public ReadContext(DbContextOptions<GenialNetContext> options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //ChangeTracker.LazyLoadingEnabled = false;
        }
    }
}
