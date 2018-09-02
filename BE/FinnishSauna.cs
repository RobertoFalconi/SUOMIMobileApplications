using System;
using System.Collections.Generic;

namespace BE
{
    public class FinnishSauna
    {
        public List<User> UsersEnqueued { get; set; }

        public FinnishSauna(List<User> usersEnqueued)
        {
            this.UsersEnqueued = usersEnqueued;
        }
    }
}
