using System.ComponentModel.DataAnnotations;

namespace InternetStoreEngine.DataAccessLayer.Entities
{
    public class Availabilitys : Base
    {
        [Display(Name = "Доступна ли категория?")]
        [Required(ErrorMessage = "Пожалуйста, введите доступность категории: Да или Нет")]
        public bool Availability { get; set; }
    }
}