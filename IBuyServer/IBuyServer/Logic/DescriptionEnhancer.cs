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
            source = source.Trim();
            string[] words = source.Split(' ');
            var sb = new StringBuilder();
            sb.Append("");
            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[i]);
                if (i % 2 == 1)
                {
                    sb.Append(" The Best");
                }
                if (i + 1 != words.Length)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
    }

}