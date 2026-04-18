using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itereta.Data.Entities
{
    public class Iteration
    {
        public int Id { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime LastActionAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public bool IsFinished => FinishedAt.HasValue;
        public TimeSpan AverageActionTime
        {
            get
            {
                if (FinishedAt.HasValue)
                {
                    return (FinishedAt - StartedAt).Value / Iterettes.Count;
                }
                else
                {
                    return (DateTime.UtcNow - StartedAt) / Iterettes.Count;
                }
            }
        }

        public int UserId { get; set; }
        public User User { get; set; }
        public List<Iterette> Iterettes { get; set; }


        public Iteration() { }

        public Iteration(User user, List<Iterette> iterettes)
        {
            StartedAt = DateTime.UtcNow;
            LastActionAt = StartedAt;
            FinishedAt = null;

            User = user;
            Iterettes = iterettes;
        }
    }
}
