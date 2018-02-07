using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.Manager
{
    class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();

        public string SaveCompany(Company company)
        {
            if (aCompanyGateway.IsCompanyExistes(company.Name))
            {
                return "Company already exists";
            }
            else
            {
                int rowAffected = aCompanyGateway.SaveCompany(company);
                if (rowAffected > 0)
                {
                    return "Saved successfully";
                }
                return "Save failed";
            }

        }

        public List<Company> GetAllCompanies()
        {
            return aCompanyGateway.GetAllCompanies();
        }
    }
}
