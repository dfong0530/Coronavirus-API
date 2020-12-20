using ApiPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Data
{
    public interface ICovidRepository
    {
        void AddGloabalCases(GlobalCases obj);
        Task<bool> SaveChangesAsync();
        Task<GlobalCases[]> GetAllGlobalCasesAsync();
        Task<NumCasesPerCountry[]> GetNumCasesPerCountryAsync();
        Task<PercentCases[]> GetPercentcasesAsync();
        Task<GlobalCases> GetGlobalCaseAsync(int id);
        Task<NumCasesPerCountry> GetNumCasePerCountryAsync(int id);
        Task<PercentCases> GetPercentCaseAsync(int id);
        void RemoveGlobalCases(GlobalCases obj);


    }
}
