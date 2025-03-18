using Petfolio.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfolio.Application.UseCases.Pets.GetAll
{
    public class GetAllPetsUseCase
    {

        public ResponseAllPetJson Execute()
        {
            return new ResponseAllPetJson()
            {
                Pets = new List<ResponseShotPetJson>()
                {
                    new ResponseShotPetJson
                    {
                        Id = Guid.NewGuid(),   
                        Name = "name",
                        Type = Communication.Enuns.PetTypes.Dog
                    }
                }
            };
        }
    }
}
