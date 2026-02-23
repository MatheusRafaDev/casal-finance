using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasalFinance.Models;

[Table("Parcelados")]
public class Parcelado
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatória")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Valor total é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Valor Total")]
    public decimal ValorTotal { get; set; }

    [Required(ErrorMessage = "Número de parcelas é obrigatório")]
    [Range(1, 48, ErrorMessage = "Parcelas deve ser entre 1 e 48")]
    [Display(Name = "Número de Parcelas")]
    public int NumParcelas { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Valor da Parcela")]
    public decimal ValorParcela { get; set; }

    [Required(ErrorMessage = "Data da primeira parcela é obrigatória")]
    [DataType(DataType.Date)]
    [Display(Name = "Data da Primeira Parcela")]
    public DateTime DataPrimeira { get; set; }

    [Required(ErrorMessage = "Categoria é obrigatória")]
    [StringLength(50)]
    [Display(Name = "Categoria")]
    public string Categoria { get; set; } = string.Empty;

    [Required(ErrorMessage = "Responsável é obrigatório")]
    [StringLength(20)]
    [Display(Name = "Responsável")]
    public string Responsavel { get; set; } = string.Empty; // eu, parceiro, conjunto

    [Display(Name = "Parcelas Pagas")]
    public int ParcelasPagas { get; set; } = 0;

    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Display(Name = "Ativo")]
    public bool Ativo { get; set; } = true;

    [Display(Name = "Observações")]
    [StringLength(500)]
    public string? Observacoes { get; set; }

    [Display(Name = "Forma de Pagamento")]
    [StringLength(30)]
    public string? FormaPagamento { get; set; } // Crédito, Financiamento, Empréstimo

    [Display(Name = "Juros (%)")]
    [Column(TypeName = "decimal(5,2)")]
    public decimal? Juros { get; set; }

    [Display(Name = "Valor com Juros")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal? ValorComJuros { get; set; }

    // Propriedades calculadas
    [NotMapped]
    public int ParcelasRestantes => NumParcelas - ParcelasPagas;

    [NotMapped]
    public decimal ValorPago => ValorParcela * ParcelasPagas;

    [NotMapped]
    public decimal ValorRestante => ValorTotal - ValorPago;

    [NotMapped]
    public bool Concluido => ParcelasPagas >= NumParcelas;

    [NotMapped]
    public string Status => Concluido ? "Concluído" : $"{ParcelasPagas}/{NumParcelas} pagas";

    [NotMapped]
    public DateTime ProximaParcela => DataPrimeira.AddMonths(ParcelasPagas);

    [NotMapped]
    public List<DateTime> DatasParcelas
    {
        get
        {
            var datas = new List<DateTime>();
            for (int i = 0; i < NumParcelas; i++)
            {
                datas.Add(DataPrimeira.AddMonths(i));
            }
            return datas;
        }
    }
}