using System.Collections.Generic;
using System.Linq;

namespace DevTools.Designer
{
    public static partial class Design
    {

        /// <summary>
        /// Construit un dictionnaire a partir de la liste en paramètre 
        /// </summary>
        /// <typeparam name="T">Type générique: représente le type de donnée dans collection en paramètre </typeparam>
        /// <param name="list">Collection de <typeparamref name="T"/></param>
        /// <returns>
        /// Dictionnaire ayant comme <c>'clé'</c> : les propriétés du type <typeparamref name="T"/>, et
        /// <c>'valeur'</c> : toutes les valeurs d'une propriété particulière dans la liste
        /// </returns>
        public static IDictionary<string, IEnumerable<string>> DictionnaryFrom<T>(IEnumerable<T> list)
        {
            var props = typeof(T).GetProperties().Select(x => x.Name);
            var dictionnary = new Dictionary<string, IEnumerable<string>>();

            for (int i = 0; i < props.Count(); i++)
            {
                var values = new List<string>();
                foreach (var val in list)
                    values.Add(val.GetType().GetProperty(props.ElementAt(i)).GetValue(val)?.ToString() ?? "");

                dictionnary.Add(props.ElementAt(i), values);
            }
            return dictionnary;
        }


        /// <summary>
        /// Obtains multi dimension array from Dictionnary
        /// </summary>
        /// <param name="datas">Dictionnary of datas</param>
        /// <returns>
        /// Multi dimension array with <c>'column'</c> : dictionnary keys count, and
        /// <c>'rows'</c> : dictionnary value count
        /// </returns>
        public static string[,] GetMultiDimArrayFrom(IDictionary<string, IEnumerable<string>> datas)
        {
            var props = datas.Keys;
            string[,] multiArr = new string[datas.Values.ElementAt(0).Count() + 1, props.Count()];

            for (int i = 0; i < datas.Count(); i++)
            {
                multiArr[0, i] = props.ElementAt(i);

                var values = datas[props.ElementAt(i)];
                for (int j = 1; j <= values.Count(); j++)
                    multiArr[j, i] = values.ElementAt(j - 1);
            }
            return multiArr;
        }


        // create multi dimension table from collection datas
        public static string[,] GetMultiDimArrayFrom<T>(IEnumerable<T> list)
        {
            var props = typeof(T).GetProperties().Select(x => x.Name);
            string[,] multiArr = new string[list.Count() + 1, props.Count()];

            for (int i = 0; i < props.Count(); i++)
                multiArr[0, i] = props.ElementAt(i);

            int line = 1;
            foreach (var item in list)
            {
                int col = 0;
                foreach (var prop in props)
                {
                    multiArr[line, col] = item.GetType().GetProperty(prop).GetValue(item)?.ToString() ?? "";
                    col++;
                }

                line++;
            }
            return multiArr;
        }


        // create multi dimension table from collection datas with possibility to excluse some properties
        public static string[,] GetMultiDimArrayFrom<T>(IEnumerable<T> list, ICollection<string> excludeProps)
        {
            var props = typeof(T).GetProperties().Select(x => x.Name).ToList();
            // we have only add this
            props.RemoveAll(x => excludeProps.Contains(x));
            //
            string[,] multiArr = new string[list.Count() + 1, props.Count()];

            for (int i = 0; i < props.Count(); i++)
                multiArr[0, i] = props.ElementAt(i);

            int line = 1;
            foreach (var item in list)
            {
                int col = 0;
                foreach (var prop in props)
                {
                    multiArr[line, col] = item.GetType().GetProperty(prop).GetValue(item)?.ToString() ?? "";
                    col++;
                }

                line++;
            }
            return multiArr;
        }
    }
}
