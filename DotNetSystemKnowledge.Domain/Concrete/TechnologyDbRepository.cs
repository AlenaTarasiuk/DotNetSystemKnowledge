using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetSystemKnowledge.Domain.Interfaces;
using DotNetSystemKnowledge.Domain.Entities;

namespace DotNetSystemKnowledge.Domain.Concrete
{
    public class TechnologyDbRipository : ITechnologyRepository
    {
        private TechnologyDb context = new TechnologyDb();
        public IQueryable<Technology> Technologys
        {
            get { return context.Technologys; }
        }

    }
}
