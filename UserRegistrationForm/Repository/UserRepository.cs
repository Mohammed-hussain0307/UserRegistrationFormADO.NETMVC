using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserRegistrationForm.Models;

namespace UserRegistrationForm.Repository
{
	public class UserRepository
	{
		private SqlConnection sqlConnection;
		List<UserModel> userModels = new List<UserModel>();
		public UserRepository()
		{
			string connection = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
			sqlConnection = new SqlConnection(connection);
		}
		public List<UserModel> GetUsers()
		{
			using (sqlConnection)
			{
				SqlCommand sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.CommandText = "sp_GetAllUsers";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();

				sqlConnection.Open();
				sqlDataAdapter.Fill(dataTable);
				sqlConnection.Close();

				foreach(DataRow dataRow in dataTable.Rows)
				{
					userModels.Add(new UserModel
					{
						Id = Convert.ToInt32(dataRow["id"]),
						FirstName = dataRow["first_name"].ToString(),
						LastName = dataRow["last_name"].ToString(),
						DataOfBirth = dataRow["date_of_birth"].ToString(),
						Gender = dataRow["gender"].ToString(),
						MobileNumber = dataRow["phone_number"].ToString(),
						EmailAddress = dataRow["email_address"].ToString(),
						Address = dataRow["address"].ToString(),
						City = dataRow["city"].ToString(),
						State = dataRow["state"].ToString(),
						UserName = dataRow["user_name"].ToString(),
						PassWord = dataRow["password"].ToString()
					});
                }
				return userModels;
            }
		}

		public bool CreateUser(UserModel userModel)
		{
			int check = 0;

			using (sqlConnection)
			{
				SqlCommand sqlCommand = new SqlCommand("sp_InsertUser", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.AddWithValue("@FirstName", userModel.FirstName);
				sqlCommand.Parameters.AddWithValue("@LastName", userModel.LastName);
				sqlCommand.Parameters.AddWithValue("@DateOfBirth", userModel.DataOfBirth);
				sqlCommand.Parameters.AddWithValue("@Gender", userModel.Gender);
				sqlCommand.Parameters.AddWithValue("@PhoneNumber", userModel.MobileNumber);
				sqlCommand.Parameters.AddWithValue("@EmailAddress", userModel.EmailAddress);
				sqlCommand.Parameters.AddWithValue("@Address", userModel.Address);
				sqlCommand.Parameters.AddWithValue("@City", userModel.City);
				sqlCommand.Parameters.AddWithValue("@State", userModel.State);
				sqlCommand.Parameters.AddWithValue("@UserName", userModel.UserName);
				sqlCommand.Parameters.AddWithValue("@Password", userModel.PassWord);

				sqlConnection.Open();
				check = sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			return check > 0;
		}

		//Get user by ID
		public List<UserModel> GetUserById(int id)
		{
			using (sqlConnection)
			{
				SqlCommand sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandText = "sp_GetUserById";
				sqlCommand.Parameters.AddWithValue("@Id", id);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();

				sqlConnection.Open();
				sqlDataAdapter.Fill(dataTable);
				sqlConnection.Close();

				foreach(DataRow dataRow in dataTable.Rows)
				{
					userModels.Add(new UserModel
					{
						FirstName = dataRow["first_name"].ToString(),
						LastName = dataRow["last_name"].ToString(),
                        DataOfBirth = dataRow["date_of_birth"].ToString(),
                        Gender = dataRow["gender"].ToString(),
                        MobileNumber = dataRow["phone_number"].ToString(),
                        EmailAddress = dataRow["email_address"].ToString(),
                        Address = dataRow["address"].ToString(),
                        City = dataRow["city"].ToString(),
                        State = dataRow["state"].ToString(),
                        UserName = dataRow["user_name"].ToString(),
                        PassWord = dataRow["password"].ToString()
                    });
				}
            }
			return userModels;
		}

		public bool UpdateUser(UserModel userModel)
		{
			int check = 0;

			using (sqlConnection)
			{
				SqlCommand sqlCommand = new SqlCommand("sp_UpdateUser", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.AddWithValue("@Id", userModel.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", userModel.LastName);
                sqlCommand.Parameters.AddWithValue("@DateOfBirth", userModel.DataOfBirth);
                sqlCommand.Parameters.AddWithValue("@Gender", userModel.Gender);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", userModel.MobileNumber);
                sqlCommand.Parameters.AddWithValue("@EmailAddress", userModel.EmailAddress);
                sqlCommand.Parameters.AddWithValue("@Address", userModel.Address);
                sqlCommand.Parameters.AddWithValue("@City", userModel.City);
                sqlCommand.Parameters.AddWithValue("@State", userModel.State);
                sqlCommand.Parameters.AddWithValue("@UserName", userModel.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", userModel.PassWord);

				sqlConnection.Open();
				check = sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
            }
			return check > 0;
		}

		//Delete user detail
		public bool DeleteUser(int id)
		{
			int check = 0;

			using (sqlConnection)
			{
				SqlCommand sqlCommand = new SqlCommand("sp_DeleteUser", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.Parameters.AddWithValue("@Id", id);

				sqlConnection.Open();
				check = sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			return check > 0;
		}
	}
}