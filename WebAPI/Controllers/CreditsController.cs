﻿using BLL.Interfaces;
using Cross_Cutting.Mapping;
using Microsoft.AspNetCore.Mvc;
using Models.Business;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/credits")]
    [ApiController]
    public class CreditsController : ControllerBase
    {
        private readonly IReadService<Credit> _creditReadService;
        private readonly IWriteService<Credit> _creditWriteService;

        public CreditsController(IReadService<Credit> crs, IWriteService<Credit> cws)
        {
            _creditReadService = crs;
            _creditWriteService = cws;
        }

        // GET: api/Credits
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var credits = new CustomMapper<Credit, CreditViewModel>().MapCollection(await _creditReadService.GetAllCredits());
            if (credits.Count() <= 0)
                return NotFound();

            return Ok(credits);
        }

        // GET: api/Credits/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            var credit = new CustomMapper<Credit, CreditViewModel>().Map(await _creditReadService.GetCreditById(id));
            if (credit == null)
                return NotFound();

            return Ok(credit);
        }

        // POST: api/Credits
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreditViewModel credit)
        {
            if (credit == null)
                return BadRequest();

            await _creditWriteService.UpsertCredit(new CustomMapper<CreditViewModel, Credit>().Map(credit));
            var state = credit.Id <= 0 ? "added" : "updated";

            return Ok($"Credit was {state}");
        }

        // DELETE: api/Credits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id.Value <= 0)
                return BadRequest();

            await _creditWriteService.RemoveCredit(id.Value);

            return Ok("Credit was deleted");
        }
    }
}
