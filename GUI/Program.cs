using GUI.View;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Scaffold-DbContext "Server=MSI\SQLEXPRESS;Database=Relation_Dbfirst;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        /// Data Source=ADMIN;Initial Catalog=Laptop;Integrated Security=True;Trust Server Certificate=True
        /// Scaffold-DbContext "Data Source=ADMIN;Initial Catalog=Laptop;Integrated Security=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        ///  Scaffold-DbContext 'Data Source=ADMIN; Initial Catalog=Laptop; Integrated Security=true; TrustServerCertificate=True' Microsoft.EntityFrameworkCore.SqlServer -OutputDir DomainClass -context DBContext -Contextdir Context -DataAnnotations -Force

        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new DangNhap());
        }
    }
}