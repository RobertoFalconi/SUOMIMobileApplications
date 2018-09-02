using System;
using System.Collections.Generic;
namespace BE
{
    public class TurkishBath
    {
        public List<User> UsersEnqueued { get; set; }

        public TurkishBath(List<User> usersEnqueued)
        {
            this.UsersEnqueued = usersEnqueued;
        }
    }
}
