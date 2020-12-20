using ApiPractice.Data;
using ApiPractice.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace ApiPractice.Controllers
{
    [RoutePrefix("api/GlobalCases")]
    public class GlobalCasesController : ApiController
    {
        private readonly ICovidRepository _repo;
        private readonly IMapper _mapper;
        public GlobalCasesController(ICovidRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllGlobalCasesAsync();
                
                return Ok(_mapper.Map<IEnumerable<GlobalCasesModels>>(result));
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }

        }

        [Route("{id}", Name="GetGlobalCase")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var result = await _repo.GetGlobalCaseAsync(id);

                if (result != null)
                {
                    return Ok(_mapper.Map<GlobalCasesModels>(result));
                }

            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }

            return NotFound();
        }
        
        [Route()]
        public async Task<IHttpActionResult> Post(GlobalCasesModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var actual = _mapper.Map<GlobalCases>(model);
                    _repo.AddGloabalCases(actual);

                    if (await _repo.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<GlobalCasesModels>(actual);
                        return CreatedAtRoute("GetGlobalCase", new { Id = newModel.Id},newModel);
                    }
                }
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }

            return BadRequest();
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, GlobalCasesModels model)
        {
            try
            {
                var actual = await _repo.GetGlobalCaseAsync(id);

                if (actual == null) return NotFound();

                _mapper.Map(model, actual);

                await _repo.SaveChangesAsync();
                return Ok(_mapper.Map<GlobalCasesModels>(actual));
               

            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }

  
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var actual = await _repo.GetGlobalCaseAsync(id);

                if (actual == null) return NotFound();

                _repo.RemoveGlobalCases(actual);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }

            return InternalServerError();
        }
    }
}