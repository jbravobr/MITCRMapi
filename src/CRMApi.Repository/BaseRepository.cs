﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMApi.Repository
{
    /// <summary>
    /// Repositório Base implementado
    /// </summary>
    /// <typeparam name="T">Qualquer entidade do domínio</typeparam>
    /// <typeparam name="C">Um Contexto Entity Framework válido</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> 
        where T : class
    {
        string connectionString = "Server=MACBOOKPRO\\SQLEXPRESS;Database=myDataBase;User Id=sa;Password=r48xmxdmc44w;";

        CRMContext<T> _dbContext;
        public CRMContext<T> DBContext
        {
            get
            {
                var builder = new DbContextOptionsBuilder<CRMContext<T>>();
                builder.UseSqlServer(connectionString);

                return new CRMContext<T>(builder.Options);
            }
            set { _dbContext = value; }
        }

        /// <summary>
        /// Deleta um registro.
        /// </summary>
        public async Task<int> Delete(T TEntity)
        {
            try
            {
                DBContext.Set<T>().Remove(TEntity);
                return await DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna todos os registros de T
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<T>> GetAll()
        {
            try
            {
                return await DBContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retornar todos os registros de T usando predicate como filtro
        /// </summary>
        /// <param name="predicate">Filtro para entidade T</param>
        /// <returns></returns>
        public async Task<ICollection<T>> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await DBContext.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retornar T usando o Id como filtro
        /// </summary>
        /// <param name="Id">Id de T</param>
        /// <returns></returns>
        public async Task<T> GetById(int Id)
        {
            try
            {
                return await DBContext.Set<T>().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna T usando predicate como filtro.
        /// </summary>
        /// <param name="predicate">Filtro complexo para T</param>
        /// <returns></returns>
        public async Task<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await DBContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insere uma nova entidade de T
        /// </summary>
        /// <param name="TEntity">Entidade Nova</param>
        public async Task<int> Insert(T TEntity)
        {
            try
            {
                DBContext.Set<T>().Add(TEntity);
                return await DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza uma entidade de T
        /// </summary>
        /// <param name="Entity">Entidade para se atualizar</param>
        /// <returns></returns>
        public async Task<int> Update(T TEntity)
        {
            try
            {
                DBContext.Entry(TEntity).State = EntityState.Modified;
                 return await DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
