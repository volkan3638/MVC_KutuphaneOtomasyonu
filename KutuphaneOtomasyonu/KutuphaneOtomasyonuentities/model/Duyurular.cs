using System;
using System.ComponentModel.DataAnnotations;

namespace Kütüphaneotomasyonu.entities.Model.context
{
    public class Duyurular
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı gereklidir.")]
        [StringLength(200, ErrorMessage = "Başlık 200 karakteri geçemez.")]
        public string Başlık { get; set; }

        [Required(ErrorMessage = "Duyuru alanı gereklidir.")]
        [StringLength(1000, ErrorMessage = "Duyuru 1000 karakteri geçemez.")]
        public string Duyuru { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama 500 karakteri geçemez.")]
        public string Acıklama { get; set; }

        [Required(ErrorMessage = "Tarih alanı gereklidir.")]
        public DateTime Tarih { get; set; }
    }
}
