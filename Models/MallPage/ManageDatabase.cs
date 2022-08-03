using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Database
    {
        public static OracleConnection DB;

        //建立数据库连接
        public static void CreateConn()  //更改此处数据库地址即可
        {
            //124.222.1.19
            string user = "shop";
            string pwd = "jy2051914";
            string db = "124.222.1.19/helowin";
            string conStringUser = "User ID=" + user + ";password=" + pwd + ";Data Source=" + db + ";";
            //string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl))); Persist Security Info=True;User ID=c##shop;Password=jinyi123mx427;";
            DB = new OracleConnection(conStringUser);
            DB.Open();
        }

        //关闭数据库连接
        public static void CloseConn()
        {
            DB.Close();
        }

        //查询该管理员是否存在,管理员的role_rank为3
        //测试账号jy,34567,id为2004168
        public static bool IsUserExist(int UserID, string Password)
        {
            int Count;
            CreateConn();
            OracleCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select count(*) from user_info where user_id=:UserID and password=:Password and role_rank=3";
            CMD.Parameters.Add(new OracleParameter(":UserID", UserID));
            CMD.Parameters.Add(new OracleParameter(":Password", Password));
            Count = Convert.ToInt32(CMD.ExecuteScalar());
            CloseConn();
            if (Count == 0)
                return false;
            else
                return true;

        }

        //向MUser表中增加一个新用户(注册)
        //添加成功返回UserID，添加失败返回“0”
        public static string AddUser(string UserName, string UserPassword)
        {
            OracleCommand Insert = DB.CreateCommand();
            Insert.CommandText = "insert into user_info (user_name,password) values(:UserName,:UserPassword)";
            Insert.Parameters.Add(new OracleParameter(":UserName", UserName));
            Insert.Parameters.Add(new OracleParameter(":UserPassword", UserPassword));
            Insert.ExecuteNonQuery();

            OracleCommand find = DB.CreateCommand();

            find.CommandText = "select user_id from user_info where user_name=:UserName";
            find.Parameters.Add(new OracleParameter(":UserName", UserName));
            OracleDataReader Ord = find.ExecuteReader();
            string result = "0";
            while (Ord.Read())
            {
                result = Ord.GetValue(0).ToString();
            }
            CloseConn();
            return result;
        }

        //查找个人信息
        public static User FindUserInfo(string UserID)
        {
            User U = new User();
            OracleCommand Search = DB.CreateCommand();
            Search.CommandText = "select * from user_info where user_id=:UserID";
            Search.Parameters.Add(new OracleParameter(":UserID", UserID));
            OracleDataReader Ord = Search.ExecuteReader();
            while (Ord.Read())
            {
                U.UserID = UserID;
                U.UserPassword = Ord.GetValue(1).ToString();
            }
            return U;
        }
    }

}