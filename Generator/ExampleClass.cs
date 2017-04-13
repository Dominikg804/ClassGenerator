using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class ExampleClass
    {
        int intvalue;
        float floatvalue;
        string stringvalue;
        bool boolvalue;
        int intproperty { get; set; }
        public override string ToString()
        {
            StringBuilder sbuilder = new StringBuilder();
            sbuilder.Append("\t MAIN CLASS " + "\n" + intvalue);
            sbuilder.Append("\n" + floatvalue);
            sbuilder.Append("\n" + stringvalue);
            sbuilder.Append("\n" + boolvalue);
            sbuilder.Append("\n" + intproperty);
            return sbuilder.ToString();
        }
        class newClass {
            int intvalue;
            float floatvalue;
            string stringvalue;
            bool boolvalue;
            int intproperty { get; set; }
            public override string ToString()
            {
                StringBuilder sbuilder = new StringBuilder();
                sbuilder.Append("\t SUBCLASS 1 " + "\n" + intvalue);
                sbuilder.Append("\n" + floatvalue);
                sbuilder.Append("\n" + stringvalue);
                sbuilder.Append("\n" + boolvalue);
                sbuilder.Append("\n" + intproperty);
                return sbuilder.ToString();
            }
        }
        class newClass2
        {
            int intvalue;
            float floatvalue;
            string stringvalue;
            bool boolvalue;
            int intproperty { get; set; }
            public override string ToString()
            {
                StringBuilder sbuilder = new StringBuilder();
                sbuilder.Append("\t SUBCLASS 2 " + "\n" + intvalue);
                sbuilder.Append("\n" + floatvalue);
                sbuilder.Append("\n" + stringvalue);
                sbuilder.Append("\n" + boolvalue);
                sbuilder.Append("\n" + intproperty);
                return sbuilder.ToString();
            }
        }

    }
}
