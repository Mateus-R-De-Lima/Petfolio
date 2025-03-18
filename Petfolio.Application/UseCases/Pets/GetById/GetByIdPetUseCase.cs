using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById
{
    public class GetByIdPetUseCase
    {
        public ResponsePetJson Execute(Guid id)
        {

            return new ResponsePetJson 
            { 
                Id = id,
                Name = "Gamora", 
                Birthday = DateTime.UtcNow.AddDays(-305), 
                Type = Communication.Enuns.PetTypes.Dog
            
            };

        }
    }
}
