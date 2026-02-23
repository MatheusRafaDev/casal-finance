using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasalFinance.Models;

[Table("Gastos")]
public class Gasto
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

    [Required(ErrorMessage = "Categoria é obrigatória")]
    [StringLength(50)]
    [Display(Name = "Categoria")]
    public string Categoria { get; set; } = string.Empty; // Alimentação, Moradia, Transporte, Saúde, Lazer, Educação, Outros

    [Required(ErrorMessage = "Data é obrigatória")]
    [DataType(DataType.Date)]
    [Display(Name = "Data do Gasto")]
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

    [Display(Name = "Nota Fiscal")]
    public string? NotaFiscalUrl { get; set; }

    [Display(Name = "Pago")]
    public bool Pago { get; set; } = true;

    [Display(Name = "Forma de Pagamento")]
    [StringLength(30)]
    public string? FormaPagamento { get; set; } // Dinheiro, Crédito, Débito, Pix

    [Display(Name = "Parcelado")]
    public bool Parcelado { get; set; } = false;

    [Display(Name = "Número da Parcela")]
    public int? NumeroParcela { get; set; }

    [Display(Name = "Total de Parcelas")]
    public int? TotalParcelas { get; set; }

    [Display(Name = "ID da Compra Parcelada")]
    public int? ParcelaRef { get; set; }
}