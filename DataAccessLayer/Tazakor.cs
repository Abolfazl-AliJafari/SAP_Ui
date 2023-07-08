using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Tazakor
    {
        public static OperationResult<List<Tazakor_Tbl>> Select(string search = "")
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var query = dataContext.Tazakor_Tbls.Where(p => p.TazakorDate==search).ToList();
                return new OperationResult<List<Tazakor_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Tazakor_Tbl>>
                {
                    Success = false
                };

            }
        }

        public static OperationResult<List<Tazakor_Tbl>> SelectByMoredTitle(string Title)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var query = dataContext.Tazakor_Tbls.Where(p => p.TazakorMoredTypeTitle == Title).ToList();
                return new OperationResult<List<Tazakor_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Tazakor_Tbl>>
                {
                    Success = false
                };

            }
        }
        public static OperationResult Delete(int id)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var tazakor = dataContext.Tazakor_Tbls.Where(p => p.Id == id).Single();
                dataContext.Tazakor_Tbls.DeleteOnSubmit(tazakor);
                dataContext.SubmitChanges();
                var result = Mored.SelectScore(tazakor.TazakorMoredTypeTitle);
                if (result.Success)
                {
                    var student = Student.SelectStudent(tazakor.TazakorStudentCode);
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
        public static OperationResult Insert(Tazakor_Tbl tazakor)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                dataContext.Tazakor_Tbls.InsertOnSubmit(tazakor);
                dataContext.SubmitChanges();
                var result = Mored.SelectScore(tazakor.TazakorMoredTypeTitle);
                if (result.Success)
                {
                    var student = Student.SelectStudent(tazakor.TazakorStudentCode);
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
                    Success = false
                };
            }


        }
        public static OperationResult Update(Tazakor_Tbl tazakor, double lastScore, bool updateMored = false)
        {
            string lastTitle;
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var lastTazakor = dataContext.Tazakor_Tbls.Where(p => p.Id == tazakor.Id).Single();
                lastTitle = lastTazakor.TazakorMoredTypeTitle; 
                var result = Mored.SelectScore(lastTitle);
                    var result2 = Mored.SelectScore(tazakor.TazakorMoredTypeTitle);
                lastTazakor.TazakorElat = tazakor.TazakorElat;
                lastTazakor.TazakorEghdamKonande = tazakor.TazakorEghdamKonande;
                lastTazakor.TazakorMoredTypeTitle = tazakor.TazakorMoredTypeTitle;
                dataContext.SubmitChanges();
                if (lastTitle != tazakor.TazakorMoredTypeTitle || result.Data != lastScore)
                {
                  

                    if (result.Success && result2.Success)
                    {
                        if(updateMored)
                        {
                            var student = Student.SelectStudent(tazakor.TazakorStudentCode);
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
                            var student = Student.SelectStudent(tazakor.TazakorStudentCode);
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
        public static OperationResult<List<Tazakor_Tbl>> SelectTazakorsStudent(string StudentCode)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var tazakors = dataContext.Tazakor_Tbls.Where(tazakor => tazakor.TazakorStudentCode == StudentCode).ToList();
                return new OperationResult<List<Tazakor_Tbl>>
                {
                    Success = true,
                    Data = tazakors
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<Tazakor_Tbl>>
                {
                    Success = false,
                };
            }   
        }

        public static OperationResult MinusScore(Tazakor_Tbl takhir, double score)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var student = Student.SelectStudent(takhir.TazakorStudentCode);
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
