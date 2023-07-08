using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Bll
{
    public class User
    {

        public static OperationResult Login(string UserName, string PassWord)
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(PassWord) && UserName != "نام کاربری" && PassWord != "رمز عبور")
            {
                var result = DataAccessLayer.User.Login(UserName, PassWord);
                if(!result.Success)
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "رمز عبور یا نام کاربری اشتباه است."
                    };
                }
            }
            else
                return new OperationResult()
                {
                    Success = false,
                    Message = "پر کردن تمامی فیلد ها الزامی است ."
                };
            return new OperationResult
            {
                Success = true
            };
        }
    }
}
