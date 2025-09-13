using SQLite;
using VacinaApp.Models;

namespace VacinaApp.Data
{
    public class VacinaRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public VacinaRepository(SQLiteAsyncConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // Adicionar vacina
        public async Task<bool> AddAsync(Vacina vacina)
        {
            try
            {
                await _db.InsertAsync(vacina);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar vacina: {ex.Message}");
                return false;
            }
        }

        // Atualizar vacina
        public async Task<bool> UpdateAsync(Vacina vacina)
        {
            try
            {
                await _db.UpdateAsync(vacina);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar vacina: {ex.Message}");
                return false;
            }
        }

        // Deletar vacina
        public async Task<bool> DeleteAsync(Vacina vacina)
        {
            try
            {
                await _db.DeleteAsync(vacina);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar vacina: {ex.Message}");
                return false;
            }
        }

        // Obter todos
        public async Task<List<Vacina>> GetAllAsync()
        {
            return await _db.Table<Vacina>().ToListAsync();
        }

        // Obter por ID
        public async Task<Vacina?> GetByIdAsync(int id)
        {
            return await _db.Table<Vacina>().FirstOrDefaultAsync(v => v.Id == id);
        }

        // Obter por código (QRCode ou Código de Barras)
        public async Task<Vacina?> GetByCodigoAsync(string codigo)
        {
            return await _db.Table<Vacina>().FirstOrDefaultAsync(v => v.Codigo == codigo);
        }
    }
}
