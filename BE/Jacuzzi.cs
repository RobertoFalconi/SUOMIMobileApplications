using System;
using System.Collections.Generic;

namespace BE
{
    public class Jacuzzi
    {
        public int Id { get; set; }
        public List<User> UsersEnqueued { get; set; }

        public Jacuzzi(int id, List<User> usersEnqueued)
        {
            this.Id = id;
            this.UsersEnqueued = usersEnqueued;
        }
    }
}
