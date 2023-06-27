using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Tashvigh
    {
        public static OperationResult<List<Tashvigh_Tbl>> Select(string search = "")
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var query = dataContext.Tashvigh_Tbls.Where(p => p.TashvighDate==search).ToList();
                return new OperationResult<List<Tashvigh_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Tashvigh_Tbl>>
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
                var query = dataContext.Tashvigh_Tbls.Where(p => p.Id == id).Single();
                dataContext.Tashvigh_Tbls.DeleteOnSubmit(query);
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
        public static OperationResult Insert(Tashvigh_Tbl tashvigh)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                dataContext.Tashvigh_Tbls.InsertOnSubmit(tashvigh);
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
        public static OperationResult Update(Tashvigh_Tbl tashvigh)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var query = dataContext.Tashvigh_Tbls.Where(p => p.Id == tashvigh.Id).Single();
                query.TashvighElat = tashvigh.TashvighElat;
                query.TashvighEghdamKonande = tashvigh.TashvighEghdamKonande;
                query.TashvighMoredTypeTitle = tashvigh.TashvighMoredTypeTitle;
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

        public static OperationResult<List<Tashvigh_Tbl>> SelectTashvighsStudent(string StudentCode)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var tashvighs = dataContext.Tashvigh_Tbls.Where(tashvigh => tashvigh.TashvighStudentCode == StudentCode).ToList();
                return new OperationResult<List<Tashvigh_Tbl>>
                {
                    Success = true,
                    Data = tashvighs
                };
            }
            catch (Exception)
            {
                return new OperationResult<List<Tashvigh_Tbl>>
                {
                    Success = false,
                };
            }
        }

    }
}
