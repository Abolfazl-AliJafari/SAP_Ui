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
        public static OperationResult Insert(Student_Tbl student)
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
            catch (Exception)
            {
                return new OperationResult()
                {
                    Success = false,
                    Message = "ثبت نام موفقیت آمیز نبود"
                };
            }
        }
        public static OperationResult<List<Student_Tbl>> Select(string search)
        {
            try
            {
                SAPDbDataContext sql = new SAPDbDataContext();
                var query = sql.Student_Tbls.Where(p =>
                p.StudentFirstName.Contains(search)
                || p.StudentLastName.Contains(search)).ToList();
                return new OperationResult<List<Student_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<Student_Tbl>>
                {
                    Success = false
                };
            }

        }

        public static OperationResult<List<Student_Tbl>> SelectFilter(string dahom, string yazdahom, string davazdahom)
        {
            try
            {
                SAPDbDataContext sql = new SAPDbDataContext();
                var query = sql.Student_Tbls.Where(p =>
                p.StudentPayeh == dahom ||
                p.StudentPayeh == yazdahom ||
                p.StudentPayeh == davazdahom).ToList();
                return new OperationResult<List<Student_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<Student_Tbl>>
                {
                    Success = false
                };
            }

        }
    }
}
