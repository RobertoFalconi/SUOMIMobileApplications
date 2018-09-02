using System;
using System.Collections.Generic;

namespace BE
{
    public class Kneipp
    {
        public List<User> UsersEnqueued { get; set; }

        public Kneipp(List<User> usersEnqueued)
        {
            this.UsersEnqueued = usersEnqueued;
        }
    }
}
