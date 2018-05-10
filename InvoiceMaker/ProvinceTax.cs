using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    class ProvinceTax
    {
        public String provinceTax { get; set; }
        public int gst { get; set; }
        public int pst { get; set; }

        public ProvinceTax(String provinceTax, int gst, int pst)
        {
            this.provinceTax = provinceTax;
            this.gst = gst;
            this.pst = pst;
        }
    }
}
