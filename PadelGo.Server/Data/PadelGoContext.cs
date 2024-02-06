using Microsoft.EntityFrameworkCore;
using PadelGo.Models;
namespace PadelGo.Data;

public class PadelGoContexte : DbContext
{
    public DbSet<Utilisateur> Utilisateurs { get; set; } = null!;
    public DbSet<Joueur> Joueurs { get; set; }
    public DbSet<Administrateur> Administrateurs { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Tournoi> Tournois { get; set; }
    public DbSet<Equipe> Equipes { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }
   
    public string DbPath { get; private set; }

    public PadelGoContexte()
    {
        // Path to SQLite database file
        DbPath = "PadelGo.db";
    }


    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }


}