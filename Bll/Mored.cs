using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Mored
    {

        public static OperationResult ValidationMored(Mavared_Tbl mored,bool isedit)
        {

            if (string.IsNullOrEmpty(mored.MoredTitle))
                return new OperationResult
                {
                    Success = false,
                    Message = "عنوان مورد را وارد کنید"
                };
            else if (!isedit)
            {
                if (!(DataAccessLayer.Mored.CheckTitle(mored.MoredTitle).Success))
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "این مورد قبلا ثبت شده است"
                    };
                }
            }

            else if (!Validation.CheckStringFormat(mored.MoredTitle))
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت عنوان مورد را رعایت کنید"
                };
            if (string.IsNullOrEmpty(mored.MoredType))
                return new OperationResult
                {
                    Success = false,
                    Message = "نوع مورد را وارد کنید"
                };
            if (mored.MoredScore == 0)
                return new OperationResult
                {
                    Success = false,
                    Message = "نمره مورد را وارد کنید"
                };
            else if (!Validation.CheckScoreFormat(mored.MoredScore.ToString()))
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت نمره  را رعایت کنید"
                };
            return new OperationResult
            {
                Success = true
            };
        }

        public static OperationResult<List<Mavared_Tbl>> Select()
        {
            var mavared = DataAccessLayer.Mored.Select();
            if(!mavared.Success)
            {
                return new OperationResult<List<Mavared_Tbl>> 
                { 
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید." 
                };
            }
            return mavared;
        }  

        public static OperationResult Insert(Mavared_Tbl mored)
        {
            var validation = ValidationMored(mored,false);
            if(!validation.Success)
            {
                return validation;
            }
            var result = DataAccessLayer.Mored.Insert(mored);
            if(!result.Success)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return result;
        }
        public static OperationResult Update(Mavared_Tbl mored,double lastScore)
        {
            var validation = ValidationMored(mored,true);
            if (!validation.Success)
            {
                return validation;
            }
            var result = DataAccessLayer.Mored.Update(mored,lastScore);
            if (!result.Success)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return result;
        }
        
        public static OperationResult Delete (int Id)
        {
            var result = DataAccessLayer.Mored.Delete(Id);
            if(!result.Success)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return result;
        }

        public static OperationResult<List<string>> SelectTitles(string type)
        {
            var result = DataAccessLayer.Mored.SelectTitles(type);
            if(!result.Success)
            {
                return new OperationResult<List<string>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return result;
        }
    }

}
