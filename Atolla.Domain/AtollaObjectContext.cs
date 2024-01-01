using Atolla.Core.BaseRepository;
using Atolla.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Atolla.Domain
{
    public class AtollaObjectContext : DbContext, IDbContext
    {
        public AtollaObjectContext(DbContextOptions<AtollaObjectContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityMappingConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }


        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }



        public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class
        {
            return null;// Query<TQuery>().FromSql(CreateSqlWithParameters(sql, parameters), parameters);
        }


        public virtual IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity
        {
            return null;//  Set<TEntity>().FromSql(CreateSqlWithParameters(sql, parameters), parameters);
        }

        public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }
    }

    public class QBObjectContextFactory : IDesignTimeDbContextFactory<AtollaObjectContext>
    {
        public AtollaObjectContext CreateDbContext(string[] args)
        {
            string connectionStringOracl = $"Password=Atolla21;User Id=Atolla;Data Source=atollavm.francecentral.cloudapp.azure.com:1521/XE";

            var optionsBuilder = new DbContextOptionsBuilder<AtollaObjectContext>();
            optionsBuilder.UseOracle(connectionStringOracl, s => s.UseOracleSQLCompatibility("11"));
            return new AtollaObjectContext(optionsBuilder.Options);
        }
    }
}
