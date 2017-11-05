using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base
{
    public static class GlobalVariables
    {

#if SITG1
        public const string ContentPath = "Data\\GE1\\";
#elif SITG2
        public const string ContentPath = "Data\\GE2\\";
#elif SITG3
        public const string ContentPath = "Data\\GE3\\";
#elif SITG4
        public const string ContentPath = "Data\\GE4\\";
#elif PROD
        public const string ContentPath = "Data\\PROD\\";
#endif


        static GlobalVariables()
        {

        }

    }

}
