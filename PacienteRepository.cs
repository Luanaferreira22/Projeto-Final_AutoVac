using SQLite;
using VacinaApp.Models;

namespace VacinaApp.Data
{
    public class PacienteRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public PacienteRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task Init()
        {
            await _database.CreateTableAsync<Paciente>();
        }

        public Task<List<Paciente>> GetAllAsync()
        {
            return _database.Table<Paciente>().ToListAsync();
        }

        public Task<int> AddAsync(Paciente paciente)
        {
            return _database.InsertAsync(paciente);
        }

        public Task<int> UpdateAsync(Paciente paciente)
        {
            return _database.UpdateAsync(paciente);
        }

        public Task<int> DeleteAsync(Paciente paciente)
        {
            return _database.DeleteAsync(paciente);
        }

        public Task<Paciente> GetByIdAsync(int id)
        {
            return _database.Table<Paciente>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}