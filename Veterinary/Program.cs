using Veterinary.Models;
using Veterinary.Presenters;
using Veterinary.Repositories;
using Veterinary.Views;

namespace Veterinary
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string sqlConnection = "Data Source=DESKTOP-E315N41\\SQLEXPRESS;Initial Catalog=VeterinaryDb;Integrated Security=True;TrustServerCertificate=True;";
            IPetView petView = new PetView();
            IPetRepository petRepository = new PetRepository(sqlConnection);
            new PetPresenter(petView, petRepository);
            Application.Run((Form)petView);
        }
    }
}