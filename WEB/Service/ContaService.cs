using System.Net;
using System.Net.Http.Json;
using WEB.Entity;
using WEB.Interface;

namespace WEB.Service
{
    public class ContaService : IContaService
    {
        private string urlBase = "https://localhost:7047/";

        public ContaService()
        {

        }

        public async Task AdicionarAsync(Conta conta)
        {
            using var client = new HttpClient();

            var response = await client.PostAsJsonAsync<Conta>(urlBase + "Conta/", conta);

            response.EnsureSuccessStatusCode();
        }

        public async Task AtualizarAsync(Conta conta)
        {
            using var client = new HttpClient();

            var response = await client.PutAsJsonAsync<Conta>(urlBase + "Conta/", conta);

            response.EnsureSuccessStatusCode();
        }

        public async Task ExcluirAsync(int id)
        {
            using var client = new HttpClient();

            var response = await client.DeleteAsync(urlBase + "Conta/" + id);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Conta> ObterPorIDAsync(int id)
        {
            using var client = new HttpClient(); 

            var conta = await client.GetFromJsonAsync<Conta>(urlBase + "Conta/" + id);

            return conta;
        }

        public async Task<IEnumerable<Conta>> ObterTodosAsync()
        {
            using var client = new HttpClient();

            var listaContas = await client.GetFromJsonAsync<IEnumerable<Conta>>(urlBase + "Conta");

            return listaContas;
        }
    }
}
