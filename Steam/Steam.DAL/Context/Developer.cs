using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Context
{
    public class Developer
    {
        public Developer()
        {
            Games = new HashSet<Game>();
        }

        [Key]
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
