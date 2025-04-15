using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pets.Delete;
using Petfolio.Application.UseCases.Pets.GetAll;
using Petfolio.Application.UseCases.Pets.GetById;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Application.UseCases.Pets.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterPetJson),StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrosJson),StatusCodes.Status400BadRequest)]
        public IActionResult Register(RequestPetJson request)
        {
            var useCase = new RegisterPetUseCase();
            var response = useCase.Execute(request);
            return Created("",response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute]Guid id, [FromBody] RequestPetJson request)
        {
            var useCase = new UpdatePetUseCase();
            useCase.Execute(request);

            return NoContent();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllPetsUseCase();

            var response = useCase.Execute();

            if (response.Pets.Any())
            {
                return Ok(response.Pets);
            }

            return NoContent();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute] Guid id)
        {
            var useCase = new GetByIdPetUseCase();

            var response = useCase.Execute(id);

            return Ok(response);


        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrosJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeletePetByIdUseCase();

            useCase.Execute(id);

            return NoContent();


        }


    }
}
