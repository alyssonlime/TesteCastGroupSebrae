using API.Interface.Service;
using API.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace API.Entity.Service
{
    public class CEPService : ICEPService
    {
        public async Task<ViaCepEndereco> ConsultarAsync(string cep)
        {
            using var client = new RestClient("http://viacep.com.br/");

            var request = new RestRequest("ws/" + cep + "/json/", Method.Get);

            var response = await client.ExecuteGetAsync(request);

            response.ThrowIfError();

            var status = JsonConvert.DeserializeObject<ViaCepStatus>(response.Content);

            if (status.Erro)
            {
                throw new BadHttpRequestException("Cep não encontrado");
            }

            var endereco = JsonConvert.DeserializeObject<ViaCepEndereco>(response.Content);

            return endereco;
        }
    }
}
