using FluentValidation;
using GenialNet.Application.Fornecedores.Commands.CadastrarFornecedor;
using GenialNet.Application.Fornecedores.Queries.BuscarFornecedor;
using GenialNet.Domain.Dtos;
using GenialNet.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GenialNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController: ControllerBase
    {
        private readonly ILogger<FornecedorController> _logger;
        protected IMediator _mediator;

        public FornecedorController(ILogger<FornecedorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(typeof(Fornecedor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<Guid>> CadastrarFornecedor([FromBody] CadastrarFornecedorRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);

                return result == Guid.Empty
                    ? BadRequest(new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Title = "Result not found.",
                        Detail = "The requested Fornecedor was not found.",
                        Type = nameof(Fornecedor)
                    })
                : Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { Errors = ex.Errors.Select(e => e.ErrorMessage) });
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(FornecedorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<ActionResult<FornecedorDto>> GetOne([FromQuery] Guid request)
        {
            var getRequest = new BuscarFornecedorRequest(Id: request);

            var result = await _mediator.Send(getRequest);

            return result != null
                ? result
                : BadRequest(new ProblemDetails
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Title = "Result not found.",
                    Detail = "The requested Fornecedor was not found.",
                    Type = nameof(Fornecedor)
                });
        }
    }
}
