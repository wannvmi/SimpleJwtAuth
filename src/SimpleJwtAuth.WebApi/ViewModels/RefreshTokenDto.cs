using System.ComponentModel.DataAnnotations;

namespace SimpleJwtAuth.WebApi.ViewModels
{
    public class RefreshTokenDto
    {
        [Required]
        public string Token { get; set; }
    }
}
