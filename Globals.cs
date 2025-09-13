using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor
{

    public interface ILog
    {
        public void agregar(string info);
    }

    public class ConsolaLog : ILog
    {

        private List<string> logs = new List<string>();

        public void agregar(string info)
        {
            logs.Add(info);
        }
    }

    //public static class Globals
    //{
    //    public static List<string> logs = new List<string>();
    //}
}
