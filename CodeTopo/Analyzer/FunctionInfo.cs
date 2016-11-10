using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTopo.Analyzer
{
    public enum AccessModifier
    {
        AccessPublic,
        AccessProtected,
        AccessPrivate,
    }

    public class FunctionInfo
    {
        public string Name { get; set; }

        public AccessModifier Modifier { get; set; }

        public int NestingLevel { get; set; }
    }
}
