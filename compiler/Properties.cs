using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baja
{
    public class Properties
    {
        public int WarnLevel { get; set; }
        public int OptLevel { get; set; }
        public string Name { get; set; }
        public int FileCount { get; set; }

        public Properties()
        {
            // Set the default types for Compiler options
            WarnLevel = 0;
            OptLevel = 0;
            Name = "NewProject";
            FileCount = 0;
        }
    }
}
