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
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
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
                SAPDbDataContext dataContext = new SAPDbDataContext();
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
                SAPDbDataContext dataContext = new SAPDbDataContext();
                dataContext.Tazakor_Tbls.InsertOnSubmit(tazakor);
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
        public static OperationResult Update(Tazakor_Tbl tazakor)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
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
                SAPDbDataContext dataContext = new SAPDbDataContext();
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
