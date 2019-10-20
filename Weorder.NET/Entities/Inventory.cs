using System;
using System.Collections.Generic;
using System.Text;

namespace Weorder.NET.Entities
{
    public class Inventory
    {
        public int externalId { get; set; }
        public Article[] articles { get; set; }
        public Category[] categories { get; set; }
        public Modifiergroup[] modifierGroups { get; set; }
        public Modifier[] modifiers { get; set; }

    }
}
