using System.ComponentModel.DataAnnotations;

namespace Examen_Practica.Models
{
    public class Persona
    {
        public int PersonaId { get; set; }
        [StringLength(50)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
