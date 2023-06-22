using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security;
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

        public static OperationResult<List<Student_Tbl>> SelectFilter(string dahom, string yazdahom, string davazdahom
              , string hesabdari, string shabake)
        {
            try
            {
                SAPDbDataContext sql = new SAPDbDataContext();
                var query = sql.Student_Tbls.Where(p =>
                p.StudentPayeh == dahom||
                p.StudentPayeh == yazdahom||
                p.StudentPayeh == davazdahom||
                p.StudentReshteh == hesabdari||
                p.StudentReshteh == shabake).ToList();
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
        public static OperationResult Delete(Student_Tbl student)
        {
            SAPDbDataContext sql = new SAPDbDataContext();

            try
            {
                var student_ = sql.Student_Tbls.Single(user => user.StudentCode == student.StudentCode);
                sql.Student_Tbls.DeleteOnSubmit(student_);
                //for (int i = 0; i < code.Count; i++)
                //{
                //    var query = sql.Student_Tbls.Where(p => p.StudentCode == code[i]).Single();
                //    sql.Student_Tbls.DeleteOnSubmit(query);
                //}
                sql.SubmitChanges();
                return new OperationResult
                {
                    Success = true,
                    
                };
            }
            catch(Exception ec)
            {
                return new OperationResult
                {
                    Message= ec.ToString(),
                    Success = false
                };
            }
        }
        public static OperationResult DeleteStudents(List<Student_Tbl> students)
        {
            SAPDbDataContext sql = new SAPDbDataContext();

            List<Student_Tbl> students_ = new List<Student_Tbl>();
            try
            {
                foreach (Student_Tbl student in students)
                {
                   students_.Add(sql.Student_Tbls.Single(user => user.StudentCode == student.StudentCode));
                }
                sql.Student_Tbls.DeleteAllOnSubmit(students_);
                sql.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch(Exception)
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }

        public static OperationResult Update(string LastStudentCode,Student_Tbl Student)
        {
            SAPDbDataContext sql = new SAPDbDataContext();
            try
            {
                var student = sql.Student_Tbls.Where(x => x.StudentCode == LastStudentCode).Single();
                student.StudentFirstName = Student.StudentFirstName;
                student.StudentLastName = Student.StudentLastName;
                student.StudentPayeh = Student.StudentPayeh;
                student.StudentReshteh = Student.StudentReshteh;
                student.StudentNationalCode = Student.StudentNationalCode;
                student.StudentCode = Student.StudentCode;
                student.StudentProfile = Student.StudentProfile;
                student.StudentBimaryKhas = Student.StudentBimaryKhas;
                student.StudentFatherName = Student.StudentFatherName;
                student.StudentFatherJob = Student.StudentFatherJob;
                student.StudentFatherMobile = Student.StudentFatherMobile;
                student.StudentMotherJob = Student.StudentMotherJob;
                student.StudentMotherMobile = Student.StudentMotherMobile;
                student.StudentLeftParent = Student.StudentLeftParent;
                student.StudentDeadParent = Student.StudentDeadParent;
                student.StudentParentBimary = Student.StudentParentBimary;
                student.StudentHomeAddress = Student.StudentHomeAddress;
                student.StudentHomeNumber = Student.StudentHomeNumber;
                student.StudentOther = Student.StudentOther;
                sql.SubmitChanges();
                return new OperationResult { Success = true };

            }
            catch(Exception)
            {
                return new OperationResult { Success = false };

            }
        }
        
    }
}
