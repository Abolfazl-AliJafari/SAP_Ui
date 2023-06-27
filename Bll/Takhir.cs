using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Takhir
    {
        public static OperationResult Validation(Takhir_Tbl takhir)
        {
            if (string.IsNullOrEmpty(takhir.TakhirDate))
                return new OperationResult
                {
                    Success = false,
                    Message = "تاریخ را وارد کنید"
                };
            else if (string.IsNullOrEmpty(takhir.TakhirStudentName))
                return new OperationResult
                {
                    Success = false,
                    Message = "نام و نام خانوادگی را وارد کنید"
                };
            else if (string.IsNullOrEmpty(takhir.TakhirMoredTypeTitle))
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
        public static OperationResult<List<Takhir_Tbl>> Select(string Search = "")
        {
            var result = DataAccessLayer.Takhir.Select(Search);
            if (result.Success == true)
            {
                return result;
            }
            else
            {
                return new OperationResult<List<Takhir_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
        }
        public static OperationResult Delete(string code, string tarikh)
        {
            var result = DataAccessLayer.Takhir.Delete(code, tarikh);
            if (result.Success)
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
        public static OperationResult Insert(Takhir_Tbl takhir)
        {
            var validationResult = Validation(takhir);
           if (!validationResult.Success)
            {
                return validationResult;
            }
            else
            {
                var result = DataAccessLayer.Takhir.Insert(takhir);
                if (result.Success == true)
                {
                    return new OperationResult
                    {
                        Success = true,
                        Message = "ثبت شد"
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
        public static OperationResult Update(Takhir_Tbl takhir)
        {
            if (string.IsNullOrEmpty(takhir.TakhirMoredTypeTitle))
                return new OperationResult
                {
                    Success = false,
                    Message = "مورد را وارد کنید"
                };
            else
            {
                var result = DataAccessLayer.Takhir.Update(takhir);
                if (result.Success == true)
                {
                    return new OperationResult
                    {
                        Success = true,
                        Message = "ثبت شد"
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
        public static OperationResult<List<Takhir_Tbl>> SelectTakhirsStudent(string StudentCode)
        {
            var result = DataAccessLayer.Takhir.SelectTakhirsStudent(StudentCode);
            if (!result.Success)
            {
                return new OperationResult<List<Takhir_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return result;
        }
    }
}
