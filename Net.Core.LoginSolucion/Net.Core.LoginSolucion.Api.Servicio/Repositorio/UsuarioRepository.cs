using Microsoft.EntityFrameworkCore;
using Net.Core.LoginSolucion.Api.Infraestructura.Interfaces;
using Net.Core.LoginSolucion.Api.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Net.Core.LoginSolucion.Api.Servicio.Repositorio
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly LoginDBContext dBContext;
        private readonly DbSet<Usuario> dbSet;

        public UsuarioRepository(LoginDBContext Context)
        {
            dBContext = Context ?? throw new ArgumentNullException(nameof(Context));
            dbSet = dBContext.Set<Usuario>();
        }

        /// <summary>
        /// Metodo que retorna un usuario especifico
        /// </summary>
        /// <param name="filter">(x => x.Usuario == miUsuario && x.Password == miPassword)</param>
        /// <returns>Retorna un queriable de Usuarios</returns>
        public IEnumerable<Usuario> Get(Expression<Func<Usuario, bool>> filter = null)
        {
            IQueryable<Usuario> query = dbSet;

            if (filter != null)
                return query.Where(filter);

            return query;
        }

        public IQueryable<Usuario> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public Usuario GetById(Guid id)
        {
            var usuario = dbSet.Find(id);
            if (usuario == null) return null;

            dBContext.Entry(usuario).State = EntityState.Detached;

            return usuario;
        }

        public bool UpdateEntity(Usuario entity)
        {
            var usuarioUpdate = dbSet.Update(entity);
            var result = dBContext.SaveChanges();

            dBContext.Entry(entity).State = EntityState.Modified;

            return result > 0 ? true : false;
        }

        public bool AddEntity(Usuario entity)
        {
            var usuarioUpdate = dbSet.Add(entity);
            var result = dBContext.SaveChanges();

            dBContext.Entry(entity).State = EntityState.Added;

            return result > 0 ? true : false;
        }
    }
}
