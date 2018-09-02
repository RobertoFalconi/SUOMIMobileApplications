using System;
using System.Collections.Generic;

namespace BE
{
    public class Jacuzzi
    {
        public List<User> UsersEnqueued { get; set; }

        public Jacuzzi(List<User> usersEnqueued)
        {
            this.UsersEnqueued = usersEnqueued;
        }
    }
}
