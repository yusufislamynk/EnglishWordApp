using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishProject
{
    internal class Word
    {
        public int WordID { get; set; }// Kelimenin ID'si
        public string wordTR { get; set; }// Türkçe kelime
        public string wordEN { get; set; }// İngilizce kelime
        public string wordSentence { get; set; } // Kelimenin cümle içinde kullanımı
        public bool isLearning { get; set; }// Kelimenin öğrenilip öğrenilmediği durumu
        public int userID { get; set; }// Kullanıcı ID'si
        public DateTime replyDate { get; set; }// Kelimenin tekrar tarihi
    }
}
