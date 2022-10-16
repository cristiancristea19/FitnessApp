using Application.Interfaces;
using Common;
using Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quotation.Domain.Entities.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance
{
    [MapServiceDependency(nameof(FitnessDbContext))]
    public class FitnessDbContext : IdentityDbContext<User>, IDbContext, IFitnessDbContext
    {
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public FitnessDbContext(DbContextOptions<FitnessDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FitnessDbContext).Assembly);
        }

        Task IDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        void IDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}