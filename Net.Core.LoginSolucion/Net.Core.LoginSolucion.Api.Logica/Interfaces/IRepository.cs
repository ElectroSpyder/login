using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Net.Core.LoginSolucion.Api.Infraestructura.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtiene una Entidad por id o key o Guid.
        /// </summary>
        /// <param name="id">Id o Key o Guid</param>
        /// <returns><see cref="TEntity"/></returns>
        TEntity GetById(Guid id);

        /// <summary>
        /// Obtiene una lista de Entidades.
        /// </summary>
        /// <returns>List of <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Obtiene una lista de Entidades segun alguna Condicion
        /// </summary>
        /// <param name="filter">Filtro Ej.Where(x=> x.Propiedad)</param>
        /// <param name="orderBy">Define el ordenamiento Ej. (y => y.Id)</param>        
        /// <returns></returns>
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Entidad a Actualizar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(TEntity entity);

        /// <summary>
        /// Entidad a Agregar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool AddEntity(TEntity entity);
        
    }
}
