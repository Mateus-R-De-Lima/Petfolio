using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;
using Petfolio.Exception.ExceptionsBase;

namespace Petfolio.Application.UseCases.Pets.Register
{
    public class RegisterPetUseCase
    {
        public ResponseRegisterPetJson Execute(RequestPetJson request)
        {
            Validate(request);
            return new ResponseRegisterPetJson
            {
                Id = Guid.NewGuid(),
                Name = request.Name,

            };
        }

        private void Validate(RequestPetJson request)
        {
            var validator = new RegisterPetValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationsException(errorMessages);
            }

        }
    }
}
