using EstocariaNet.Shared.DTOs;
using Microsoft.AspNetCore.Identity;

public enum TipoUsuario { Admin, Estoquista }

namespace EstocariaNet.Models
{
    public class AplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public TipoUsuarioEnum? TipoUsuario { get; set; }

        public string? IdAdmin { get; set; }

        public Admin? Admin { get; set; }

        public string? IdEstoquista { get; set; }
        
        public Estoquista? Estoquista { get; set; }
    }
}
