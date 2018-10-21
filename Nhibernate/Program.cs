using NHibernate;
using NHibernate.Cfg;
using NHiberToMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHiberToMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();
            cfg.Configure();//解析配置文件
            cfg.AddAssembly("NHiberToMySQL");

            ISessionFactory sessionFactory = null;
            ISession session = null;
            try
            {
                sessionFactory = cfg.BuildSessionFactory();
                session = sessionFactory.OpenSession();//开启和数据库的一个会话
                User user = new User() { Username = "asdasd", Password = "asdasd" };
                session.Save(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (session != null)
                {
                    session.Close();
                }
                if (sessionFactory != null)
                {
                    sessionFactory.Close();
                }
            }
        }
    }
}
