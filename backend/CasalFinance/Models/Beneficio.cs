using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasalFinance.Models;

[Table("Beneficios")]
public class Beneficio
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tipo é obrigatório")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Tipo deve ter entre 2 e 50 caracteres")]
    [Display(Name = "Tipo de Benefício")]
    public string Tipo { get; set; } = string.Empty; // VR, VA, VT, Combustível, Cultura, Outros

    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Valor Mensal")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "Dia da recarga é obrigatório")]
    [Range(1, 31, ErrorMessage = "Dia deve ser entre 1 e 31")]
    [Display(Name = "Dia da Recarga")]
    public int DiaRecarga { get; set; }

    [Required(ErrorMessage = "Responsável é obrigatório")]
    [StringLength(20)]
    [Display(Name = "Responsável")]
    public string Responsavel { get; set; } = string.Empty; // eu, parceiro, conjunto

    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Display(Name = "Ativo")]
    public bool Ativo { get; set; } = true;

    [Display(Name = "Observações")]
    [StringLength(500)]
    public string? Observacoes { get; set; }
}