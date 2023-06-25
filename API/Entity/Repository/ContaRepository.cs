using API.Entity.Model;
using API.Interface.Reporitory;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace API.Entity.Repository
{
    public class ContaRepository : IContaRepository
    {
        protected readonly AppDbContext _dbContext;

        public ContaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarAsync(Conta conta)
        {
            _dbContext.Conta.Add(conta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Conta> ObterPorIDAsync(int id)
        {
            return await _dbContext.Conta.FindAsync(id);
        }

        public async Task<IEnumerable<Conta>> ObterTodosAsync()
        {
            return await _dbContext.Conta.ToListAsync();
        }

        public async Task AtualizarAsync(Conta conta)
        {
            _dbContext.Entry(conta).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirAsync(Conta conta)
        {
            _dbContext.Conta.Remove(conta);
            await _dbContext.SaveChangesAsync();
        }
    }
}
