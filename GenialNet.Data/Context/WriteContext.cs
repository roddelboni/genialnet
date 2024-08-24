using Microsoft.EntityFrameworkCore;

namespace GenialNet.Data.Context
{
    public class WriteContext : GenialNetContext
    {
        public WriteContext(DbContextOptions<GenialNetContext> options) : base(options)
        {
        }
    }
}
