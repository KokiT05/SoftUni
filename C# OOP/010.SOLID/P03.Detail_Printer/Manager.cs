using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Description()
        {
            throw new NotImplementedException();
        }

        public override string Details()
        {
            return base.Details() + 
                $"{Environment.NewLine}" + $"Documents: {string.Join(',', this.Documents)}";
        }
    }
}
