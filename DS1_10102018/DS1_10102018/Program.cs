using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DS1_10102018
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix;
            string host;
            string user;
            string bdd;
            string pwd;
            MySqlCommand Cmd;
            MySqlConnection Cnx;
           
            Requetes rq;

            /*paramètres de connexion
            Console.WriteLine("Donner le nom du serveur");
            host = Console.ReadLine();
            Console.WriteLine("Donner le nom de la base de données");
            bdd = Console.ReadLine();
            Console.WriteLine("Donner le nom de l'utilisateur");
            user= Console.ReadLine();
            Console.WriteLine("Donner le mot de passe");
            pwd = Console.ReadLine(); */

            host = "localhost";
            bdd = "gesper";
            user = "root";
            pwd = "";


            // connexion

            rq = new Requetes(host, user, bdd, pwd);

            do
            {
                do
                {
                    Console.WriteLine("1 - liste complète des employés (utiliser une requête)");
                    Console.WriteLine("2 - liste complète des services (utiliser la table, sans écrire de requête)");
                    Console.WriteLine("3 - mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée)");
                    Console.WriteLine("4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)");
                    Console.WriteLine("5 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)");

                    Console.WriteLine("6 - Procédure utilisateur de creation d'un nouvel employé");
                    Console.WriteLine("7 - Procédure utilisateur qui donne la liste des employes qui possèdent à la fois le bac et une licence");
                    Console.WriteLine("8 - Procédure donnant les employés qui ont un salaire compris dans une borne");
                    Console.WriteLine("9 - Procédure Permettant de mettre a jour le budget d'un service");
                    Console.WriteLine("10 - Procedure permettant d'afficher le(s) nom(s) et prenom(s) de(s) employé(s) qui ont plus de diplome que la moyenne des diplomes possedes par chaque employés");

                    Console.WriteLine("11 - fin du traitement");


                    choix = Int32.Parse(Console.ReadLine());

                } while (choix < 0 || choix > 11);

                switch (choix)
                {
                    #region 1 - liste complète des employés (utiliser une requête)")
                    case 1:
                        Console.WriteLine("\n1 - liste complète des employés (utiliser une requête)");

                        Console.WriteLine(rq.ListeEmployes());


                        break;
                    #endregion

                    #region 2 - liste complète des services (utiliser la table, sans écrire de requête)")
                    case 2:
                        Console.WriteLine("\n1 - liste complète des services (utiliser la table, sans écrire de requête)");
                        
                        Console.WriteLine(rq.ListeServices());
                     
                        break;
                    #endregion
                    #region 3 - mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée majSalaire)
                    case 3:
                        Console.WriteLine("\n3 - mettre à jour le salaire d'un employé en passant en paramètre le nom de l'employé et le pourcentage d'augmentation (utiliser la procédure stockée majSalaire)");
                      
                        Console.WriteLine(rq.MajSalaire("Dupont",0.2));
                        break;
                    #endregion

                 
                    #region 4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)
                    case 4:
                        Console.WriteLine("\n4 - Donner la masse salariale mensuelle d'un service (procédure stockée paramétrée)");
                        /*Console.WriteLine("nom du service ?");
                        string nomService = Console.ReadLine();*/

                        Console.WriteLine(rq.MasseSalariale("Atelier A"));


                        break;
                    #endregion
                    #region 5 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)
                    case 5:
                        Console.WriteLine("\n5 - liste des employés cadres qui gagnent plus que la moyenne des salaires des cadres(utiliser une requête)");
                        
                       
                        Console.WriteLine(rq.SuperCadre());


                        break;
                    #endregion
                    #region 6 - Procédure utilisateur de creation d'un nouvel employé
                    case 6:
                        Console.WriteLine("\n6 - Procédure utilisateur de creation d'un nouvel employé");
                        rq.NewEmploye("sdfs", "dfdfq", "M", 0, 2000, 1);
                        break;
                    #endregion


                    #region 7 - Procédure utilisateur qui donne la liste des employes qui possèdent à la fois le bac et une licence
                    case 7:
                        Console.WriteLine("7 - Procédure utilisateur qui donne la liste des employes qui possèdent à la fois le bac et une licence");
                        Console.WriteLine(rq.BacLic());
                        break;
                    #endregion


                    #region 8 - Procédure donnant les employés qui ont un salaire compris dans une borne
                    case 8:
                        Console.WriteLine("8 - Procédure donnant les employés qui ont un salaire compris dans une borne");
                        Console.WriteLine(rq.Borne(3000,4000));
                        break;
                    #endregion


                    #region 9 - Procédure Permettant de mettre a jour le budget d'un service
                    case 9:
                        Console.WriteLine("9 - Procédure Permettant de mettre a jour le budget d'un service\n requete");
                        rq.UpDateService(3, 0.35);
                        Console.WriteLine("effectué");
                        break;
                    #endregion



                    #region 10 -  Procedure permettant d'afficher le(s) nom(s) et prenom(s) de(s) employé(s) qui ont plus de diplome que la moyenne des diplomes possedes par chaque employés
                    case 10:
                        Console.WriteLine("10 - Procedure permettant d'afficher le(s) nom(s) et prenom(s) de(s) employé(s) qui ont plus de diplome que la moyenne des diplomes possedes par chaque employés");
                        Console.WriteLine(rq.MoyenneDiplome());
                        break;
                    #endregion

                    #region 11 - Fin
                    case 11:
                        Console.WriteLine("\nFin du traitement");
                        break;
                        #endregion

                }
            }
            while (choix != 11);

            Console.ReadLine();
        }
    }
}
