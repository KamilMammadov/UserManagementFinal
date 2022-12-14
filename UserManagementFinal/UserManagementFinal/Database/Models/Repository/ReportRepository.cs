using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementFinal.Database.Models.Repository
{
    class ReportRepository
    {
        private static int _idCounter;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }

        }
        private static List<Report> Reports { get; set; } = new List<Report>()
        {

        };


        public static List<Report> GetReports()
        {
            return Reports;
        }

        public static Report AddReport(User fromwho, User towho, string text)
        {
            Report report = new Report(fromwho, towho, text);
            User.Reports.Add(report);
            return report;
        }
    }
}
