using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class User
    {
        public static OperationResult Login(string UserName, string PassWord)
         {
            using (var dataContext = new SAPDbDataContext())
            {
                var user = dataContext.User_Tbls.FirstOrDefault(User => User.UserName == UserName);

                if (user != null && user.PassWord == PassWord)
                {
                    return new OperationResult()
                    {
                        Success = true
                    };
                }
                else
                {
                    return new OperationResult()
                    {
                        Success = false
                    };
                }
            }
        }
    }
}
