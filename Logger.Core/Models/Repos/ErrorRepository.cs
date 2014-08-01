using System;
using System.Linq;
using Logger.Core.Models.Abstract;
using Logger.Core.Models.Tables;


namespace Logger.Core.Models.Repos
{
    public class ErrorRepository : RepositoryBase, IErrorRepository
    {
        public void Add(Error error)
        {
            Db.Errors.Add(error);
            Db.SaveChanges();
        }

        public void Delete(string apikey, int id)
        {
            var firstOrDefault = Db.Errors.FirstOrDefault(item => item.ApiKey == apikey && item.Id == id);
            if (firstOrDefault != null)
                Db.Errors.Remove(firstOrDefault);
            Db.SaveChanges();
        }

        public IQueryable<Error> GetAll(string apikey, bool orderByDescending = true)
        {
            return orderByDescending
                ? Db.Errors.Where(item => item.ApiKey == apikey).OrderByDescending(item => item.Id)
                : Db.Errors.Where(item => item.ApiKey == apikey).OrderBy(item => item.Id);
        }

        public Error Get(string apikey, int id)
        {
            return Db.Errors.FirstOrDefault(item => item.ApiKey == apikey && item.Id == id);
        }

        public Error GetNext(string apikey, int id)
        {
            return Db.Errors.FirstOrDefault(item => item.ApiKey == apikey && item.Id > id);
        }

        public Error GetPrev(string apikey, int id)
        {
            return
                Db.Errors.Where(item => item.ApiKey == apikey && item.Id < id)
                    .OrderByDescending(m => m.Id)
                    .FirstOrDefault();
        }
    }
}