using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetSystemKnowledge.Domain.Entities;
using System.Data.Entity;

namespace DotNetSystemKnowledge.Domain.Concrete
{
    class TechnologyDb : DbContext
    {
        public DbSet<Technology> Technologys { get; set; }
    }
}
