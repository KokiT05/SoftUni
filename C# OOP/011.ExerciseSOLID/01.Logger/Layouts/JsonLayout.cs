using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LoggerExercise.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Template
        {
            get
            {
                return @"""log"": {{
  ""date"": ""{0}"",    
  ""level"": ""{1}"",
  ""message"": ""{2}""
}},";
            }
        }
    }
}
