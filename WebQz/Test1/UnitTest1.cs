using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebQz;
using WebQz.Models;
using WebQz.Repository;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConnection()
        {
            try
            {
                DBConnection.connection.Open();
                SqlCommand SqlCommand = new SqlCommand("SELECT * FROM Questions", DBConnection.connection);
                SqlCommand.ExecuteNonQuery();
                DBConnection.connection.Close();
                Assert.AreEqual(true, true);
            }
            catch (System.Exception) 
            { 
                Assert.AreEqual(false, true); 
            }

        }

        [TestMethod]
        public void GetQuestions()
        {
            QuestionsRepository questionsRepository = new QuestionsRepository();
            List<Questions> questions = questionsRepository.GetQuestions();
            CollectionAssert.AreNotEqual(questions, new List<Questions>());
        }
    }
}
