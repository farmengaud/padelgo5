using System.ComponentModel.DataAnnotations.Schema;
using PadelGo.Data;

namespace PadelGo.Models;
public class Utilisateur
{
    public int UtilisateurId { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Mail { get; set; }
    public string MotDePasse { get; set; } // Doit être géré de manière sécurisée

    // public Utilisateur(int utilisateurId, string nom, string prenom, string mail, string motDePasse)
    // {
    //     UtilisateurId = utilisateurId;
    //     Nom = nom;
    //     Prenom = prenom;
    //     Mail = mail;
    //     MotDePasse = motDePasse;
    // }
}