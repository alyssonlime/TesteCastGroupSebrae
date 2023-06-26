using WEB.Entity;

namespace WEB.Interface
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
