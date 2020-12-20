using ApiPractice.Data;
using ApiPractice.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace ApiPractice.Controllers
{
    [RoutePrefix("api/PercentPerCountry")]
    public class PercentCasesController : ApiController
    {
        private readonly ICovidRepository _repo;
        private readonly IMapper _mapper;

        public PercentCasesController(ICovidRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var actual = await _repo.GetPercentcasesAsync();
                return Ok(_mapper.Map<IEnumerable<PercentCasesModels>>(actual));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var actual = await _repo.GetPercentCaseAsync(id);

                if (actual != null)
                {
                    return Ok(_mapper.Map<PercentCasesModels>(actual));
                }
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }

            return NotFound();
        }

    }
}