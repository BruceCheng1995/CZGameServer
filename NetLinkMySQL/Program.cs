using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NetLinkMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connecrStr = "server=127.0.0.1;port=3306;database=gamedatabase;user =root;password=root";
            MySqlConnection c = new MySqlConnection(connecrStr);
            try
            {
                //read(c);
                //insert(c);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                c.Clone();
            }
        }

        private static void Insert(MySqlConnection c)
        {
            c.Open();
            string sql = "INSERT INTO `gamedatabase`.`users` (`username`, `password`, `registerdate`) VALUES ('asd', 'zxc', '2018-10-21');";
            MySqlCommand cmd = new MySqlCommand(sql, c);
            var result = cmd.ExecuteNonQuery();


        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="c">链接对象</param>
        private static void Resd(MySqlConnection c)
        {
            c.Open();
            string sql = "select *from users";
            MySqlCommand cmd = new MySqlCommand(sql, c);

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
            reader.Read();
            Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());

            Console.WriteLine("已经建立链接");
        }
    }
}
