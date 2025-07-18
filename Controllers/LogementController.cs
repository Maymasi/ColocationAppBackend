﻿using ColocationAppBackend.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColocationAppBackend.Controllers
{
    [Authorize(Roles = "Administrateur")]
    [ApiController]
    [Route("api/[controller]")]
    public class LogementController: ControllerBase
    {
        private readonly LogementService _logementService;
        public LogementController (LogementService logementService)
        {
            _logementService = logementService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var utilisateurs = await _logementService.GetAllLogementsAsync();
            return Ok(utilisateurs);
        }
        [Route("DeleteProperiete")]
        [HttpPost]
        public async Task<IActionResult> DeletePropriete([FromQuery] int PropId)
        {
            var idDeleted = await _logementService.DeleteProperiete(PropId);
            return Ok(idDeleted);
        }
    }

}
