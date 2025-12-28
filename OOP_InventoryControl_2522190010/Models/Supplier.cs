using System.ComponentModel.DataAnnotations; 

namespace OOP_InventoryControl_2522190010.Models;

public class Supplier
{
    public int SupplierId { get; set; }

    [Required(ErrorMessage = "Firma adı alanı zorunludur.")]
    public string CompanyName { get; set; } = "";

    // Email Format Kontrolü
    [Required(ErrorMessage = "Email alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz (örn: isim@firma.com).")]
    public string Email { get; set; } = "";

    [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
    public string Phone { get; set; } = "";
}