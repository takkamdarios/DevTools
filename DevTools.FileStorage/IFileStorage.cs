using System;
using System.Collections.Generic;

namespace DevTools.FileStorage
{
    public interface IFileStorage<T>
    {
        /// <summary>
        /// Save data into the file
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        //void Serialize(ICollection<T> data);

        /// <summary>
        /// Fetch data inside the file
        /// </summary>
        /// <returns></returns>
        //ICollection<T>? Deserialize();

        T Create(T data);
        T Update(int id, T data);
        T Delete(int id);
        T Get(int id);
        ICollection<T> GetAll(int? skip, int? take);
        ICollection<T> SeachAllBy(Func<T, bool> predicat, int? skip, int? take);
        T SeachOneBy(Func<T, bool> predicat);
    }
}