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
