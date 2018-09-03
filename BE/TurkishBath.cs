using System;
using System.Collections.Generic;
namespace BE
{
    public class TurkishBath
    {
        public int Id { get; set; }
        public List<User> UsersEnqueued { get; set; }

        public TurkishBath(int id, List<User> usersEnqueued)
        {
            this.Id = id;
            this.UsersEnqueued = usersEnqueued;
        }
    }
}
