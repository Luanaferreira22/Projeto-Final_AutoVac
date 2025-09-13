using SQLite;
using VacinaApp.Models;

namespace VacinaApp.Data
{
    public class CarteirinhaRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public CarteirinhaRepository(SQLiteAsyncConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _db.CreateTableAsync<Carteirinha>().Wait();
        }

        // Adicionar
        public async Task<int> AddAsync(Carteirinha carteirinha)
        {
            return await _db.InsertAsync(carteirinha);
        }

        // Atualizar
        public async Task<int> UpdateAsync(Carteirinha carteirinha)
        {
            return await _db.UpdateAsync(carteirinha);
        }

        // Deletar
        public async Task<int> DeleteAsync(Carteirinha carteirinha)
        {
            return await _db.DeleteAsync(carteirinha);
        }

        // Buscar por Id
        public async Task<Carteirinha?> GetByIdAsync(int id)
        {
            return await _db.Table<Carteirinha>().FirstOrDefaultAsync(c => c.Id == id);
        }

        // Listar todas
        public async Task<List<Carteirinha>> GetAllAsync()
        {
            return await _db.Table<Carteirinha>().ToListAsync();
        }
    }
}
