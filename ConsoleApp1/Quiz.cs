using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<Question>();
        }
    }
}
