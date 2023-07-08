using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Tashvigh
    {

        public static OperationResult ValidationTashvigh(Tashvigh_Tbl tashvigh)
        {
            if (string.IsNullOrEmpty(tashvigh.TashvighDate))
                return new OperationResult
                {
                    Success = false,
                    Message = "تاریخ را وارد کنید"
                };
            else if (string.IsNullOrEmpty(tashvigh.TashvighStudentCode))
                return new OperationResult
                {
                    Success = false,
                    Message = "کد دانش آموزی را وارد کنید"
                };
            else if (!string.IsNullOrEmpty(tashvigh.TashvighElat))
            {
            if (!Validation.CheckStringFormat(tashvigh.TashvighElat))
                    return new OperationResult
                    {
                        Success = false,
                        Message = "فرمت علت تشویق را رعایت کنید"
                    };
            }
            else if (string.IsNullOrEmpty(tashvigh.TashvighEghdamKonande))
                return new OperationResult
                {
                    Success = false,
                    Message = "اقدام کننده را وارد کنید"
                };
            else if (!Validation.CheckStringFormat(tashvigh.TashvighEghdamKonande))
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت اقدام کننده را رعایت کنید"
                };
            else if (string.IsNullOrEmpty(tashvigh.TashvighMoredTypeTitle))
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
        public static OperationResult<List<Tashvigh_Tbl>> Select(string Search)
        {
            var result = DataAccessLayer.Tashvigh.Select(Search);
            if(result.Success)
            {
                return result;
            }
            return new OperationResult<List<Tashvigh_Tbl>>
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };
        }

        public static OperationResult Insert(Tashvigh_Tbl tashvigh)
        {
            var validation = ValidationTashvigh(tashvigh);
            if(!validation.Success)
            {
                return validation;
            }
            var result = DataAccessLayer.Tashvigh.Insert(tashvigh);
            if(result.Success)
            {
                return result;
            }
            return new OperationResult
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };
        }

        public static OperationResult Delete (int Id)
        {
            var result = DataAccessLayer.Tashvigh.Delete(Id);
            if(result.Success )
            {
                return result;
            }
            return new OperationResult
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };
        }
        public static OperationResult Update(Tashvigh_Tbl tashvigh)
        {
            var validation = ValidationTashvigh(tashvigh);
            if(!validation.Success)
            {
                return validation;
            }
            var result = DataAccessLayer.Tashvigh.Update(tashvigh,0);
            if(result.Success)
            {
                return result;
            }
            return new OperationResult
            {
                Success = false, 
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید." 
            };
        }

        public static OperationResult<List<Tashvigh_Tbl>> SelectTashvighsStudent(string StudentCode)
        {
            var result = DataAccessLayer.Tashvigh.SelectTashvighsStudent(StudentCode);
            if (!result.Success)
            {
                return new OperationResult<List<Tashvigh_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return result;
        }

    }
}
