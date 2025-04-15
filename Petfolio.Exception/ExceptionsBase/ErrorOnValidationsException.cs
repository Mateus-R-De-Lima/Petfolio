using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfolio.Exception.ExceptionsBase
{
    public class ErrorOnValidationsException : PetfolioException
    {
        public List<string> ErrorMensagens { get; set; }

        public ErrorOnValidationsException(List<string> errorMensagens)
        {
            ErrorMensagens = errorMensagens;
            
        }
    }
}
