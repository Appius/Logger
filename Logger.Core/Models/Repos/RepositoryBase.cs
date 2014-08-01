using System;

namespace Logger.Core.Models.Repos
{
    public abstract class RepositoryBase
    {
        private static readonly Lazy<DBContext> Lazy = new Lazy<DBContext>(() => new DBContext());

        protected static DBContext Db { get { return Lazy.Value; } }

        protected RepositoryBase()
        {
        }
    }
}