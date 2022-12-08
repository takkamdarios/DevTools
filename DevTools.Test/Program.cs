using DevTools.Designer;
using System;
using System.Collections.Generic;

namespace DevTools.Test
{
    class Program
    {
        static void Main(string[] args) {
            string[,] multi = new string[5, 4];

            multi[0, 0] = "Etudiants (NOM)";
            multi[0, 1] = "Matricule";
            multi[0, 2] = "Enseignants (NOM)";
            multi[0, 3] = "Salaire";
            multi[1, 0] = "Kevin SOKOUDJOU";
            multi[1, 1] = "000KeSoK2022";
            multi[1, 2] = "Jordan Wildes SUSOWIJO";
            multi[1, 3] = "50.000$";
            multi[2, 0] = "Darios TAKAM";
            multi[2, 1] = "000DaTak2022";
            multi[2, 2] = "Stratege TAKAM";
            multi[2, 3] = "1000$";
            multi[3, 0] = "Mariella MAJOUMO TCHUDING";
            multi[3, 1] = "000MaMaj2022";
            multi[3, 2] = "Guillaume SORO";
            multi[3, 3] = "2000$";
            multi[4, 0] = "Jorelle PELAHO";
            multi[4, 1] = "000JoPel2022";
            multi[4, 2] = "Junior DIMARIA";
            multi[4, 3] = "1.500$";


            var list = new List<Person>
            {
                new Person
                {
                    DateNaiss = DateTime.Now,
                    Email = "sokoubi@gmail.com",
                    MotDePasse = "12345678", 
                    Nom = "SOKOU Billionaire",
                    Pseudo = "sokoubil"
                },
                new Person
                {
                    DateNaiss = DateTime.Now,
                    Email = "algotak@gmail.com",
                    MotDePasse = "1234", 
                    Nom = "TAKAM Talla Darios",
                    Pseudo = "algorithme"
                },
                new Person
                {
                    DateNaiss = DateTime.Now,
                    Email = "pelasusie@gmail.com",
                    MotDePasse = "@susi123Spt-14", 
                    Nom = "Pelaho",
                    Pseudo = "SPTJ"
                },
                new Person
                {
                    DateNaiss = DateTime.Now,
                    Email = "mariella@gmail.com",
                    MotDePasse = "Mar1-3@tchu", 
                    Nom = "TCHUDING Mariella",
                    Pseudo = "mariellamajoumo2000"
                },
            };

            var p =
                new Person
                {
                    DateNaiss = DateTime.Now,
                    Email = "exemple@test.com",
                    MotDePasse = "123",
                    Nom = "Jordan4 Sokamte",
                    Pseudo = "susowijo"
                };
            //p.Show();

            /*var dic = Design.DictionnaryFrom<Person>(list.Select(x => new Person 
            { 
                Pseudo = x.Pseudo, MotDePasse = x.MotDePasse 
            }));*/
            var dictionnary = new Dictionary<string, IEnumerable<string>>
            {
                {"Email", new []{ "sokoubi@gmail.com", "algotak@gmail.com", "pelasusie@gmail.com", "mariella@gmail.com" } },
                {"Pseudo", new []{ "algorithme", "SPTJ", "mariellamajoumo2000", "susowijo" } }
            };
            var excludeProps = new string[] { "MotDePasse", "Pseudo" };
            //var multiArr = Design.GetMultiDimArrayFrom<Person>(list);
            //var multiArr = Design.GetMultiDimArrayFrom<Person>(list, excludeProps);
            //var multiArr = Design.GetMultiDimArrayFrom(dictionnary);
            var dic = Design.DictionnaryFrom<Person>(list);
            var multiArr = Design.GetMultiDimArrayFrom(dic);
            Design.Show(multiArr);
            
            Console.ReadKey();
        }
    }
}
