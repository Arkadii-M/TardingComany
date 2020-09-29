using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL.Interfaces;
using DTO;


using System.Linq;
using System.Threading.Tasks;
namespace DAL.Concrete
{
    public class AccountDal : IAccountDal
    {
        private string connectionString;

        public AccountDal(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public AccountDTO CreateAccount(AccountDTO Account)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Account(UserLogin,UserPassword,Salt) output INSERTED.[UserID] values (@login,@password,@salt)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@login",Account.UserLogin);
                comm.Parameters.AddWithValue("@password", Account.UserPassword);
                comm.Parameters.AddWithValue("@salt", Account.Salt);
                conn.Open();
                Account.UserID = Convert.ToInt32(comm.ExecuteScalar());
                return Account;
            }

        }

        public bool DeleteAccount(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Account where UserID = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                comm.ExecuteNonQuery();
                return true;
            }
        }

        public AccountDTO GetAccountByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                
                comm.CommandText = "select * from Account where UserID = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();
                var reader = comm.ExecuteReader();

                AccountDTO to_ret = new AccountDTO { UserID = (int)reader["UserID"],
                    UserLogin = reader["UserLogin"].ToString(),
                    UserPassword = Encoding.ASCII.GetBytes(reader["UserPassword"].ToString()),
                    Salt = reader["Salt"].ToString()
                        };
                return to_ret;

            }
        }

        public List<AccountDTO> GetAllAccounts()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {

                comm.CommandText = "select * from Account";
                comm.Parameters.Clear();
                conn.Open();
                var reader = comm.ExecuteReader();
                List<AccountDTO> to_ret = new List<AccountDTO>();
                while (reader.Read())
                {
                    
                    to_ret.Add(new AccountDTO { UserID = Convert.ToInt32(reader["UserID"].ToString()),
                        UserLogin = reader["UserLogin"].ToString(),
                        UserPassword = Encoding.ASCII.GetBytes(reader["UserPassword"].ToString()),
                        Salt = reader["Salt"].ToString()
                    });
                    
                }
                reader.Close();
                return to_ret;
                
                
                    
             };

        }

        public AccountDTO UpdateAccount(AccountDTO Account)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                var to_db = this.GetAccountByID(Account.UserID);
                to_db.UserLogin = (Account.UserLogin == null) ? to_db.UserLogin : Account.UserLogin;
                to_db.UserPassword = (Account.UserPassword == null) ? to_db.UserPassword : Account.UserPassword;
                to_db.Salt = (Account.Salt == null) ? to_db.Salt : Account.Salt;

                comm.CommandText = "update Account set UserLogin = @login,UserPassword = @password,Salt = @salt where UserID = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@login", to_db.UserLogin);
                comm.Parameters.AddWithValue("@password", to_db.UserPassword);
                comm.Parameters.AddWithValue("@salt", to_db.Salt);
                comm.Parameters.AddWithValue("@id", to_db.UserID);
                conn.Open();
                return to_db;
            }
        }
    }
}
