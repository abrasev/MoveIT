using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context
{
    public class MoveItContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MoveItContext(DbContextOptions<MoveItContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //DbSets
        public DbSet<MoveProposal> MoveProposals { get; set; }




        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is MoveProposal && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var item in entries)
            {
                if (item.State == EntityState.Added)
                {
                    ((MoveProposal)item.Entity).CreatedBy = this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "MyApp";
                }
            }
            return base.SaveChanges();
        }


    }
}
