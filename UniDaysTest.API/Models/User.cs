using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniDaysTest.API.Models
{
    public class User
    {
        public int UserId { get;  }
        public string Email { get;  }
        public string Password { get;  }
        public DateTime CreatedDate { get;  }
        public DateTime LastUpdateDate { get;  }

        public User (int userId, string email, string password, DateTime createdDate, DateTime lastUpdateDate)
        {
            UserId = userId;
            Email = email;
            Password = password;
            CreatedDate = createdDate;
            LastUpdateDate = lastUpdateDate;
        }

        public User (string email, string password)
        {
            Email = email;
            Password = password;
            CreatedDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
        }
    }

}