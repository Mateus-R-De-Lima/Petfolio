namespace Petfolio.Communication.Responses
{
    public class ResponseErrosJson
    {
        public List<string> Erros { get; set; } = [];

        public ResponseErrosJson(string errorMensagem)
        {
            Erros = [errorMensagem];
        }

        public ResponseErrosJson(List<string> errorMensagens)
        {
                Erros = errorMensagens;
        }
    }
}
