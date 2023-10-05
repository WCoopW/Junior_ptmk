using Junior_ptmk.DB.DbContexts;
using Junior_ptmk.DB.Model;
using Junior_ptmk.DB.Repo;
using Junior_ptmk.ParseCMD;
using System.Diagnostics;

namespace Junior_ptmk
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var start = new ArgsCMD();
            start.EnableProgram(args);
        }
    }
}
