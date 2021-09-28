using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context
{
    public class IdentityMoverContext : IdentityDbContext<MoverUser, MoverRole, Guid>
    {
        public IdentityMoverContext(DbContextOptions<IdentityMoverContext> options) : base(options)
        {
        }
    }
}
