using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasalFinance.Models;

[Table("Futuros")]
public class Futuro
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tipo é obrigatório")]
    [StringLength(20)]
    [Display(Name = "Tipo")]
    public string Tipo { get; set; } = string.Empty; // receita, gasto, custo

    [Required(ErrorMessage = "Descrição é obrigatória")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Descrição deve ter entre 3 e 100 caracteres")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Valor")]
    public decimal Valor { get; set; }

    [Display(Name = "Categoria")]
    [StringLength(50)]
    public string? Categoria { get; set; } // para gastos

    [Display(Name = "Tipo de Custo")]
    [StringLength(20)]
    public string? TipoCusto { get; set; } // para custos (Fixo/Variável)

    [Required(ErrorMessage = "Data é obrigatória")]
    [DataType(DataType.Date)]
    [Display(Name = "Data")]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "Responsável é obrigatório")]
    [StringLength(20)]
    [Display(Name = "Responsável")]
    public string Responsavel { get; set; } = string.Empty; // eu, parceiro, conjunto

    [Required(ErrorMessage = "Status é obrigatório")]
    [StringLength(20)]
    [Display(Name = "Status")]
    public string Status { get; set; } = "pendente"; // pendente, pago, atrasado

    [Display(Name = "Referência da Parcela")]
    public int? ParcelaRef { get; set; } // ID da compra parcelada

    [Display(Name = "Número da Parcela")]
    public int? ParcelaNum { get; set; }

    [Display(Name = "Total de Parcelas")]
    public int? TotalParcelas { get; set; }

    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Display(Name = "Ativo")]
    public bool Ativo { get; set; } = true;

    [Display(Name = "Observações")]
    [StringLength(500)]
    public string? Observacoes { get; set; }

    [Display(Name = "Recorrente")]
    public bool Recorrente { get; set; } = false;

    [Display(Name = "Frequência (meses)")]
    public int? FrequenciaMeses { get; set; }

    // Propriedade calculada
    [NotMapped]
    public bool EstaAtrasado => Status == "pendente" && Data < DateTime.Today;

    [NotMapped]
    public string StatusFormatado => Status switch
    {
        "pendente" => EstaAtrasado ? "atrasado" : "pendente",
        "pago" => "pago",
        _ => Status
    };

    [NotMapped]
    public string CorStatus => StatusFormatado switch
    {
        "pago" => "success",
        "pendente" => "warning",
        "atrasado" => "danger",
        _ => "secondary"
    };
}