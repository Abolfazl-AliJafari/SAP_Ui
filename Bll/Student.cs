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
        public static OperationResult Insert(Student_Tbl student)
        {

            if (string.IsNullOrEmpty(student.StudentFirstName))
                return new OperationResult
                {
                    Success = false,
                    Message = "نام را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentLastName))
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentPayeh))
                return new OperationResult
                {
                    Success = false,
                    Message = "پایه را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentReshteh))
                return new OperationResult
                {
                    Success = false,
                    Message = "رشته را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentNationalCode))
                return new OperationResult
                {
                    Success = false,
                    Message = "کد ملی را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentCode))
                return new OperationResult
                {
                    Success = false,
                    Message = "کد دانش آموزی را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentProfile))
                return new OperationResult
                {
                    Success = false,
                    Message = "پروفایل را آپلود کنید"
                };


            if (string.IsNullOrEmpty(student.StudentFatherName))
                return new OperationResult
                {
                    Success = false,
                    Message = "نام پدر را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentFatherJob))
                return new OperationResult
                {
                    Success = false,
                    Message = "شغل پدر را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentFatherMobile))
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل پدر را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentMotherJob))
                return new OperationResult
                {
                    Success = false,
                    Message = "شغل مادر را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentMotherMobile))
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل مادر را وارد کنید"
                };

            if (string.IsNullOrEmpty(student.StudentHomeAddress))
                return new OperationResult
                {
                    Success = false,
                    Message = "آدرس را وارد کنید"
                };
            if (string.IsNullOrEmpty(student.StudentHomeNumber))
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن خانه را وارد کنید"
                };

            if (string.IsNullOrEmpty(student.StudentFirstName))
                return new OperationResult
                {
                    Success = false,
                    Message = "نام را وارد کنید"
                };

            try
            {
                var result = DataAccessLayer.Student.Insert(student);
                return result;
            }
            catch (Exception)
            {
                return new OperationResult()
                {
                    Success = false,
                    Message = "مشکلی رخ داد"
                };
            }

        }
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
