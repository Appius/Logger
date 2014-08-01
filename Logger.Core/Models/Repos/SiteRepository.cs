using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using Logger.Core.Models.Abstract;
using Logger.Core.Models.Tables;

namespace Logger.Core.Models.Repos
{
    public class SiteRepository : RepositoryBase, ISiteRepository
    {
        public UserProfile GetUserByApiKey(string key)
        {
            var firstOrDefault = Db.Sites.FirstOrDefault(item => item.ApiKey == key);
            return firstOrDefault == null ? null : firstOrDefault.UserProfile;
        }

        public Site Get(int id)
        {
            return Db.Sites.FirstOrDefault(item => item.Id == id);
        }

        public Site Get(string apikey)
        {
            return Db.Sites.FirstOrDefault(item => item.ApiKey == apikey);
        }

        public IEnumerable<Site> GetAllByUserId(int userId)
        {
            return Db.Sites.Where(item => item.UserId == userId).OrderBy(item => item.Id);
        }

        public IEnumerable<Site> GetAll()
        {
            return Db.Sites.OrderBy(item => item.Id);
        }

        public int Add(Site site)
        {
            Db.Sites.Add(site);
            try
            {
                return Db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int Toggle(Site site)
        {
            var firstOrDefault = Db.Sites.FirstOrDefault(item => item.Id == site.Id);
            if (firstOrDefault != null)
                firstOrDefault.IsBlocked = !firstOrDefault.IsBlocked;
            return Db.SaveChanges();
        }

        public int Remove(Site site)
        {
            var firstOrDefault = Db.Sites.FirstOrDefault(item => item.Id == site.Id);
            if (firstOrDefault != null)
            {
                Db.Sites.Remove(firstOrDefault);
            }
            return Db.SaveChanges();
        }

        public int Remove(int siteid)
        {
            return Remove(new Site {Id = siteid});
        }
    }
}