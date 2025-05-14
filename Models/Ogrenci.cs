using System.ComponentModel.DataAnnotations;

namespace OgrenciAjaxProjesi.Models
{
    public class Ogrenci
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad boş bırakılamaz.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad boş bırakılamaz.")]
        public string Soyad { get; set; }
    }
}
