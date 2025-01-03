﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Template
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("<log>");
                sb.AppendLine(" <date>{0}</date>");
                sb.AppendLine(" <level>{1}</level>");
                sb.AppendLine(" <message>{2}</message>");
                sb.AppendLine("</log>");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
