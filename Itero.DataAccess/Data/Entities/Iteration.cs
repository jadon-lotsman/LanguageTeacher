using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itero.DataAccess.Data.Entities
{
    public class Iteration
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public List<IterationPart>? Questions { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }


        public Iteration() { }

        public Iteration(User user, List<IterationPart> questions)
        {
            Created = DateTime.UtcNow;
            
            User = user;
            Questions = questions;
        }
    }
}
