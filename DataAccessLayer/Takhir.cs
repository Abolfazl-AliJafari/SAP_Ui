using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Takhir
    {
        public static OperationResult<List<Takhir_Tbl>> Select(string Search = "")
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var query = dataContext.Takhir_Tbls.Where(p => p.TakhirDate==Search).ToList();
                return new OperationResult<List<Takhir_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Takhir_Tbl>>
                {
                    Success = false
                };
            }
        }

        public static OperationResult<List<Takhir_Tbl>> SelectByMoredTitle(string Title)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var query = dataContext.Takhir_Tbls.Where(p => p.TakhirMoredTypeTitle == Title).ToList();
                return new OperationResult<List<Takhir_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Takhir_Tbl>>
                {
                    Success = false
                };
            }
        }
        public static OperationResult Delete(string code, string tarikh)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var takhir = dataContext.Takhir_Tbls.Where(p => p.TakhirStudentCode == code &&
                p.TakhirDate == tarikh).Single();
                dataContext.Takhir_Tbls.DeleteOnSubmit(takhir);
                dataContext.SubmitChanges();
                var result = Mored.SelectScore(takhir.TakhirMoredTypeTitle);
                if (result.Success)
                {
                    var student = Student.SelectStudent(takhir.TakhirStudentCode);
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
        public static OperationResult Insert(Takhir_Tbl takhir)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                dataContext.Takhir_Tbls.InsertOnSubmit(takhir);
                dataContext.SubmitChanges();
                var result = Mored.SelectScore(takhir.TakhirMoredTypeTitle);
                if (result.Success)
                {
                    var student = Student.SelectStudent(takhir.TakhirStudentCode);
                    if (student.Success)
                    {
                        student.Data.StudentScore -= result.Data;
                        var update = Student.Update(student.Data.StudentCode, student.Data);
                        if(update.Success)
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
                    Success = false
                };
            }

        }
        public static OperationResult Update(Takhir_Tbl takhir, double lastScore, bool updateMored = false)
        {
            string lastTitle;
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var lastTakhir = dataContext.Takhir_Tbls.Where(p => p.TakhirStudentCode == takhir.TakhirStudentCode &&
                p.TakhirDate == takhir.TakhirDate).Single();
                lastTitle = lastTakhir.TakhirMoredTypeTitle;
                var result = Mored.SelectScore(lastTitle);
                var result2 = Mored.SelectScore(takhir.TakhirMoredTypeTitle);
               
                if (lastTakhir != null)
                {
                    lastTakhir.TakhirMoredTypeTitle = takhir.TakhirMoredTypeTitle;
                }
                dataContext.SubmitChanges();
                if (lastTitle != takhir.TakhirMoredTypeTitle || result.Data != lastScore)
                {
                   

                    if (result.Success && result2.Success)
                    {
                        if(updateMored)
                        {
                            var student = Student.SelectStudent(takhir.TakhirStudentCode);
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
                            var student = Student.SelectStudent(takhir.TakhirStudentCode);
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
        public static OperationResult<List<Takhir_Tbl>> SelectTakhirsStudent(string StudentCode)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var takirs = dataContext.Takhir_Tbls.Where(takir => takir.TakhirStudentCode == StudentCode).ToList();
                return new OperationResult<List<Takhir_Tbl>>
                {
                    Success = true,
                    Data = takirs
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<Takhir_Tbl>>
                {
                    Success = false,
                };
            }
        }
        public static OperationResult CheckGheybatDateCode(string StudentCode, string Date)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var result = dataContext.Takhir_Tbls.Where(x => x.TakhirStudentCode == StudentCode && x.TakhirDate == Date).ToList();
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
        public static OperationResult MinusScore(Takhir_Tbl takhir, double score)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var student = Student.SelectStudent(takhir.TakhirStudentCode);
                student.Data.StudentScore += score;
                var update = Student.Update(student.Data.StudentCode, student.Data);
                if (update.Success)
                {
                    return new OperationResult { Success = true };
                }
                else
                {
                    return new OperationResult { Success = false };
                }
            }
            catch (Exception)
            {
                return new OperationResult { Success = false };
            }
        }
    }

}
