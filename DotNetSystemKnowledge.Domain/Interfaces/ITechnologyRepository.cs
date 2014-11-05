using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetSystemKnowledge.Domain.Entities;

namespace DotNetSystemKnowledge.Domain.Interfaces
{
    public interface ITechnologyRepository
    {
        IQueryable<Technology> Technologys { get; }
     //   void CreateOrSaveTechnology(Technology technology);
     //   void DeleteTechnology(Technology technology);
    }


}
