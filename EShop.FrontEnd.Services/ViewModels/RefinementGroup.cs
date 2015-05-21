using System.Collections.Generic;

namespace EShop.FrontEnd.Services.ViewModels
{
    public class RefinementGroup
    {
        public string Name { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<Refinement> Refinements { get; set; }
    }
}
