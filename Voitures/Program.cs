using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voitures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Modèles chez Renault");

            var chaineConnexion = "Server=.;Database=Voitures;Trusted_Connection=True;";
            var connexion = new SqlConnection(chaineConnexion);
            connexion.Open();

            var commande = connexion.CreateCommand();
            commande.CommandText = 
                @"SELECT M.Nom AS NomModele, S.Nom AS NomSegment
                  FROM Modeles M
                      INNER JOIN Segments S ON S.Id = M.IdSegment
                  WHERE IdMarque = 2";
            var dataReader = commande.ExecuteReader();
            while (dataReader.Read())
            {
                var indexColonneNomModele = dataReader.GetOrdinal("NomModele");
                var indexColonneNomSegment = dataReader.GetOrdinal("NomSegment");
                Console.Write(dataReader.GetString(indexColonneNomModele));
                Console.Write(" (");
                Console.Write(dataReader.GetString(indexColonneNomSegment));
                Console.WriteLine(")");
            }

            connexion.Close();

            Console.ReadKey();
        }
    }
}
