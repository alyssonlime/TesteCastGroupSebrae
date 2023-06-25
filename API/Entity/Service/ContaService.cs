using API.Entity.Model;
using API.Interface.Reporitory;
using API.Interface.Service;
using System.Drawing;

namespace API.Entity.Service
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repository;

        public ContaService(IContaRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarAsync(Conta conta)
        {
            await _repository.AdicionarAsync(conta);
        }

        public async Task AtualizarAsync(Conta conta)
        {
            await _repository.AtualizarAsync(conta);
        }

        public async Task ExcluirAsync(int id)
        {
            var conta = await _repository.ObterPorIDAsync(id);
            await _repository.ExcluirAsync(conta);
        }

        public async Task<Conta> ObterPorIDAsync(int id)
        {
            return await _repository.ObterPorIDAsync(id);
        }

        public async Task<IEnumerable<Conta>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}
