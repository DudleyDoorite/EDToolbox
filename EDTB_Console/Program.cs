using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTB_Console
{
    class Program
    {
        static string JournalFile = @"C:\Dev\ED\Journal.180430195455.01.log";
        static void Main(string[] args)
        {
            Journal.JournalReader reader = new Journal.JournalReader(JournalFile);
            reader.JournalEventFound += Reader_JournalEventFound;
            reader.ScanJournal();


            Hold();
        }

        private static void Hold()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to end.");
            Console.ReadKey();
        }
        private static void Reader_JournalEventFound(object sender, Journal.Events.JournalEventArg e)
        {
            Console.WriteLine(e.JournalEntry);
        }
    }
}
