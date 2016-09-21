using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XSqlLiteAppMobile.Classes
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;


        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();

            connection = new SQLiteConnection(config.Platform, Path.Combine(config.DirectoryDB, "Employess.db3"));

            connection.CreateTable<Employee>();
        }


        //Método Generico:
        public void Insert<T>(T model)
        {
            connection.Insert(model);
        }


        public void Update<T>(T model)
        {
            connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            connection.Delete(model);
        }


        //BUscar por clave primaria:
        //metodo no generico:
        //public Employee FindEmployee(int employeeId)
        //{
        //    return connection.Table<Employee>().Where(e=>e.EmployeeId == employeeId).FirstOrDefault();
        //}

        //Metodo generico:
        public T Find<T>(int id) where T : class
        {
            return connection.Table<T>().Where(model => model.GetHashCode() == id).FirstOrDefault();
        }

        //método normal;
        //public void InsertInployee(Employee employee)
        //{
        //    connection.Insert(employee);
        //}


          public T First<T>() where T : class
        {
            return connection.Table<T>().FirstOrDefault();
        }

        public List<T> GetList<T>() where T : class
        {
            return connection.Table<T>().ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
