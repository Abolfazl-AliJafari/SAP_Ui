using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Gheybat
    {
        public static SAPDbDataContext dataContext = new SAPDbDataContext();

        public static OperationResult<List<Gheybat_Tbl>> Select(string Search = "")
        {
            try
            {
                var gheybat_ = dataContext.Gheybat_Tbls.Where(p => p.GheybatDate==Search).ToList();
                return new OperationResult<List<Gheybat_Tbl>>
                {
                    Success = true,
                    Data = gheybat_
                };
            }
            catch
            {
                return new OperationResult<List<Gheybat_Tbl>>
                {
                    Success = false
                };
            }
        }
        //public static OperationResult<string> SelectCode(string Search)
        //{
        //    try
        //    {
        //        SAPDbDataContext linq = new SAPDbDataContext();
        //        var query = linq.Student_Tbls.Where(p => p.StudentFirstName +""+ p.StudentLastName == Search)
        //            .Select(p => p.StudentCode).Single();
        //        return new OperationResult<string>
        //        {
        //            Success = true,
        //            Data = query
        //        };
        //    }
        //    catch
        //    {
        //        return new OperationResult<string>
        //        {
        //            Success = false
        //        };
        //    }
        //}
        public static OperationResult Delete(string code, string tarikh)
        {
            try
            {
                var gheybat_ = dataContext.Gheybat_Tbls.Where(p => p.GheybatStudentCode == code &&
                p.GheybatDate == tarikh).Single();
                dataContext.Gheybat_Tbls.DeleteOnSubmit(gheybat_);
                dataContext.SubmitChanges();
                return new OperationResult
                {
                    Success = true
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false
                };
            }
        }
        public static OperationResult Insert(Gheybat_Tbl gheybat)
        {
            try
            {

                dataContext.Gheybat_Tbls.InsertOnSubmit(gheybat);
                dataContext.SubmitChanges();
                var result = Mored.SelectScore(gheybat.GheybatMoredTypeTitle);
                if(result.Success)
                {
                    var student = Student.SelectStudent(gheybat.GheybatStudentCode);
                    if(student.Success)
                    {
                        student.Data.StudentScore -= result.Data; 
                        var update = Student.Update(student.Data.StudentCode,student.Data);
                        if (update.Success)
                        {
                            return new OperationResult
                            {
                                Success = true
                            };
                        }
                    }
                }
                return new OperationResult
                {
                    Success = false
                };
            }
            catch
            {
                return new OperationResult
                {
                    Success = false,
                };
            }

        }
            public static OperationResult Update( Gheybat_Tbl gheybat)
            {
                try
                {
                    var gheybat_ = dataContext.Gheybat_Tbls.Where(p => p.GheybatStudentCode == gheybat.GheybatStudentCode &&
                    p.GheybatDate == gheybat.GheybatDate).Single();
                    if (gheybat_ != null)
                    {
                     gheybat_.GheybatMoredTypeTitle = gheybat.GheybatMoredTypeTitle;
                    }
                dataContext.SubmitChanges();
                    return new OperationResult
                    {
                        Success = true
                    };
                }
                catch
                {
                    return new OperationResult
                    {
                        Success = false
                       
                    };
                }

            }
        public static OperationResult<List<Gheybat_Tbl>> SelectGheybatsStudent(string StudentCode)
        {
            try
            {
                var ghayebs = dataContext.Gheybat_Tbls.Where(gheybat => gheybat.GheybatStudentCode == StudentCode).ToList();
                return new OperationResult<List<Gheybat_Tbl>>
                {
                    Success = true,
                    Data = ghayebs
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<Gheybat_Tbl>>
                {
                    Success = false,
                };
            }
        }

        public static OperationResult CheckGheybatDateCode(string StudentCode,string Date)
        {
            var result = dataContext.Gheybat_Tbls.Where(x => x.GheybatStudentCode == StudentCode && x.GheybatDate == Date).ToList();
            if(result.Count!=0)
            {
                return new OperationResult
                {
                    Success = false
                };
            }
            return new OperationResult
            {
                Success = true
            };
        }

    }
}
