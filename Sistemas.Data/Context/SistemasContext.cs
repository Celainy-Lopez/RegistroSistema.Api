using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistemas.Data.Models;
namespace Sistemas.Data.Context;

public class SistemasContext : DbContext
{
    public SistemasContext(DbContextOptions<SistemasContext> options) : base(options) { }
    public DbSet<Sistema> Sistemas { get; set; }
}