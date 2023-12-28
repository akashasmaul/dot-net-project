using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int, bool>, IAuth<Employee>, IFinance<int>
    {
        public Employee Authenticate(string username, string password)
        {

            var data = db.Employees.FirstOrDefault(u => u.UserName.Equals(username) && u.Password.Equals(password));
            if (data != null) return data;
            return null;
        }

        public int Count()
        {

            int totalEmployees = db.Employees.Count();
            return totalEmployees;
        }

        public bool Create(Employee obj)
        {
            db.Employees.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var data = Read(id);
            db.Employees.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Employee> Read()
        {
            return db.Employees.ToList();
        }

        public Employee Read(int id)
        {
            return db.Employees.Find(id);
        }

        public int TotalSal()
        {
            return db.Employees.Sum(employee => employee.Salary.SalaryAmount);
        }

        public bool Update(Employee obj)
        {
            var data = db.Employees.Find(obj.Id);
            obj.Password = data.Password;
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
