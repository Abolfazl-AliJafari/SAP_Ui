using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Tazakor
    {
        public static SAPDbDataContext dataContext = new SAPDbDataContext();
        public static OperationResult<List<Tazakor_Tbl>> Select(string search = "")
        {
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
        public static OperationResult Delete(int id)
        {
            try
            {
                var query = dataContext.Tazakor_Tbls.Where(p => p.Id == id).Single();
                dataContext.Tazakor_Tbls.DeleteOnSubmit(query);
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
        public static OperationResult Insert(Tazakor_Tbl tazakor)
        {
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
        public static OperationResult Update(Tazakor_Tbl tazakor)
        {
            try
            {
                var query = dataContext.Tazakor_Tbls.Where(p => p.Id == tazakor.Id).Single();
                query.TazakorElat = tazakor.TazakorElat;
                query.TazakorEghdamKonande = tazakor.TazakorEghdamKonande;
                query.TazakorMoredTypeTitle = tazakor.TazakorMoredTypeTitle;
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
        public static OperationResult<List<Tazakor_Tbl>> SelectTazakorsStudent(string StudentCode)
        {
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
    }
}
