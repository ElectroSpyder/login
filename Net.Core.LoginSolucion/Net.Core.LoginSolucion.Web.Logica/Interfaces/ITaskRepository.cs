using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Net.Core.LoginSolucion.Api.Infraestructura.Interfaces
{
    public interface ITaskRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtiene una Entidad por id o key o Guid.
        /// </summary>
        /// <param name="id">Id o Key o Guid</param>
        /// <returns><see cref="TEntity"/></returns>
        Task<TEntity> GetById(Guid id);

        /// <summary>
        /// Obtiene una lista de Entidades.
        /// </summary>
        /// <returns>List of <see cref="TEntity"/></returns>
        Task<IQueryable<TEntity>> GetAll();

        /// <summary>
        /// Obtiene una lista de Entidades segun alguna Condicion
        /// </summary>
        /// <param name="filter">Filtro Ej.Where(x=> x.Propiedad)</param>
        /// <param name="orderBy">Define el ordenamiento Ej. x => x.OrderBy(y => y.Id)</param>        
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Entidad a almacenar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateEntity(TEntity entity);
    }
}
