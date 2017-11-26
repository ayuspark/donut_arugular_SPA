using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace donut_arugular_SPA.Models
{
    public class Make
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Model> Models { get; set; }
        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}