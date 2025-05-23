﻿using Petfolio.Communication.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfolio.Communication.Responses
{
    public class ResponsePetJson
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        public PetTypes Type { get; set; }
    }
}
