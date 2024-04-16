using BlazorApp.Server.Interfaces;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Services
{
    public class CompanyManager : ICompany
    {
        readonly DatabaseContext _dbContext = new();

        public CompanyManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Company> GetCompanyDetails()
        {
            try
            {
                return _dbContext.Companies.ToList();
            }
            catch
            {
                throw;
            }
        }
   
        public void AddCompany(Company company)
        {
            try
            {
                _dbContext.Companies.Add(company);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
  
        public void UpdateCompanyDetails(Company company)
        {
            try
            {
                _dbContext.Entry(company).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
   
        public Company GetCompanyData(int id)
        {
            try
            {
                Company? company = _dbContext.Companies.Find(id);

                if (company != null)
                {
                    return company;
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
        public void DeleteCompany(int id)
        {
            try
            {
                Company? company = _dbContext.Companies.Find(id);

                if (company != null)
                {
                    _dbContext.Companies.Remove(company);
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
