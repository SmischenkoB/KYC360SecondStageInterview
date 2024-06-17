using DAL;
using DAL.Entities;
using DAL.Repositories;
using KYC360SecondStageInterview.Services;
using Microsoft.AspNetCore.Mvc;

namespace KYC360SecondStageInterview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly ICrudService<Entity> _entityService;
        private readonly ILogger<EntityController> _logger;

        public EntityController(ICrudService<Entity> entityService, ILogger<EntityController> logger)
        {
            _entityService = entityService;
            _logger = logger;
        }

        [HttpGet("GetAll")]

        public async Task<IEnumerable<Entity>>? GetAll(int limit, int skip)
        {
            try
            {
                return await _entityService.GetAll(new GetRequest<Entity>() {Take = limit, Skip = skip});

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                // to cover stack trace from being exposed to api response
                throw new Exception(e.Message);
            }
        } 

        [HttpGet("{id}")]
        public async Task<Entity>? Get(int id)
        {
            try
            {
                return await _entityService.Get(id.ToString()); 
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                // to cover stack trace from being exposed to api response
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<Entity> Post(Entity entity)
        {
            try
            {
                return await _entityService.Post(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                // to cover stack trace from being exposed to api response
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<Entity>? Put(Entity entity)
        {
            try
            {
                return await _entityService.Put(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                // to cover stack trace from being exposed to api response
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _entityService.Delete(id.ToString());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                // to cover stack trace from being exposed to api response
                throw new Exception(e.Message);
            }
        }
    }
}
