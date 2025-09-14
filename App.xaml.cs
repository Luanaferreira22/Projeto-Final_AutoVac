using Microsoft.Extensions.Logging;
using VacinaApp.Data;

namespace VacinaApp
{
    public partial class App : Application
    {
        public PacienteRepository PacienteRepo { get; private set; }
        public UsuarioRepository UsuarioRepo { get; private set; }

        public App()
        {
            InitializeComponent();

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "vacinaapp.db3");
            PacienteRepo = new PacienteRepository(databasePath);
            UsuarioRepo = new UsuarioRepository(databasePath);

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            await PacienteRepo.Init();
            await UsuarioRepo.Init();
        }
    }
}