using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee.Controller;

namespace Yahtzee
{
    class Program
    {
        static void Main(string[] args)
        {
            MasterController mc = new MasterController();

            mc.run();
        }
    }
}
