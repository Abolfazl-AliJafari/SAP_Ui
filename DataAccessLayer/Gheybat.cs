using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Gheybat
    {


        public static OperationResult<List<Gheybat_Tbl>> Select(string Search = "")
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var gheybat_ = dataContext.Gheybat_Tbls.Where(p => p.GheybatDate == Search).ToList();
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
        public static OperationResult<List<Gheybat_Tbl>> SelectByMoredTitle(string Title)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var gheybat_ = dataContext.Gheybat_Tbls.Where(p => p.GheybatMoredTypeTitle == Title).ToList();
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
            string gheybatTitle;
            string gheybatStudentCode = "";
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var gheybat_ = dataContext.Gheybat_Tbls.Where(p => p.GheybatStudentCode == code &&
                p.GheybatDate == tarikh).Single();
                gheybatStudentCode = gheybat_.GheybatStudentCode;
                gheybatTitle = gheybat_.GheybatMoredTypeTitle;
                dataContext.Gheybat_Tbls.DeleteOnSubmit(gheybat_);
                dataContext.SubmitChanges();
                var result = Mored.SelectScore(gheybatTitle);
                if (result.Success)
                {
                    var student = Student.SelectStudent(gheybatStudentCode);
                    if (student.Success)
                    {
                        student.Data.StudentScore += result.Data;
                        var update = Student.Update(student.Data.StudentCode, student.Data);
                        if (update.Success)
                        {
                            return new OperationResult
                            {
                                Success = true
                            };
                        }
                    }
                }
                return new OperationResult { Success = false };

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
                SAPDbDataContext dataContext = new SAPDbDataContext();
                dataContext.Gheybat_Tbls.InsertOnSubmit(gheybat);
                dataContext.SubmitChanges();
                var result = Mored.SelectScore(gheybat.GheybatMoredTypeTitle);
                if (result.Success)
                {
                    var student = Student.SelectStudent(gheybat.GheybatStudentCode);
                    if (student.Success)
                    {
                        student.Data.StudentScore -= result.Data;
                        var update = Student.Update(student.Data.StudentCode, student.Data);
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
        public static OperationResult Update(Gheybat_Tbl gheybat, double lastScore, bool updateMored = false)
        {
            string lastTitle;
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var lastGheybat = dataContext.Gheybat_Tbls.Where(p => p.GheybatStudentCode == gheybat.GheybatStudentCode &&
                p.GheybatDate == gheybat.GheybatDate).Single();
                lastTitle = lastGheybat.GheybatMoredTypeTitle;
                var result = Mored.SelectScore(lastTitle);
                var result2 = Mored.SelectScore(gheybat.GheybatMoredTypeTitle);
                lastGheybat.GheybatMoredTypeTitle = gheybat.GheybatMoredTypeTitle;

                dataContext.SubmitChanges();
                if (lastTitle != gheybat.GheybatMoredTypeTitle || result.Data != lastScore)
                {


                    if (result.Success && result2.Success)
                    {
                        if (updateMored)
                        {
                            var student = Student.SelectStudent(gheybat.GheybatStudentCode);
                            if (student.Success)
                            {
                                student.Data.StudentScore += lastScore;
                                student.Data.StudentScore -= result2.Data;

                                var update = Student.Update(student.Data.StudentCode, student.Data);
                                if (update.Success)
                                {
                                    return new OperationResult
                                    {
                                        Success = true
                                    };
                                }
                            }
                        }
                        else
                        {
                            var student = Student.SelectStudent(gheybat.GheybatStudentCode);
                            if (student.Success)
                            {
                                student.Data.StudentScore += result.Data;
                                student.Data.StudentScore -= result2.Data;

                                var update = Student.Update(student.Data.StudentCode, student.Data);
                                if (update.Success)
                                {
                                    return new OperationResult
                                    {
                                        Success = true
                                    };
                                }
                            }
                        }
                    }
                }
                else
                {
                    return new OperationResult
                    {
                        Success = true
                    };
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
                    Success = false

                };
            }

        }
        public static OperationResult<List<Gheybat_Tbl>> SelectGheybatsStudent(string StudentCode)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
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

        public static OperationResult CheckGheybatDateCode(string StudentCode, string Date)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var result = dataContext.Gheybat_Tbls.Where(x => x.GheybatStudentCode == StudentCode && x.GheybatDate == Date).ToList();
                if (result.Count != 0)
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
            catch(Exception)
            {
                return new OperationResult
                {
                    Success = false,
                };
            }
            
        }

        public static OperationResult MinusScore(Gheybat_Tbl gheybat,double score)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var student = Student.SelectStudent(gheybat.GheybatStudentCode);
                student.Data.StudentScore += score;
                var update = Student.Update(student.Data.StudentCode,student.Data);
                if(update.Success)
                {
                    return new OperationResult { Success = true };
                }
                else
                {
                    return new OperationResult { Success = false };
                }
            }
            catch(Exception)
            {
                return new OperationResult { Success = false };
            }
        }
    } 
}
