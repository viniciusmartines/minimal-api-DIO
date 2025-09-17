using Microsoft.EntityFrameworkCore;
using MinimalAPI.Dominio.Entidades;

namespace MinimalAPI.Infraestrutura.Db;

public class DbContexto : DbContext
{
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }

    private readonly IConfiguration _configuracaoAppSettings;

    public DbSet<Administrador> Administradores { get; set; } = default!;

    public DbSet<Veiculo> Veiculos { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(new Administrador
        {
            Id = 1,
            Email = "administrador@teste.com",
            Senha = "123456",
            Perfil = "Adm"
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var stringConexao = _configuracaoAppSettings.GetConnectionString("MySql")?.ToString();
            if (!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(
                    stringConexao,
                    ServerVersion.AutoDetect(stringConexao)
                );
            }
        }


    }
}