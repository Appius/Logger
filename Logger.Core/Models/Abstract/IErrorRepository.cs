using System;
using System.Linq;
using Logger.Core.Models.Tables;


namespace Logger.Core.Models.Abstract
{
    public interface IErrorRepository
    {
        void Add(Error model);
        void Delete(string apikey, int id);
        IQueryable<Error> GetAll(string apikey, bool orderByDescenting = false);
        Error Get(string apikey, int id);
        Error GetPrev(string apikey , int id);
        Error GetNext(string apikey, int id);
    }
}