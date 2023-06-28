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
        public static SAPDbDataContext dataContext = new SAPDbDataContext();

        public static OperationResult<List<Takhir_Tbl>> Select(string Search = "")
        {
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
        public static OperationResult Delete(string code, string tarikh)
        {
            try
            {
                var query = dataContext.Takhir_Tbls.Where(p => p.TakhirStudentCode == code &&
                p.TakhirDate == tarikh).Single();
                dataContext.Takhir_Tbls.DeleteOnSubmit(query);
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
        public static OperationResult Insert(Takhir_Tbl takhir)
        {
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
        public static OperationResult Update(Takhir_Tbl takhir)
        {
            try
            {
                var query = dataContext.Takhir_Tbls.Where(p => p.TakhirStudentCode == takhir.TakhirStudentCode &&
                p.TakhirDate == takhir.TakhirDate).Single();
                if (query != null)
                {
                    query.TakhirMoredTypeTitle = takhir.TakhirMoredTypeTitle;
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
        public static OperationResult<List<Takhir_Tbl>> SelectTakhirsStudent(string StudentCode)
        {
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
            var result = dataContext.Takhir_Tbls.Where(x => x.TakhirStudentCode == StudentCode && x.TakhirDate== Date).ToList();
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
    }

}
