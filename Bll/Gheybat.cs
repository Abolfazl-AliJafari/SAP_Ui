using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Gheybat
    {
        public static OperationResult Validation(Gheybat_Tbl gheybat)
        {
            if (string.IsNullOrEmpty(gheybat.GheybatDate))
                return new OperationResult
                {
                    Success = false,
                    Message = "تاریخ را وارد کنید"
                };
            else if(!(DataAccessLayer.Gheybat.CheckGheybatDateCode(gheybat.GheybatStudentCode,gheybat.GheybatDate).Success))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "غیبت برای این دانش آموز قبلا در این تاریخ ثبت شده است"
                };
            }
            else if (string.IsNullOrEmpty(gheybat.GheybatStudentName))
                return new OperationResult
                {
                    Success = false,
                    Message = "نام و نام خانوادگی را وارد کنید"
                };

            else if (string.IsNullOrEmpty(gheybat.GheybatMoredTypeTitle))
                return new OperationResult
                {
                    Success = false,
                    Message = "مورد را انتخاب کنید"
                };
            return new OperationResult
            {
                Success = true
            };
        }
        public static OperationResult<List<Gheybat_Tbl>> Select(string Search = "")
        { 
            var result = DataAccessLayer.Gheybat.Select(Search);
            if (result.Success == true)
            {
                return result;
            }

                return new OperationResult<List<Gheybat_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            
        }
        public static OperationResult Delete(string code, string tarikh)
        {
            var result = DataAccessLayer.Gheybat.Delete(code, tarikh);
            if (result.Success)
            {
                return new OperationResult
                {
                    Success = true,
                };
            }

            return new OperationResult
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };

        }
        public static OperationResult Insert(Gheybat_Tbl gheybat)
        {

            var validationGheybat = Validation(gheybat);
            if (validationGheybat.Success)
            {
                var result = DataAccessLayer.Gheybat.Insert(gheybat);
                if (result.Success)
                {
                    return new OperationResult
                    {
                        Success = true,
                    };
                }

                return new OperationResult
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };

            }
            return validationGheybat;
            
        }
        public static OperationResult Update(Gheybat_Tbl gheybat)
        {
            if (string.IsNullOrEmpty(gheybat.GheybatMoredTypeTitle))
                return new OperationResult
                {
                    Success = false,
                    Message = "تاریخ را وارد کنید"
                };
            else
            {
                var result = DataAccessLayer.Gheybat.Update( gheybat);
                if (result.Success == true)
                {
                    return new OperationResult
                    {
                        Success = true,
                    };
                }
                else
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                    };
                }
            }
        }
        public static OperationResult<List<Gheybat_Tbl>> SelectGheybatsStudent(string StudentCode)
        {
            var result = DataAccessLayer.Gheybat.SelectGheybatsStudent(StudentCode);
            if (!result.Success)
            {
                return new OperationResult<List<Gheybat_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
           return result;
        }
    }
}
