using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasalFinance.Models;

[Table("Receitas")]
public class Receita
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatória")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Valor")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "Tipo é obrigatório")]
    [StringLength(50)]
    [Display(Name = "Tipo de Receita")]
    public string Tipo { get; set; } = string.Empty; // Salário, Freela, Investimentos, Outros

    [Required(ErrorMessage = "Data é obrigatória")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Recebimento")]
    public DateTime Data { get; set; }

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

    [Display(Name = "Comprovante")]
    public string? ComprovanteUrl { get; set; }

    // Propriedade calculada
    [NotMapped]
    public string MesAno => Data.ToString("MMM/yyyy");
}