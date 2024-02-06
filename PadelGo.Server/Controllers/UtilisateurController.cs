using PadelGo.Models;
using PadelGo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCrypt.Net;


namespace PadelGo.Controllers
{
    [ApiController]
    [Route("utilisateur")]
    public class UtilisateurController : ControllerBase
    {
        private readonly PadelGoContexte _context;

        public UtilisateurController(PadelGoContexte context)
        {
            _context = context;
        }

        // GET: api/utilisateur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetUtilisateurs()
        {
            return await _context.Utilisateurs.ToListAsync();
        }



    // POST: 
        [HttpPost("inscription")]
        public IActionResult PostUtilisateur([FromBody] UtilisateurinscriptionDTOpost utilisateurDTO)
        {
            if (utilisateurDTO == null)
            {
                return BadRequest("Erreur : il faut remplir les informations du nouvel utilisateur.");
            }

            // Hachage du mot de passe
            string motDePasseHaché = BCrypt.Net.BCrypt.HashPassword(utilisateurDTO.MotDePasse);

            Utilisateur nouvelUtilisateur = new Utilisateur
            {
                Nom = utilisateurDTO.Nom,
                Prenom = utilisateurDTO.Prenom,
                Mail = utilisateurDTO.Mail,
                MotDePasse = motDePasseHaché // Utilisez le mot de passe haché
            };

            _context.Utilisateurs.Add(nouvelUtilisateur);
            _context.SaveChanges();

            return Ok("Inscription réussie");
        }

        [HttpPost("connexion")]
public IActionResult PostConnexion([FromBody] UtilisateurconnexionDTOpost utilisateurDTO)
{
    if (utilisateurDTO == null)
    {
        return BadRequest("Les données de connexion sont requises.");
    }

    // Trouver l'utilisateur par mail
    var utilisateur = _context.Utilisateurs.FirstOrDefault(u => u.Mail == utilisateurDTO.Mail);
    
    if (utilisateur == null)
    {
        return Unauthorized("Utilisateur non trouvé.");
    }

    // Vérifier le mot de passe
    bool motDePasseValide = BCrypt.Net.BCrypt.Verify(utilisateurDTO.MotDePasse, utilisateur.MotDePasse);

    if (!motDePasseValide)
    {
        return Unauthorized("Mot de passe incorrect.");
    }

    // Si tout est correct, retourner une réponse de succès (vous pourriez vouloir retourner un token ou des infos utilisateur ici)
    return Ok("Connexion réussie.");
}

    }
}

