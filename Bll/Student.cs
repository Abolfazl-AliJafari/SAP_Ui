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
        public static bool CheckStringFormat(string str)
        {
            foreach(char chr in str)
            {
                if(byte.TryParse(chr.ToString(),out byte a))
                {
                    return false;
                }
            }
            return true;
        }
        
        public static OperationResult ValidationStudent (Student_Tbl student,bool isedit)
        {
            if (string.IsNullOrEmpty(student.StudentFirstName))
                return new OperationResult
                {
                    Success = false,
                    Message = "نام را وارد کنید"
                };
            
            if(!Validation.CheckStringFormat(student.StudentFirstName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت نام را رعایت کنید"
                };
            }
            if (string.IsNullOrEmpty(student.StudentLastName))
                return new OperationResult
                {
                    Success = false,
                    Message = "نام خانوادگی را وارد کنید"
                };
            if (!Validation.CheckStringFormat(student.StudentLastName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت نام خانوادگی را رعایت کنید"
                };
            }
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
            if (!isedit)
            {
                if (!DataAccessLayer.Student.CheckNationalCode(student.StudentNationalCode).Success)
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "کد ملی قبلا ثبت شده است"
                    };
                }
            }
            if(!Validation.CheckRangeFormat(student.StudentNationalCode, 10))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد ملی باید 10 رقم باشد"
                };
            }
            if(!Validation.CheckNumberFormat(student.StudentNationalCode))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت عددی کدملی را رعایت کنید"
                };
            }
            if (!Validation.CheckNumberFormat(student.StudentCode))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت عددی کد دانش آموزی را رعایت کنید"
                };
            }
            if (!isedit)
            {
                if (!DataAccessLayer.Student.CheckStudentCode(student.StudentCode).Success)
                {
                    return new OperationResult
                    {
                        Success = false,
                        Message = "کد دانش آموزی قبلا ثبت شده است"
                    };
                }
            }
            if (!Validation.CheckRangeFormat(student.StudentCode, 10))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "کد دانش آموزی باید 10 رقم باشد"
                };
            }
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
            if (!Validation.CheckStringFormat(student.StudentFatherName))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت نام پدر را رعایت کنید"
                };
            }
            if (string.IsNullOrEmpty(student.StudentFatherJob))
                return new OperationResult
                {
                    Success = false,
                    Message = "شغل پدر را وارد کنید"
                };
            if (!Validation.CheckStringFormat(student.StudentFatherJob))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت شغل پدر را رعایت کنید"
                };
            }
            if (string.IsNullOrEmpty(student.StudentFatherMobile))
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل پدر را وارد کنید"
                };

            if (!Validation.CheckRangeFormat(student.StudentFatherMobile,11))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل باید 11 رقم باشد"
                };
            }
            if (!Validation.CheckNumberFormat(student.StudentFatherMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت عددی شماره موبایل را رعایت کنید"
                };
            }
            if (string.IsNullOrEmpty(student.StudentMotherJob))
                return new OperationResult
                {
                    Success = false,
                    Message = "شغل مادر را وارد کنید"
                };
          
            if (!Validation.CheckStringFormat(student.StudentMotherJob))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت شغل مادر را رعایت کنید"
                };
            }
            if (string.IsNullOrEmpty(student.StudentMotherMobile))
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل مادر را وارد کنید"
                };
            if (!Validation.CheckRangeFormat(student.StudentMotherMobile,11))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره موبایل باید 11 رقم باشد"
                };
            }
            if (!Validation.CheckNumberFormat(student.StudentMotherMobile))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت عددی شماره موبایل را رعایت کنید"
                };
            }
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
            if (!Validation.CheckRangeFormat(student.StudentHomeNumber,8))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "شماره تلفن منزل باید 8 رقم باشد"
                };
            }
            if (!Validation.CheckNumberFormat(student.StudentHomeNumber))
            {
                return new OperationResult
                {
                    Success = false,
                    Message = "فرمت عددی شماره تلفن منزل را رعایت کنید"
                };
            }
            return new OperationResult
            {
                Success = true
            };
        }

        public static OperationResult Update ( string LastStudentCode,Student_Tbl student)
        {
            var validationResult = ValidationStudent(student,true);
            if (validationResult.Success)
            {
                 var result = DataAccessLayer.Student.Update(LastStudentCode, student);
                if (!result.Success)
                {
                    result.Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید.";
                }
                return result;
            }
            return validationResult;

        }

        public static OperationResult Insert(Student_Tbl student)
        {

            
            var validationResult = ValidationStudent(student,false);
            if (validationResult.Success)
            {

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
            return validationResult;


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
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
        }
        //public static OperationResult<List<Student_Tbl>> SelectFilter(string dahom, string yazdahom, string davazdahom)
        //{
        //    var query = DataAccessLayer.Student.SelectFilter(dahom, yazdahom, davazdahom);
        //    if (query.Success == true)
        //    {
        //        return query;
        //    }
        //    else
        //    {
        //        return new OperationResult<List<Student_Tbl>>
        //        {
        //            Success = false,
        //            Message = "خطایی رخ داده لطفا  تماس فرماید"
        //        };
        //    }


        //}
        public static OperationResult Delete(Student_Tbl student)
        {
            
            var result = DataAccessLayer.Student.Delete(student);
            if(result.Success == false)
            {
                result.Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید.";
                return result;
            }
            
            return result;
            
        }

        public static OperationResult DeleteStudents(List<Student_Tbl> students)
        {
            var result = DataAccessLayer.Student.DeleteStudents(students);
            if (result.Success == false)
            {
                result.Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید.";
                return result;
            }

            return result;
        }
        public static OperationResult<Student_Tbl> SelectStudent(string StudentCode)
        {
            var result = DataAccessLayer.Student.SelectStudent(StudentCode);
            if(result.Success)
            {
                return result;
            }
            else
            {
                return new OperationResult<Student_Tbl> { Success = false, Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید." };
            }
        }

        public static OperationResult<List<string>> GetstudentCode()
        {
            var studentsCode = DataAccessLayer.Student.GetstudentCode();
            if(!studentsCode.Success)
            {
                return new OperationResult<List<string>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return studentsCode;

        }
        public static OperationResult<List<string>> GetstudentName()
        {
            var studentsName = DataAccessLayer.Student.GetstudentName();
            if (!studentsName.Success)
            {
                return new OperationResult<List<string>>
                {
                    Success = false,
                    Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
                };
            }
            return studentsName;
        }
        public static OperationResult<double> SelectScore(string StudentCode)
        {
            var result = DataAccessLayer.Student.SelectScore(StudentCode);
            if(result.Success) 
            {
                return result;
            }
            return new OperationResult<double>
            {
                Success = false,
                Message = "خطایی رخ داد لطفا با پشتیبانی تماس بگیرید."
            };
        }


    }
}
