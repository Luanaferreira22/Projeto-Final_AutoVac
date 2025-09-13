using SQLite;
using VacinaApp.Models;

namespace VacinaApp.Data
{
    public class UsuarioRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public UsuarioRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task Init()
        {
            await _database.CreateTableAsync<Usuario>();
        }

        public Task<List<Usuario>> GetAllAsync()
        {
            return _database.Table<Usuario>().ToListAsync();
        }

        public Task<int> AddAsync(Usuario usuario)
        {
            return _database.InsertAsync(usuario);
        }

        public Task<int> UpdateAsync(Usuario usuario)
        {
            return _database.UpdateAsync(usuario);
        }

        public Task<int> DeleteAsync(Usuario usuario)
        {
            return _database.DeleteAsync(usuario);
        }

        public Task<Usuario> GetByIdAsync(int id)
        {
            return _database.Table<Usuario>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task<Usuario> GetByEmailAsync(string email)
        {
            return _database.Table<Usuario>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        // ADICIONE ESTE MÉTODO - GetByLoginAsync
        public Task<Usuario> GetByLoginAsync(string email, string senha)
        {
            return _database.Table<Usuario>()
                .Where(u => u.Email == email && u.Senha == senha)
                .FirstOrDefaultAsync();
        }

        // Método alternativo de autenticação (já existente)
        public Task<Usuario> AuthenticateAsync(string email, string senha)
        {
            return _database.Table<Usuario>()
                .Where(u => u.Email == email && u.Senha == senha)
                .FirstOrDefaultAsync();
        }
    }
}