using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperForMySql.Models;
using MySql.Data.MySqlClient;

namespace DapperForMySql
{
    class Program
    {
        static string connStr = ConfigurationManager.ConnectionStrings["renjing"].ConnectionString;

        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            #region 1. 插入
            //这里的批量插入都是伪批量，实则是生成多条插入语句。有兴趣的可以看下面的博客实现真的批量插入。
            //http://www.cnblogs.com/renjing/p/MysqlBatchAdd.html
            #region 1.0 批量插入。伪批量！
            //using (MySqlConnection conn = new MySqlConnection(connStr))
            //{
            //    for (int i = 1; i <= 1000; i++)
            //    {
            //        conn.Execute("insert into student(name,age,class_id) values(@name,@age,@class_id)", new { name = "小明" + i, age = i % 100 + 1, class_id = i % 3 + 1 });
            //        Console.WriteLine(i + ".插入成功。。。");
            //    }
            //}
            #endregion

            #region 1.2 批量插入。伪批量！
            //using (MySqlConnection conn = new MySqlConnection(connStr))
            //{
            //    var dataList = Enumerable.Range(1, 1000).Select(i => new { name="小明"+i, age = i % 100 + 1, class_id = i % 3 + 1 });

            //    int count = conn.Execute("insert into student(name,age,class_id) values(@name,@age,@class_id)", dataList);
            //    Console.WriteLine($"批量插入 {count} 条 成功！！！");
            //}
            #endregion
            #endregion

            #region 2. 查询
            #region 2.0 基本查询
            //using (MySqlConnection conn = new MySqlConnection(connStr))
            //{
            //    var students = conn.Query<Student>("select * from student;");
            //    //参数化查询
            //    //var students = conn.Query<Student>("select * from student where name=@name;", new { name = "小明13" });

            //    foreach (var item in students)
            //    {
            //        Console.WriteLine($"{item.id}\t{item.name}\t{item.age}");
            //    }
            //}
            #endregion

            #region 2.1 动态类型查询
            //using (MySqlConnection conn = new MySqlConnection(connStr))
            //{
            //    var students = conn.Query("select * from student;");

            //    foreach (var item in students)
            //    {
            //        Console.WriteLine($"{item.id}\t{item.name}\t{item.age}");
            //    }
            //} 
            #endregion

            #region 2.2 多结果查询
            //using (MySqlConnection conn = new MySqlConnection(connStr))
            //{
            //    var multi = conn.QueryMultiple("select * from student;select * from class;");

            //    var studentList = multi.Read<Student>().ToList();
            //    var classList = multi.Read<Class>().ToList();

            //    Console.WriteLine($"student:{studentList.Count} 条！");
            //    Console.WriteLine($"classList:{classList.Count} 条！");
            //}
            #endregion

            #endregion

            #region 3. 修改
            #region 3.0 修改
            //using (MySqlConnection conn = new MySqlConnection(connStr))
            //{
            //    var result = conn.Execute("update student set name=@name where id=@id;", new { name = "小明哥哥", id = 100 });

            //    Console.WriteLine("3.1 修改成功");
            //} 
            #endregion

            #endregion

            #region 4. 删除
            #region 4.1 删除
            //using (MySqlConnection conn = new MySqlConnection(connStr))
            //{
            //    var result = conn.Execute("delete from student where id=@id;", new { id = 100 });

            //    Console.WriteLine("4.1 删除成功");
            //}

            #endregion
            #endregion

            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            Console.Read();
        }
    }
}
