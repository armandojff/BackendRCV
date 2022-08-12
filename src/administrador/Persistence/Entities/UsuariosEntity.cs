using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace administrador.Persistence.Entities
{
    public class UsuariosEntity:BaseEntity
    {
        [Required]
        public string mail { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string tipo { get; set; }
        public HashSet<IncidentesEntity> admin { get; set; }
    }
}

//quizás no haga falta esta entidad por lo del LDAP