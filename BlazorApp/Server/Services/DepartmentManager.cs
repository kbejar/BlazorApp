using BlazorApp.Server.Interfaces;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Services
{
    public class DepartmentManager : IDepartment
    {
        readonly DatabaseContext _dbContext = new();

        public DepartmentManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Department> GetDepartmentDetails()
        {
            try
            {
                return _dbContext.Departments.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddDepartment(Department department)
        {
            try
            {
                _dbContext.Departments.Add(department);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateDepartmentDetails(Department department)
        {
            try
            {
                _dbContext.Entry(department).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Department GetDepartmentData(int id)
        {
            try
            {
                Department? department = _dbContext.Departments.Find(id);

                if (department != null)
                {
                    return department;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular user    
        public void DeleteDepartment(int id)
        {
            try
            {
                Department? department = _dbContext.Departments.Find(id);

                if (department != null)
                {
                    _dbContext.Departments.Remove(department);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
