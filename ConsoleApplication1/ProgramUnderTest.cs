using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ProgramUnderTest
    {
        Random ran = new Random();
        //string[] positiveWords = { "love", "alive", "bloom", "clever", "amaze", "blessed", "eager", "peace", "relax", "welcome", "beautiful", "happy" };
        string[] positiveWords = { "ABLE", "ACTIVE", "ADORABLE", "AGELESS", "AID", "ACCOUNTABILITY", "ACCOMPLISHMENT", "ACCOMPLISH", "ACHIEVEMENT", "ACHIEVE", "ACKNOWLEDGEMENT", "ADAPTABILITY", "AMBITION", "ANTICIPATION", "APPRECIATION", "APPRECIATIVE", "APPRECIATIVENESS", "AWARE", "AWARENESS", "AUTHENTIC", "AUTHENTICITY",
            "ALLOW", "ALLOWING", "AFFECTION", "AFFECTIONATE", "ABSORBED", "ALERT", "AMAZED", "AWE", "AWED", "ANIMATE", "ANIMATED" , "GOOD", "INDWELLING", "SPIRIT", "GOOD", "WORD", "GOOD",
            "WORDS", "GOOD-HUMORED", "GOODWILL", "GOOD", "FORTUNE", "GYPSY", "SOUL", "GAME-CHANGER", "GENERATORLIFE", "GRACEFULLY", "GRACIOUSNESS", "HOPE", "HOPEFULNESS", "HEART", "HOT", "HONEST", "HONESTY", "HELPFULNESS", "HONOR", "HEAVEN", "HEAVENLY", "HALO", "HEARTWARMING", "ONE-POINTEDNESS", "HAPPY", "HEARTED",
            "HIGH-SPIRITEDNESS", "HIGHLY", "DISTINGUISHED", "HIGHLY", "DISTINGUISHED", "HARNESS", "HOLY", "SPIRIT", "IMAGINATION", "INCREDIBLE", "IMPROVEMENT", "INGENUITY", "INTEGRITY", "INTIMACY", "INTUITIVENESS", "INVESTING", "INTENTION", "INVIGORATE", "INVIGORATED", "INNOCENT", "INEFFABLE", "INVINCIBLE", "INQUISITIVE",
            "ILLUSTRIOUS", "INNER", "ICHARIBA", "CHODE", "IKIGAI", "INCREDIBLE", "CUTENESS", "INDWELLING", "INSPIRATIONAL", "WORDS", "INSPIRING", "WORD", "INSPIRING", "WORDS", "IRIDESCENT", "ILLUSTRIOUS", "INNER", "SPIRIT", "INTERCONNECTED", "INTERCONNECTIVITY", "INTUITION", "JOY", "JOYFUL", "JOYOUS", "JUST", "JUVENESCENT",
            "JUBILINGO", "KINDNESS", "KIND", "KIND-HEART", "KINDLY", "KITTENS",  "WON", "WHOLEHEARTEDNESS", "WATER", "WELFARE", "WHOLE", "WIN", "WINNABLE", "WINNING", "WALWALUN", "WEBRELATEDNESS", "WORLD-BUILDER", "WORTHINESS", "SPACE", "XO", "XENOPHILE", "YES", "YIPPEE", "YEA", "YEN", "YARAANA", "YOUR", "TRUE", "VALUE", "ZEALOUS", "ZING"};
        //string[] negativeWords = { "anxious", "fail", "evil", "ghastly", "moan", "nasty", "mean", "negative", "hard", "guilty","" };
        string[] negativeWords={"aloof", "altercation", "ambiguity", "ambiguous", "ambivalence", "ambivalent", "ambush", "amiss", "amputate", "anarchism", "anarchist", "apologists", "appall", "appalled", "appalling", "appallingly", "apprehension", "apprehensions", "apprehensive", 
            "bloody", "blotchy", "blow", "blunder", "blundering", "blunders", "blunt", "blur", "blurred", "blurring", "blurry", "blurs", "blurt", "boastful", "boggle", "bogus",
        "corrosive", "corrupt", "corrupted", "corrupting", "corruption", "corrupts", "costlier", "costly", "counter-productive", "counterproductive",
            "injure", "injurious", "injury", "injustice", "injustices", "innuendo", "inoperable", "inopportune", "inordinate", "inordinately"
        };
        string[] Words = { "I", "am", "got", "This", "The", "me", "love","let","welcome","guilty","people","God","is","clever","You" };
        public string createText(int numOfWords, int type)
        {
            //string[] Words = Word.Split();
   
            string outText = "";
            string randomWord = Words[ran.Next(0, Words.Length)];
          
            if (type == 1)
            {
                for (int i = 0; i < numOfWords; i++)
                {
                    outText += randomWord + " ";
                    randomWord = positiveWords[ran.Next(0, positiveWords.Length)];
                }
            }
            else if (type == 0)
            {
                for (int i = 0; i < numOfWords; i++)
                {
                    outText += randomWord + " ";
                    randomWord = negativeWords[ran.Next(0, negativeWords.Length)];
                }
            }
            else
            {
                for (int i = 0; i < numOfWords; i++)
                {
                    outText += randomWord + " ";
                    if (ran.Next(1,50000)%3==1)
                        randomWord = positiveWords[ran.Next(0, positiveWords.Length)];
                    else if (ran.Next(1, 50000) % 3 == 1)
                        randomWord = negativeWords[ran.Next(0, negativeWords.Length)];
                    else
                        randomWord = Words[ran.Next(0, Words.Length)];
                }
            }
          
            return outText;

        }
      
    }
    }
