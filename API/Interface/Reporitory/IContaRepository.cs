using API.Entity.Model;

namespace API.Interface.Reporitory
{
    public interface IContaRepository
    {
        Task AdicionarAsync(Conta conta);
        Task<Conta> ObterPorIDAsync(int id);
        Task<IEnumerable<Conta>> ObterTodosAsync();
        Task AtualizarAsync(Conta conta);
        Task ExcluirAsync(Conta conta);
    }
}
