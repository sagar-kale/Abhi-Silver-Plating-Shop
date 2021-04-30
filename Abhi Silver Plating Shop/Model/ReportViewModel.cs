using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abhi_Silver_Plating_Shop.Model
{
    public class ReportViewModel<T>
    {

        public string Name { get; set; }
        public T Obj { get; set; }
    }
}
