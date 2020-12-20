using ApiPractice.Data;
using ApiPractice.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiPractice.Controllers
{
    [RoutePrefix("api/CasesPerCountry")]
    public class NumCasesPerCountryController : ApiController
    {
        private readonly ICovidRepository _repo;
        private readonly IMapper _mapper;

        public NumCasesPerCountryController(ICovidRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var actual = await _repo.GetNumCasesPerCountryAsync();
                return Ok(_mapper.Map<IEnumerable<NumCasesPerCountryModel>>(actual));
            }

            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var actual = await _repo.GetNumCasePerCountryAsync(id);

                if (actual != null)
                {
                    return Ok(_mapper.Map<NumCasesPerCountryModel>(actual));
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return NotFound();
        }

    }
}