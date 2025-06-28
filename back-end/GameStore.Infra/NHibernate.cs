using NHibernate;
using NHibernate.Cfg;
using System.Reflection;
using NHibernate.Driver;

namespace GameStore.Infra
{
    public static class NHibernate
    {
        public static ISessionFactory BuildSessionFactory(string connString)
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(db =>
            {
                db.ConnectionString = connString;
                db.Driver<NpgsqlDriver>();
                db.Dialect<NHibernate.Dialect.PostgreSQLDialect>();
                db.SchemaAction = SchemaAutoAction.Validate;
            });
            cfg.AddAssembly(typeof(GameStore.Core.Entities.Game).Assembly);
            return cfg.BuildSessionFactory();
        }
    }
}