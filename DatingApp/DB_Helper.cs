using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatingApp
{
    public class DB_Helper
    {
        public SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-NL5KD07\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=db_Dating");

        //********************** - Til Login - ********************************
        public UserModel select_stuff(string user, string pass)
        {
            UserModel temp = new UserModel();

            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Users WHERE Brugernavn = '" + user+"' AND Password ='" + pass + "'", connection))
            {
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        temp.ID = read.GetInt32(0);
                        temp.Fornavn = read.GetString(1);
                        temp.Efternavn = read.GetString(2);
                        temp.Brugernavn = read.GetString(3);
                        temp.Password = read.GetString(4);
                        temp.Email = read.GetString(5);
                        temp.isAdmin = read.GetBoolean(6);
                        temp.loggedIn = true;
                    }
                    else
                    {
                        temp.loggedIn = false;
                    }
                }
            }
            connection.Close();
            return temp; 
        }

        public spModel select_SearchProfile(int userID)
        {
            spModel temp = new spModel();

            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_Search_Profile WHERE fk_USER = '" + userID + "'", connection))
            {
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        temp.Smoker = read.GetByte(2);
                        temp.Gender = read.GetInt32(3);
                        temp.minBday = read.GetDateTime(4).ToString();
                        temp.maxBday = read.GetDateTime(5).ToString();
                    }
                    else
                    {
                        Console.WriteLine("Mistakes WHere made");
                        Console.ReadKey();
                    }
                }
            }

            connection.Close();
            return temp;

        }


        //-------------------Select statement (Profile Text)
        public string select_stuff(int ID)
        {
            string profiletekst;

            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT tbl_Profile.Profiltekst FROM tbl_Users INNER JOIN tbl_Profile ON tbl_Profile.fk_User = tbl_Users.ID WHERE tbl_Users.ID ='" + ID + "'", connection))
            {
                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        profiletekst = read.GetString(0);
                    }
                    else
                    {
                        profiletekst = "You currently dont have a profile text entry";
                    }
                }
            }

            connection.Close();
            return profiletekst; 
        }

        //----------------- Update Profile Text---------
        public string Update_stuff(string profileText, int userLogged)
        {
            connection.Open();

            using (SqlCommand cmd =
            new SqlCommand("UPDATE tbl_Profile SET Profiltekst='" + profileText + "' WHERE fk_User='" + userLogged + "'", connection))
            {
                cmd.Parameters.AddWithValue("@Profiltekst", profileText);
                cmd.ExecuteNonQuery();
            }

            connection.Close();

            string response = "This went well";

            return response;

        }



    }
}
