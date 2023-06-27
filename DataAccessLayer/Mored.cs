using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Mored
    {
        public static OperationResult<List<Mavared_Tbl>> Select()
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var query = dataContext.Mavared_Tbls.ToList();
                return new OperationResult<List<Mavared_Tbl>>
                {
                    Success = true,
                    Data = query
                };
            }
            catch
            {
                return new OperationResult<List<Mavared_Tbl>>
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
                var query = dataContext.Mavared_Tbls.Where(p => p.Id == id).Single();
                dataContext.Mavared_Tbls.DeleteOnSubmit(query);
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
        public static OperationResult Insert(Mavared_Tbl mored)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                dataContext.Mavared_Tbls.InsertOnSubmit(mored);
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
        public static OperationResult Update(Mavared_Tbl mored)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var query = dataContext.Mavared_Tbls.Where(p => p.MoredTitle == mored.MoredTitle).Single();
                query.MoredType = mored.MoredType;
                query.MoredScore = mored.MoredScore;
                query.MoredTitle = mored.MoredTitle;
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

        public static OperationResult<List<string>> SelectTitles(string type)
        {
            try
            {
                SAPDbDataContext dataContext = new SAPDbDataContext();
                var mavared = dataContext.Mavared_Tbls.Where(x => x.MoredType == type);
                List<string> titles = new List<string>();
                foreach (Mavared_Tbl mored in mavared)
                {
                    titles.Add(mored.MoredTitle);
                }
                return new OperationResult<List<string>>
                {
                    Success = true,
                    Data = titles
                };
            }
            catch(Exception)
            {
                return new OperationResult<List<string>> { Success = false };
            }
        }

    }
}
