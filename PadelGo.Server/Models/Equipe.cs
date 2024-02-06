using System.ComponentModel.DataAnnotations.Schema;
using PadelGo.Data;

namespace PadelGo.Models;
public class Equipe
{
    public int EquipeId { get; set; }
    public string NomJoueur1 { get; set; }
    public string NomJoueur2 { get; set; }
    public int PoidsEquipe { get; set; }
}