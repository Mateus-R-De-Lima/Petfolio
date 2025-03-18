using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfolio.Application.UseCases.Pets.Update
{
    public class UpdatePetUseCase
    {
        public ResponseRegisterPetJson Execute(RequestPetJson request)
        {
            return new ResponseRegisterPetJson()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
        }
    }
}
