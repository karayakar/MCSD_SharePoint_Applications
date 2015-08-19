using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;





namespace CustomRoleProvider
{
    public class mProvide : MembershipProvider
    {
        //The name we will use to refer to it during configuration later.
        public override string Name
        {
            get
            {
                return "MembershipProviderForYou";
            }
        }
        //Get our fake users here...
        private List<SampleUser> userCollection = SampleUsers.GetSampleUsersCollection();

        #region Required Overrides - Custom Logic Based on Your Data Store you want it to be...

        //providerUserKey is whatever
 
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var retrivedUsers = (from u in userCollection where u.email == emailToMatch select u);
            MembershipUserCollection users = null;
            foreach(var user in retrivedUsers)
            {
                users.Add(new MembershipUser(typeof(mProvide).FullName, user.name, null, user.email, null,
                    true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now));
            }
            //Make sure to assign the OUT parameter before you return..
            totalRecords = users.Count;
            return users;

           // throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var retrievedUsers = (from u in userCollection where u.name == usernameToMatch select u);
            MembershipUserCollection users = null;
            foreach(var user in retrievedUsers)
            {
                users.Add(new MembershipUser(typeof(mProvide).FullName, user.name, null, user.email,
                   null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now));
            }
            //Make sure to assign to the OUT parameter before you return
            totalRecords = users.Count;
            return users;
            //throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection allUsers = null;
            foreach(SampleUser oneUser in userCollection)
            {
                allUsers.Add(new MembershipUser(typeof(mProvide).FullName, oneUser.email, null, oneUser.email, null, null, true, false,
                        DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now));
            }
            totalRecords = allUsers.Count;
            return allUsers;
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var retrievedUser = (from u in userCollection where u.name == username select u).First();
            MembershipUser tempUser = new MembershipUser(typeof(mProvide).FullName).FullName,retrievedUser.name,
            null,retrievedUser.email, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now,
            DateTime.Now, DateTime.Now);
            return tempUser;
           // throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException("Not Implemented for this provider. Call GetUser(string.bool) instead");
           
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
   
}
