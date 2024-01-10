using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace DentalClinicManagement
{
    public class DB
    {
        private static DB? _instance = null;
        private SqlConnection? _connection = null;

        //public string ConnectionString { get; set; } = "Server=DESKTOP-8IL3H18\\SQLEXPRESS01;Database=ImportExcel;Integrated Security=True;";

        // 21120082_PhanQuocHuy's ConnectionString
        //public string ConnectionString { get; set; } = "Server=YANGGGGG\\TESTDB;Database=QLPhongKhamNhaKhoa;Integrated Security=True;";

        public string ConnectionString { get; set; } = "Server=LAPTOP-PRB0VQ46;Database=QLPhongKhamNhaKhoa;Integrated Security=True;";


        public string tableName = "QLPhongKhamNhaKhoa";
        public void ImportDataToSQL()
        {
        }

        public SqlConnection? Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(ConnectionString);
                    _connection.Open();
                }

                return _connection;
            }
        }

        // Chuỗi kết nối với tùy chọn Windows Authentication

        public static DB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DB();
                }

                return _instance;
            }
        }
    }
}
