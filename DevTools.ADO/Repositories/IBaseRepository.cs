using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.ADO.Repositories
{
    /// <summary>
    /// This class describe all methods that will be manage in <typeparamref name="T"/> repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IBaseRepository<T>
    {
        /// <summary>
        /// This method add a new <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity">Represents the <typeparamref name="T"/> will be added</param>
        void Add(T entity);


        /// <summary>
        /// This method update a <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity">Represents the <typeparamref name="T"/> will be updated</param>
        /// <param name="id">Represents the id of the <typeparamref name="T"/> before update</param>
        void Update(int id, T entity);


        /// <summary>
        /// This method delete a <typeparamref name="T"/>
        /// </summary>
        /// <param name="id">Represents the id of the <typeparamref name="T"/> will be deleted</param>
        void Delete(int id);


        /// <summary>
        /// This method get one <typeparamref name="T"/>
        /// </summary>
        /// <param name="id">Represents the id of the <typeparamref name="T"/></param>
        T Get(int id);


        /// <summary>
        /// This method get all <typeparamref name="T"/>
        /// </summary>
        ICollection<T> GetAll();
    }
}
