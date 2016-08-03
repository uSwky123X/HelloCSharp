using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp
{
    class Class
    {
        public static string FileName;
        [DllImport("Compiler.dll")]
        public static extern string Compile(string SourceFile, string OutFile);

        [DllImport("Compiler.dll")]
        public static extern void Run(string File);
    }
}
