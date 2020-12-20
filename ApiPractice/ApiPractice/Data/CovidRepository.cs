using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ApiPractice.Data
{
    public class CovidRepository: ICovidRepository
    {
        private readonly PracticeCovidContext _context;
        public CovidRepository(PracticeCovidContext context)
        {
            _context = context;
        }

        public void AddGloabalCases(GlobalCases obj)
        {
            _context.GlobalCases.Add(obj);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<GlobalCases[]> GetAllGlobalCasesAsync()
        {
            IQueryable<GlobalCases> query = _context.GlobalCases;
            return await query.ToArrayAsync();
        }

        public async Task<NumCasesPerCountry[]> GetNumCasesPerCountryAsync()
        {
            IQueryable<NumCasesPerCountry> query = _context.NumCasesPerCountry;
            return await query.ToArrayAsync();

        }

        public async Task<PercentCases[]> GetPercentcasesAsync()
        {
            IQueryable<PercentCases> query = _context.PercentCases;
            return await query.ToArrayAsync();
        }

        public async Task<GlobalCases> GetGlobalCaseAsync(int id)
        {
            IQueryable<GlobalCases> query = _context.GlobalCases.Where(obj => obj.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<NumCasesPerCountry> GetNumCasePerCountryAsync(int id)
        {
            IQueryable<NumCasesPerCountry> query = _context.NumCasesPerCountry.Where(obj => obj.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<PercentCases> GetPercentCaseAsync(int id)
        {
            IQueryable<PercentCases> query = _context.PercentCases.Where(obj => obj.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public void RemoveGlobalCases(GlobalCases obj)
        {
            _context.GlobalCases.Remove(obj);
        }


    }
}