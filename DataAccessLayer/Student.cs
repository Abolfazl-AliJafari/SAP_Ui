using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Student
    {
        public static OperationResult Insert (Student_Tbl student)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                dataContext.Student_Tbls.InsertOnSubmit(student);
                dataContext.SubmitChanges();
                return new OperationResult()
                {
                    Success = true,
                    Message = "ثبت نام با موفقیت انجام شد"
                };
            }
            catch(Exception)
            {
                return new OperationResult()
                {
                    Success = false,
                    Message = "ثبت نام موفقیت آمیز نبود"
                };
            }
        }
            
    }
}
