using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Takhir
    {
        public static OperationResult<List<Takhir_Tbl>> Select(string Search)
        {
            try
            {
                SAPDbDataContext linq = new SAPDbDataContext();
                var query = linq.Takhir_Tbls.Where(p => p.TakhirDate==Search).ToList();
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
                SAPDbDataContext linq = new SAPDbDataContext();
                var query = linq.Takhir_Tbls.Where(p => p.TakhirStudentCode == code &&
                p.TakhirDate == tarikh).Single();
                linq.Takhir_Tbls.DeleteOnSubmit(query);
                linq.SubmitChanges();
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
                SAPDbDataContext linq = new SAPDbDataContext();
                linq.Takhir_Tbls.InsertOnSubmit(takhir);
                linq.SubmitChanges();
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
        public static OperationResult Update(Takhir_Tbl takhir)
        {
            try
            {
                SAPDbDataContext linq = new SAPDbDataContext();
                var query = linq.Takhir_Tbls.Where(p => p.TakhirStudentCode == takhir.TakhirStudentCode &&
                p.TakhirDate == takhir.TakhirDate).Single();
                if (query != null)
                {
                    query.TakhirMoredTypeTitle = takhir.TakhirMoredTypeTitle;
                }
                linq.SubmitChanges();
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
                SAPDbDataContext dataContext = new SAPDbDataContext();
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
    }
}
