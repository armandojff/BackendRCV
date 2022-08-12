using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using administrador.BussinesLogic.DTOs;
using administrador.Exceptions;
using administrador.Persistence.DAOs.Interfaces;
using administrador.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using administrador.Persistence.DAOs.Implementations;
using Microsoft.AspNetCore.Identity;

namespace administrador.Controllers.Administrador
{
    [ApiController]
    [Route("Administrador")]
    public class AdministradorController : Controller
    {
        private readonly IAdministradorDAO _adminDAO;
        private readonly ILogger<AdministradorController> _logger;

        public AdministradorController(ILogger<AdministradorController> logger, IAdministradorDAO providerDAO)
        {
            //_adminDAO = AdministradorDAO;
            _logger = logger;
        }

        [HttpGet("providers/{brand}")]
        public ApplicationResponse<List<AdminDTO>> GetProvidersByBrand([Required][FromRoute] string brand)
        {
            var response = new ApplicationResponse<List<AdminDTO>>();
            try
            {
                //response.Data = _adminDAO.GetProvidersByBrand(brand);
            }
            catch (RCVExceptions ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        /*[HttpPost()]
        public ActionResult<AdminDTO> AddUser([FromBody] AdminDTO newUserToCreate)
        {
            if (string.IsNullOrEmpty(newUserToCreate.Name))
                return BadRequest(new ProblemDetails()
                {
                    Title = "Bad parameters",
                    Detail = "The name of the new user cannot be empty or null",
                    Instance = HttpContext.Request.Path
                });

            var userAlreadyExists = _userRepository.Exists(newUserToCreate.Name);
            if (userAlreadyExists)
                return Conflict(new ProblemDetails()
                {
                    Detail = "User already exists",
                    Title = "Bad parameters",
                    Instance = HttpContext.Request.Path
                });

            var newUser = new User(newUserToCreate.Name);

            _userRepository.Add(newUser);

            return Created($"/users/{newUserToCreate.Name}", UserDto.FromModel(newUser));
        }*/
    }
}