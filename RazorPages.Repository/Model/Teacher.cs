using System.ComponentModel.DataAnnotations;

namespace RazorPages.Repository.Model
{
    public class Teacher
    {
        // Идентификатор учителя
        public int Id { get; set; }

        // Имя учителя
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Name { get; set; }

        // Фамилия учителя
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Surname { get; set; }

        // Предмет, который преподает учитель
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Subject { get; set; }

        // Стаж работы учителя
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(5, 50, ErrorMessage = "Недопустимый стаж")]
        public int Experience { get; set; }

        // Возраст учителя
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(25, 75, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }        
    }
}
