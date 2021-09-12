using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebQz.Repository
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private List<Models.Questions> questions = new();
        public QuestionsRepository()
        {
            try
            {
                

                DBConnection.connection.Open();

                SqlCommand sqlCommand = new SqlCommand("GetAllQuestions", DBConnection.connection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                        questions.Add(new Models.Questions()
                        { 
                            Id = dataReader.GetInt32(0),
                            TextQ = dataReader.GetString(1),
                            RightAnswer = dataReader.GetString(2),
                            Answer1 = dataReader.GetString(3),
                            Answer2 = dataReader.GetString(4),
                            Answer3 = dataReader.GetString(5),
                            Answer4 = dataReader.GetString(6)
                        });
                }

                dataReader.Close();
                sqlCommand.Dispose();
                DBConnection.connection.Close();

            }
            catch (Exception) 
            {
                
                DBConnection.connection.Close();
            }
        }
        public List<Models.Questions> GetQuestions() => questions;
    }
}

