using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Student_Success_Planner.Data
{
    public class DatabaseUpdate
    {
        private string Statement = "";

        public void UpdateSM(int SID, String SName, int PID, string Abr)
        {
            Statement = "UPDATE SuccessMap SET " +
                        "SMName = " + SName +
                        ", PrgmID = " + PID +
                        ", Abbr = " + Abr +
                        "WHERE SMID = " + SID;
        }

        public void InsertSM(String SName, int PID, string Abr)
        {
            Statement = "INSERT INTO SuccessMap(SMName, PrgmID, Abbr) " +
                        "VALUES('"+SName+"','"+PID+"','"+Abr+"')";
        }
    }
}
