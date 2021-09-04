using IOScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTourney
{
    /// <summary>
    /// Assumptions:
    /// 1. Experiences and skills are non-negative integers.
    /// 2. Court types on the input JSON are either "clay", "grass" or "hard".
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IO.ReadInputJSON();
        }
    }
}
