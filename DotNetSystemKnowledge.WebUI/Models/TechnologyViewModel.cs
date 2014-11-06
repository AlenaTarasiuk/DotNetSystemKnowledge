using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetSystemKnowledge.Domain.Entities;

namespace DotNetSystemKnowledge.WebUI.Models
{
    public class TechnologyViewModel
    {
        public IEnumerable<Technology> Technologys { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}