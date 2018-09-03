using System;
using System.Collections.Generic;

namespace BE
{
    public class FinnishSauna
    {
        public int Id { get; set; }
        public List<User> UsersEnqueued { get; set; }

        public FinnishSauna(int id, List<User> usersEnqueued)
        {
            this.Id = id;
            this.UsersEnqueued = usersEnqueued;
        }
    }
}
