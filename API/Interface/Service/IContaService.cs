using API.Entity.Model;

namespace API.Interface.Service
{
    public interface IContaService
    {
        Task AdicionarAsync(Conta conta);
        Task<Conta> ObterPorIDAsync(int id);
        Task<IEnumerable<Conta>> ObterTodosAsync();
        Task AtualizarAsync(Conta conta);
        Task ExcluirAsync(int id);
    }
}
