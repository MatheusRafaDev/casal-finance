namespace CasalFinance.Services;
using System.Globalization;
public class CalculadoraService
{
    public class ResultadoCDB
    {
        public decimal RendimentoBruto { get; set; }
        public decimal Imposto { get; set; }
        public decimal RendimentoLiquido { get; set; }
        public decimal ValorFinal { get; set; }
    }

    public ResultadoCDB CalcularCDB(decimal valor, decimal percentualCDI, decimal taxaCDI, int meses)
    {
        var taxaAnual = taxaCDI * (percentualCDI / 100);
        var taxaMensal = (decimal)Math.Pow(1 + (double)taxaAnual, 1.0 / 12.0) - 1;
        
        var rendimentoBruto = valor * ((decimal)Math.Pow(1 + (double)taxaMensal, meses) - 1);
        
        decimal aliquotaIR;
        if (meses <= 6) aliquotaIR = 0.225m;
        else if (meses <= 12) aliquotaIR = 0.20m;
        else if (meses <= 24) aliquotaIR = 0.175m;
        else aliquotaIR = 0.15m;

        var imposto = rendimentoBruto * aliquotaIR;
        var rendimentoLiquido = rendimentoBruto - imposto;
        var valorFinal = valor + rendimentoLiquido;

        return new ResultadoCDB
        {
            RendimentoBruto = rendimentoBruto,
            Imposto = imposto,
            RendimentoLiquido = rendimentoLiquido,
            ValorFinal = valorFinal
        };
    }

    public decimal CalcularParcela(decimal valorTotal, int numParcelas)
    {
        return valorTotal / numParcelas;
    }

}