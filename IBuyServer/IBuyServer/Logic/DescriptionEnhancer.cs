using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace IBuyServer.Logic
{
    public class DescriptionEnhancer
    {
        public string AddTheBestAfterEverySecondWord(string source)
        {
            string[] words = source.Split(' ');
            var sb = new StringBuilder();
            sb.Append("");
            for (int i = 0; i < words.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append("The Best ");
                }
                sb.Append(words[i]);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}