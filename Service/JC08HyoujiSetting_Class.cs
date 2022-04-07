﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Common;

namespace Service
{
    public class JC08HyoujiSetting_Class
    {
        //MySqlConnection M_con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);

        public string loginId { get; set; }

        public void ReadConn()

        //MySqlConnection con = new MySqlConnection("Server=" + DBUtilitycs.Server + "; Database=" + DBUtilitycs.Database + "; User Id=" + DBUtilitycs.user + "; password=" + DBUtilitycs.pass);
        public DataTable HyoujiData(string sqlstring)
        {
            ReadConn();
            DataTable dt = new DataTable();
            using (MySqlDataAdapter adap = new MySqlDataAdapter(sqlstring, con))
            {
                adap.Fill(dt);
            }
            return dt;
        }
        public void updateHyoujiListSql(string sqlStr)
        {
            ReadConn();
            MySqlCommand myCommand = new MySqlCommand(sqlStr, con);
            con.Open();
            myCommand.ExecuteNonQuery();
            con.Close();

            //return fret;
        }
    }
}