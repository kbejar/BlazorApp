using BlazorApp.Shared.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorApp.Server.Interfaces
{
    public interface ICompany
    {
        public List<Company> GetCompanyDetails();

        public void AddCompany(Company company);

        public void UpdateCompanyDetails(Company company);

        public Company GetCompanyData(int id);

        public void DeleteCompany(int id);
    }
}
