using System.ComponentModel.DataAnnotations;

namespace Stock.Client.Web.ViewModels
{
    public class LogonViewModel
    {
        [Display(Name = "Имя пользователя")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public string Message { get; set; }
    }
}
