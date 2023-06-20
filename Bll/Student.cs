using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Student
    {
        public static OperationResult<List<Student_Tbl>> Select(string search = "")
        {
            var query = DataAccessLayer.Student.Select(search);
            if (query.Success == true)
            {
                return query;
            }
            else
            {
                return new OperationResult<List<Student_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده لطفا با جعفر تماس فرماید"
                };
            }
        }
        public static OperationResult<List<Student_Tbl>> SelectFilter(string dahom, string yazdahom, string davazdahom)
        {
            var query = DataAccessLayer.Student.SelectFilter(dahom, yazdahom, davazdahom);
            if (query.Success == true)
            {
                return query;
            }
            else
            {
                return new OperationResult<List<Student_Tbl>>
                {
                    Success = false,
                    Message = "خطایی رخ داده لطفا با جعفر تماس فرماید"
                };
            }
            

        }
    }
}
