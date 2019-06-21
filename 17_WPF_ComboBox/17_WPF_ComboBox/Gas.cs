using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_WPF_ComboBox
{
    public class Gas
    {
        public string GasName { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{GasName}";
        }
    }
}
