using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GetStudentCodeName
    {
        public static OperationResult operationResult { get; set; }
        public static List<string> StudentCodes { get; set; }
        public static List<string> StudentNames { get; set; }
    }
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

       public static OperationResult<List<string>> GetstudentCode()
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var students = dataContext.Student_Tbls.ToList();
                List<string> codes = new List<string>();
                foreach (Student_Tbl student in students)
                {
                    codes.Add(student.StudentCode);
                }
                return new OperationResult<List<string>>
                {
                    Success = true,
                    Data = codes
                };
            }
            catch(Exception)
            {
                return new OperationResult<List<string>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<string>> GetstudentName()
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var students = dataContext.Student_Tbls.ToList();
                List<string> names = new List<string>();
                foreach (Student_Tbl student in students)
                {
                    names.Add(student.StudentFirstName+" "+student.StudentLastName);
                }
                return new OperationResult<List<string>>
                {
                    Success = true,
                    Data = names
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<string>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult<List<Student_Tbl>> Select(string search)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var query = dataContext.Student_Tbls.Where(p =>
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
       
        public static OperationResult<Student_Tbl> SelectStudent(string StudentCode)
        {
            try
            {
                SAPDbDataContext sql = new SAPDbDataContext();
                var query = sql.Student_Tbls.Where(p => p.StudentCode == StudentCode).First();
                return new OperationResult <Student_Tbl>
                {
                    Success = true,
                    Data = query
                };
            }
            catch (Exception)
            {
                return new OperationResult <Student_Tbl>
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
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var student = dataContext.Student_Tbls.Where(x => x.StudentCode == LastStudentCode).Single();
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
                dataContext.SubmitChanges();
                return new OperationResult { Success = true };

            }
            catch(Exception)
            {
                return new OperationResult { Success = false };

            }
        }
        
        public static OperationResult<double> ScoreCalculat(string StudentCode)
        {
            SAPDbDataContext dataContext= new SAPDbDataContext();
            try
            {
                var gheybats = dataContext.Gheybat_Tbls.Where(x => x.GheybatStudentCode == StudentCode).ToList();
                var takhirs = dataContext.Takhir_Tbls.Where(x => x.TakhirStudentCode == StudentCode).ToList();
                var tashvighs = dataContext.Tashvigh_Tbls.Where(x => x.TashvighStudentCode == StudentCode).ToList();
                var tazakors = dataContext.Tazakor_Tbls.Where(x => x.TazakorStudentCode == StudentCode).ToList();
                var mavared = dataContext.Mavared_Tbls.ToList();
                List<string> mavaredStudent = new List<string>();
                List<double> scorePlusStudent = new List<double>();
                List<double> scoreNegativeStudent = new List<double>();
                foreach (Gheybat_Tbl gheybat in gheybats)
                {
                    mavaredStudent.Add(gheybat.GheybatMoredTypeTitle);
                }

                foreach (Takhir_Tbl takhir in takhirs)
                {
                    mavaredStudent.Add(takhir.TakhirMoredTypeTitle);
                }

                foreach (Tashvigh_Tbl tashvigh in tashvighs)
                {
                    mavaredStudent.Add(tashvigh.TashvighMoredTypeTitle);
                }

                foreach (Tazakor_Tbl tazakor in tazakors)
                {
                    mavaredStudent.Add(tazakor.TazakorMoredTypeTitle);
                }


                foreach (string title in mavaredStudent)
                {   
                    var mored = dataContext.Mavared_Tbls.Where(x => x.MoredTitle==title).Single();
                    if(mored.MoredType == "تشویق")
                    {
                        scorePlusStudent.Add(mored.MoredScore);
                    }
                    else
                    {
                        scoreNegativeStudent.Add(mored.MoredScore);
                    }
                }
                double negativeScore = 0;
                double plusScore = 0;
                foreach (double score in scoreNegativeStudent)
                {
                    negativeScore += score;
                }
                foreach (double score in scorePlusStudent)
                {
                    plusScore += score;
                }

                double FinalScore = (double)((20+plusScore)-negativeScore);
                return new OperationResult<double>
                {
                    Success = true,
                    Data = FinalScore
                };
            }
            catch(Exception ex)
            {
                return new OperationResult<double>
                {
                    Success = false,
                };
            }
        }
        public static OperationResult CheckStudentCode(string StudentCode)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            var result = dataContext.Student_Tbls.Where(x => x.StudentCode == StudentCode).Single();
            if (result != null)
            {
                return new OperationResult
                {
                    Success = false
                };
            }
            return new OperationResult
            {
                Success = true,
            };
        }

        public static OperationResult CheckNationalCode(string NationalCode)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            var result = dataContext.Student_Tbls.Where(x => x.StudentNationalCode == NationalCode).Single();
            if (result != null)
            {
                return new OperationResult
                {
                    Success = false
                };
            }
            return new OperationResult
            {
                Success = true,
            };
        }
    }
}
