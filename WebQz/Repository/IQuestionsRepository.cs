using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebQz.Repository
{
    public interface IQuestionsRepository
    {
        public List<Models.Questions> GetQuestions();
    }
}
