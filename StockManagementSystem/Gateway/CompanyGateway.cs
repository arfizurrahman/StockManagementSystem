using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    class CompanyGateway : Gateway
    {
        public int SaveCompany(Company company)
        {
            Query = "INSERT INTO Company (Name) VALUES('" + company.Name + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsCompanyExistes(string companyName)
        {
            Query = "SELECT * FROM Company WHERE Name = '" + companyName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        public List<Company> GetAllCompanies()
        {
            Query = "SELECT * FROM Company";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Company> companies = new List<Company>();

            while (Reader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(Reader["Id"]);
                company.Name = Reader["Name"].ToString();

                companies.Add(company);
            }
            Reader.Close();
            Connection.Close();
            return companies;
        }
    }
}
