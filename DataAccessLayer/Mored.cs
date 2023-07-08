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
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
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
            SAPDbDataContext dataContext = new SAPDbDataContext();
            string title;
            try
            {
                var query = dataContext.Mavared_Tbls.Where(p => p.Id == id).Single();
                title = query.MoredTitle;
                var takhirs = Takhir.SelectByMoredTitle(query.MoredTitle);
                var tashvighs = Tashvigh.SelectByMoredTitle(query.MoredTitle);
                var tazakors = Tazakor.SelectByMoredTitle(query.MoredTitle);
                var gheybats = Gheybat.SelectByMoredTitle(query.MoredTitle);
                foreach (Takhir_Tbl takhir in takhirs.Data)
                {
                    Takhir.MinusScore(takhir, query.MoredScore);
                }
                foreach (Tashvigh_Tbl tashvigh in tashvighs.Data)
                {
                    Tashvigh.MinusScore(tashvigh, query.MoredScore);
                }
                foreach (Tazakor_Tbl tazakor in tazakors.Data)
                {
                    Tazakor.MinusScore(tazakor, query.MoredScore);
                }
                foreach (Gheybat_Tbl gheybat in gheybats.Data)
                {
                    Gheybat.MinusScore(gheybat, query.MoredScore);
                }
                
                dataContext.Mavared_Tbls.DeleteOnSubmit(query);
                dataContext.SubmitChanges();
                var score = Mored.SelectScore(title);
                
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
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
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
        public static OperationResult Update(Mavared_Tbl mored,double lastScore)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var query = dataContext.Mavared_Tbls.Where(p => p.MoredTitle == mored.MoredTitle).Single();
                query.MoredScore = mored.MoredScore;
                dataContext.SubmitChanges();
                var takhirs = Takhir.SelectByMoredTitle(query.MoredTitle);
                var tashvighs = Tashvigh.SelectByMoredTitle(query.MoredTitle);
                var tazakors = Tazakor.SelectByMoredTitle(query.MoredTitle);
                var gheybats = Gheybat.SelectByMoredTitle(query.MoredTitle);
                foreach (Takhir_Tbl takhir in takhirs.Data)
                {
                    Takhir.Update(takhir, lastScore, true);
                }
                foreach (Tashvigh_Tbl tashvigh in tashvighs.Data)
                {
                    Tashvigh.Update(tashvigh, lastScore, true);
                }
                foreach (Tazakor_Tbl tazakor in tazakors.Data)
                {
                    Tazakor.Update(tazakor, lastScore,true);
                }
                foreach (Gheybat_Tbl gheybat in gheybats.Data)
                {
                    Gheybat.Update(gheybat, lastScore,true);
                }
                return new OperationResult
                {
                    Success = true,

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
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
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

        public static OperationResult CheckTitle(string title)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var result = dataContext.Mavared_Tbls.Where(x => x.MoredTitle == title).ToList();
                if (result.Count == 0)
                {
                    return new OperationResult
                    {
                        Success = true
                    };
                }
                return new OperationResult
                {
                    Success = false,
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

        public static OperationResult<double> SelectScore(string title)
        {
            SAPDbDataContext dataContext = new SAPDbDataContext();
            try
            {
                var result = dataContext.Mavared_Tbls.Where(x => x.MoredTitle == title).ToList();
                if (result.Count != 0)
                {
                    return new OperationResult<double>
                    {
                        Success = true,
                        Data = result[0].MoredScore
                    };
                }
                return new OperationResult<double>
                {
                    Success = false,
                };
            }
            catch (Exception)
            {
                return new OperationResult<double>
                {
                    Success = false
                };
            }
           
        }

    }
}
