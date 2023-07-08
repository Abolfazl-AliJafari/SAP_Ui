using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Tazakor
    {
        public static OperationResult ValidationTazakor(Tazakor_Tbl tazakor)
        {
            if (string.IsNullOrEmpty(tazakor.TazakorDate))
                return new OperationResult
                {
                    Success = false,
                    Message = "تاریخ را وارد کنید"
                };
            else if (string.IsNullOrEmpty(tazakor.TazakorStudentCode))
                return new OperationResult
                {
                    Success = false,
                    Message = "کد دانش آموزی را وارد کنید"
                };

            else if (!string.IsNullOrEmpty(tazakor.TazakorElat))
            {
                if (!Validation.CheckStringFormat(tazakor.TazakorElat))
                    return new OperationResult
                    {
                        Success = false,
                        Message = "فرمت علت تذکر را رعایت کنید"
                    };
            }
            else if (string.IsNullOrEmpty(tazakor.TazakorEghdamKonande))
                return new OperationResult
                {
                    Success = false,
                    Message = "اقدام کننده را وارد کنید"
                };
            else if (!Validation.CheckStringFormat(tazakor.TazakorEghdamKonande))
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت اقدام کننده را رعایت کنید"
                };
            else if (string.IsNullOrEmpty(tazakor.TazakorMoredTypeTitle))
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
        public static OperationResult<List<Tazakor_Tbl>> Select(string Search)
        {
            var result = DataAccessLayer.Tazakor.Select(Search);
            if (result.Success)
            {
                return result;
            }
            return new OperationResult<List<Tazakor_Tbl>>
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };
        }

        public static OperationResult Insert(Tazakor_Tbl tazakor)
        {
            var validation = ValidationTazakor(tazakor);
            if (!validation.Success)
            {
                return validation;
            }
            var result = DataAccessLayer.Tazakor.Insert(tazakor);
            if (result.Success)
            {
                return result;
            }
            return new OperationResult
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };
        }

        public static OperationResult Delete(int Id)
        {
            var result = DataAccessLayer.Tazakor.Delete(Id);
            if (result.Success)
            {
                return result;
            }
            return new OperationResult
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };
        }
        public static OperationResult Update(Tazakor_Tbl tazakor)
        {
            var validation = ValidationTazakor(tazakor);
            if (!validation.Success)
            {
                return validation;
            }

            var result = DataAccessLayer.Tazakor.Update(tazakor,0);
            if (result.Success)
            {
                return result;
            }
            return new OperationResult
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };

        }
        public static OperationResult<List<Tazakor_Tbl>> SelectTazakorsStudent(string StudentCode)
        {
            var result = DataAccessLayer.Tazakor.SelectTazakorsStudent(StudentCode);
            if (!result.Success)
            {
                return new OperationResult<List<Tazakor_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return result;
        }
    }
}
