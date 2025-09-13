using SQLite;
using VacinaApp.Models;

namespace VacinaApp.Data
{
    public class AppDbContext
    {
        private readonly SQLiteAsyncConnection _asyncDb;

        public AppDbContext()
        {
            // Caminho do banco
            string dbFileName = Environment.GetEnvironmentVariable("DB_PATH") ?? "vacinaapp.db3";
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbFileName);

            // Conexão assíncrona
            _asyncDb = new SQLiteAsyncConnection(dbPath);

            // Cria tabelas async
            _asyncDb.CreateTableAsync<Usuario>().Wait();
            _asyncDb.CreateTableAsync<Paciente>().Wait();
            _asyncDb.CreateTableAsync<Vacina>().Wait();
            _asyncDb.CreateTableAsync<Carteirinha>().Wait();
        }

        // Expõe apenas a conexão assíncrona
        public SQLiteAsyncConnection Connection => _asyncDb;

        // Método para resetar o banco (útil em dev/teste)
        public async Task ResetDatabaseAsync()
        {
            await _asyncDb.DropTableAsync<Carteirinha>();
            await _asyncDb.DropTableAsync<Vacina>();
            await _asyncDb.DropTableAsync<Paciente>();
            await _asyncDb.DropTableAsync<Usuario>();

            await _asyncDb.CreateTableAsync<Usuario>();
            await _asyncDb.CreateTableAsync<Paciente>();
            await _asyncDb.CreateTableAsync<Vacina>();
            await _asyncDb.CreateTableAsync<Carteirinha>();
        }
    }
}
