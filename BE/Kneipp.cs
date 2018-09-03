using System;
using System.Collections.Generic;

namespace BE
{
    public class Kneipp
    {
        public int Id { get; set; }
        public List<User> UsersEnqueued { get; set; }

        public Kneipp(int id, List<User> usersEnqueued)
        {
            this.Id = id;
            this.UsersEnqueued = usersEnqueued;
        }
    }
}
