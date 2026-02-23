using System.Globalization;
public class FormatacaoService
{
    private readonly CultureInfo _cultureBR = new CultureInfo("pt-BR");

    public string FormatarMoeda(decimal valor)
    {
        return string.Format(_cultureBR, "{0:C}", valor);
    }

    public string FormatarData(DateTime data)
    {
        return data.ToString("dd/MM/yyyy", _cultureBR);
    }

    public decimal ParseMoeda(string valor)
    {
        if (string.IsNullOrEmpty(valor)) return 0;
        
        valor = valor.Replace("R$", "").Trim();
        return decimal.Parse(valor, _cultureBR);
    }
}