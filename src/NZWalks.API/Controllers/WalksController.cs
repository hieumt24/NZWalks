using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Models.Request;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    // api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkReposioty walkReposioty;

        public WalksController(IMapper mapper, IWalkReposioty walkReposioty)
        {
            this.mapper = mapper;
            this.walkReposioty = walkReposioty;
        }

        //CREATE Walk
        //POST : /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map Dto to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkReposioty.CreateAsync(walkDomainModel);

            //Map Domain Model to Dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //Get Walk
        //Get : api/walks?filterOn=Name&&filterQuerry=Track&&sortBy=Name&&isAscending=true&&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
                                                    [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
                                                    [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walkDomainModel = await walkReposioty.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true,
                pageNumber, pageSize);

            //Map Domain Model to Dto
            return Ok(mapper.Map<List<WalkDto>>(walkDomainModel));
            //return Ok(walkDomainModel);
        }

        //Get Walk By Id
        //GET : /api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkReposioty.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //Map walkDomainModel to walkDto

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Update Walk By Id
        // PUT: /api/Walk/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await walkReposioty.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain model to Dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //Delete a Walk By Id
        // Delete : /api/Walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkReposioty.DeleteAsync(id);
            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to Dto

            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}