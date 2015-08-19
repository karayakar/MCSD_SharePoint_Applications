using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRoleProvider
{
    class SampleUser
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<string> roles { get; set; }

    }

    //A helper static class with one publicly callable method, the one that gets the users collection
    public static class SampleUsers
    {
        public static List<SampleUser> users = new List<SampleUser>();
        static SampleUsers()
        {
            users = createSampleUsers(users);
        }

        public static List<SampleUser> GetSampleUsersCollection()
        {
            return users;
        }

        private static List<SampleUser> createSampleUsers()
        {
            SampleUser ross = new SampleUser()
            {
                name = "Ross Albertson",
                email = "r.albertson@diallonic.com",
                password = "s@mplePass"
            };
            users.Add(ross);
        }

    }
}
