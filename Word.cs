using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishProject
{
    internal class Word
    {
        public int WordID { get; set; }
        public string wordTR { get; set; }
        public string wordEN { get; set; }
        public string wordSentence { get; set; }
        public bool isLearning { get; set; }
        public int userID { get; set; }
        public DateTime replyDate { get; set; }
    }
}
