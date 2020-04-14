using RestApi.DTO.Auth;
using RestApi.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestApi.DataLoader.Auth
{
    public class AuthDataLoader
    {
        public bool CheckLogin(UserData user)
        {
            bool isAuthed = false;

            var dbUser = GetUser(user);

            dbUser.Password = AesEncDec.Decrypt(dbUser.Password);

            if (user != null && dbUser != null && user.UserName == dbUser.UserName && user.Password == dbUser.Password)
            {
                isAuthed = true;
            }

            return isAuthed;
        }

        private UserData GetUser(UserData user)
        {
            UserData dbUser = new UserData();
            string connetionString = @"Data Source=ASHAN\SQLEXPRESS;Initial Catalog=ISECURE;Trusted_Connection=True";
            SqlConnection cnn = null;

            try
            {
                var sqlQuery = SqlQueryStringReader.GetSqlQuery("GetUser", "Auth");

                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command = new SqlCommand(sqlQuery, cnn);
                command.Parameters.Add(new SqlParameter("@Username", user.UserName));

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dbUser.UserName = reader["Username"].ToString();
                    dbUser.Password = reader["Password"].ToString();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                if(cnn != null)
                {
                    cnn.Close();
                }
            }

            return dbUser;   
        }

        public bool CreateUser(UserData user)
        {
            bool isCrated = false;
           
            user.Password = AesEncDec.Encrypt(user.Password);

            var dbUser = GetCreatedUser(user);

            if (dbUser != null)
            {
                isCrated = true;
            }

            return isCrated;
        }

        private UserData GetCreatedUser(UserData user)
        {
            UserData dbUser = new UserData();
            string connetionString = @"Data Source=ASHAN\SQLEXPRESS;Initial Catalog=ISECURE;Trusted_Connection=True";
            SqlConnection cnn = null;

            try
            {
                var sqlQuery = SqlQueryStringReader.GetSqlQuery("CreateUser", "Auth");

                cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command = new SqlCommand(sqlQuery, cnn);
                command.Parameters.Add(new SqlParameter("@Username", user.UserName));
                command.Parameters.Add(new SqlParameter("@Password", user.Password));

                command.ExecuteNonQuery();

                return user;
            }
            catch (Exception ex)
            {
                return dbUser;
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }
        }
    }
}