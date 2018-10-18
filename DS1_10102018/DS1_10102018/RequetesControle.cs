using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace DS1_10102018
{
    class Requetes
    {
        MySqlConnection cnx;
        public Requetes(string h, string u, string db, string p)
        {
            Connexion cn = new Connexion(h, u, db, p);
            cnx = cn.Cnx;
        }

        //Requete 1
        public string ListeEmployes()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select * from employe";
            cmdSql.CommandType = CommandType.Text;

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}, {3}, {4} {5} {6}\n",
                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
            }

            this.cnx.Close();
            return result;
        }
        //Requete 2
        public string ListeServices()
        {

            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "service";
            cmdSql.CommandType = CommandType.TableDirect;

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}, {3}, {4}, {5}\n",
                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
            }

            this.cnx.Close();
            return result;
        }
        //Requete 3
        public string MajSalaire(string nom, double pourcent)
        {

            string result = "mis a jour OK ! \n";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();


            cmdSql = new MySqlCommand("call augSalaire(@nom,@pourcent);", cnx);
            cmdSql.Parameters.Add(new MySqlParameter("@nom", MySqlDbType.String));
            cmdSql.Parameters["@nom"].Value = nom;
            cmdSql.Parameters.Add(new MySqlParameter("@pourcent", MySqlDbType.Int32));
            cmdSql.Parameters["@pourcent"].Value = pourcent;

            result = Convert.ToString(cmdSql.ExecuteScalar());


            this.cnx.Close();
            return result;
       }
        //Requete 4
        public decimal MasseSalariale(string nomService)
        {


            decimal result = 0;
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;

            cmdSql.CommandText = "MasseSalariale";
            cmdSql.CommandType = CommandType.StoredProcedure;

            cmdSql.Parameters.Add("unService", MySqlDbType.String);
            cmdSql.Parameters["unService"].Value = nomService;
            cmdSql.Parameters.Add("masse", MySqlDbType.Decimal);
            cmdSql.Parameters["masse"].Direction = ParameterDirection.Output;

            cmdSql.Prepare();

            cmdSql.ExecuteNonQuery();

            result = Convert.ToDecimal((cmdSql.Parameters["masse"].Value));

            this.cnx.Close();
            return result;
        }
        //Requete 5
        public string SuperCadre()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "drop view if exists cadre; create view cadre as select * from employe where emp_cadre = 1; select emp_nom from cadre where emp_salaire >(select avg(emp_salaire) from cadre);";
            cmdSql.CommandType = CommandType.Text;

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}\n", reader[0]);
            }

            this.cnx.Close();
            return result;
        }

        //Requete 6
        public void NewEmploye(string nom,string prenom,string sexe, byte cadre,decimal salaire,int emp_service)
        {



            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;

            cmdSql.CommandText = "newemploye";
            cmdSql.CommandType = CommandType.StoredProcedure;

            cmdSql.Parameters.Add("nom", MySqlDbType.String);
            cmdSql.Parameters["nom"].Value = nom;
            cmdSql.Parameters.Add("prenom", MySqlDbType.String);
            cmdSql.Parameters["prenom"].Value = prenom;
            cmdSql.Parameters.Add("sexe", MySqlDbType.String);
            cmdSql.Parameters["sexe"].Value = sexe;
            cmdSql.Parameters.Add("cadre", MySqlDbType.Byte);
            cmdSql.Parameters["cadre"].Value = cadre;
            cmdSql.Parameters.Add("salaire", MySqlDbType.Decimal);
            cmdSql.Parameters["salaire"].Value = salaire;
            cmdSql.Parameters.Add("emp_service", MySqlDbType.Decimal);
            cmdSql.Parameters["emp_service"].Value = emp_service;

            cmdSql.Prepare();

            cmdSql.ExecuteScalar();
            

            this.cnx.Close();
        }


        //Requete 7
        public string BacLic()
        {


            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;

            cmdSql.CommandText = "baclic";
            cmdSql.CommandType = CommandType.StoredProcedure;
            
            cmdSql.Prepare();
            
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0} {1}\n", reader[0], reader[1]);
            }
            

            this.cnx.Close();
            return result;
        }

        //Requete 8
        public string Borne(int inf, int sup)
        {

            string result = "";


            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;

            cmdSql.CommandText = "borne";
            cmdSql.CommandType = CommandType.StoredProcedure;

            cmdSql.Parameters.Add("borneInf", MySqlDbType.Int32);
            cmdSql.Parameters["borneInf"].Value = inf;
            cmdSql.Parameters.Add("borneSup", MySqlDbType.Int32);
            cmdSql.Parameters["borneSup"].Value = sup;

            cmdSql.Prepare();


            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0} {1}\n", reader[0], reader[1]);
            }


            this.cnx.Close();

            return result;
        }


        //Requete 9
        public void UpDateService(int numero, double pourcentage)
        {



            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;

            cmdSql.CommandText = "updateService";
            cmdSql.CommandType = CommandType.StoredProcedure;

            cmdSql.Parameters.Add("numero", MySqlDbType.Double);
            cmdSql.Parameters["numero"].Value = numero;
            cmdSql.Parameters.Add("pourcentage", MySqlDbType.Double);
            cmdSql.Parameters["pourcentage"].Value = pourcentage;

            cmdSql.Prepare();

            cmdSql.ExecuteNonQuery();


            this.cnx.Close();
        }

        //Requete 10
        public string MoyenneDiplome()
        {
            string result = "";


            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;

            cmdSql.CommandText = "MoyenneDiplome";
            cmdSql.CommandType = CommandType.StoredProcedure;


            cmdSql.Prepare();


            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0} {1}\n", reader[0], reader[1]);
            }


            this.cnx.Close();
            return result;
        }





    }
}
