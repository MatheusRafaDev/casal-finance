using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasalFinance.Models;

[Table("Custos")]
public class Custo
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
    [StringLength(20)]
    [Display(Name = "Tipo")]
    public string Tipo { get; set; } = string.Empty; // Fixo, Variável

    [Required(ErrorMessage = "Dia de vencimento é obrigatório")]
    [Range(1, 31, ErrorMessage = "Dia deve ser entre 1 e 31")]
    [Display(Name = "Dia de Vencimento")]
    public int Vencimento { get; set; }

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

    [Display(Name = "Categoria")]
    [StringLength(50)]
    public string? Categoria { get; set; }

    [Display(Name = "Conta Automática")]
    public bool ContaAutomatica { get; set; } = false;

    // Propriedade calculada
    [NotMapped]
    public string DiaVencimentoFormatado => $"Dia {Vencimento}";
}