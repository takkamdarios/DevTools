using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DevTools.FileStorage
{
    public class FileStorage<T> : IFileStorage<T>
        where T: BaseModel
    {
        #region (Properties)
        private string fileLocation;

        // data collection mapping
        private List<T> list = new List<T>();
        #endregion

        #region (Constructor)
        public FileStorage(string directory, string fileName)
        {
            // get file name from class type
            //var fileName = $"{typeof(T).Name}.json";

            fileName = $"{(fileName.Contains(".") ? fileName.Split('.')[0] : fileName)}.json";

            fileLocation = Path.Combine(directory, fileName);
            FileStream fStream = null;
            // create directory if not exists
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            //create file if not exists
            if (!File.Exists(fileLocation))
                fStream = File.Create(fileLocation);
            
            // close file if it's open
            fStream?.Close();

            // get data from file and map in collection "list"
            Deserialize();
        }
        public FileStorage() { }

        #endregion

        #region (Public Methods)

        public virtual T Create(T data)
        {
            if(data == null)
                throw new ArgumentNullException("data: ist not reference as instance of an object");
            data.CreateAt = DateTime.Now;
            data.Id = (list.LastOrDefault()?.Id ?? 0) + 1;
            list.Add(data);
            Serialize();
            return data;
        }

        public virtual T Update(int id, T data)
        {
            if (data == null)
                throw new ArgumentNullException("data: ist not reference as instance of an object");

            var result = list.FirstOrDefault(x => x.Id == id);
            if(result == null)
                throw new ArgumentNullException("Entity not found");
            data.UpdateAt = DateTime.Now;
            var index = list.IndexOf(result);
            data.Id = result.Id;
            list[index] = data;
            Serialize();

            return data;
        }

        public virtual T Delete(int id)
        {
            var result = list.FirstOrDefault(x => x.Id == id);
            if (result == null)
                throw new ArgumentNullException("Entity not found");
            list.Remove(result);
            Serialize();

            return result;
        }

        public virtual T Get(int id)
        {
            var result = list.FirstOrDefault(x => x.Id == id);
            if (result == null)
                throw new ArgumentNullException("Entity not found");
            return result;
        }

        public virtual ICollection<T> GetAll(int? skip = null, int? take = null) =>
            list.Skip(skip ?? 0).Take(take ?? list.Count).ToList();

        public virtual ICollection<T> SeachAllBy(Func<T, bool> predicate, int? skip = null, int? take = null)
        {
            var results = list.Where(predicate);
            if (results == null)
                throw new ArgumentNullException("Entity not found");
            return results.Skip(skip ?? 0).Take(take ?? results.Count()).ToList();
        }
        public virtual T SeachOneBy(Func<T, bool> predicate)
        {
            var result = list.FirstOrDefault(predicate);
            if(result == null)
                throw new ArgumentNullException("Entity not found");

            return result;
        }
        #endregion

        #region (Private Methods)

        private void Deserialize()
        {
            var json = File.ReadAllText(fileLocation);
            list = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        private void Serialize()
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(list);
                File.WriteAllText(fileLocation, jsonData);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        #endregion
    }
}