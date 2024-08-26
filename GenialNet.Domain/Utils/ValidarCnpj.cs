﻿namespace GenialNet.Domain.Utils;

public class ValidarCnpj
{
    public bool IsValid(string cnpj)
    {
        cnpj = RemoveNonNumeric(cnpj);

        if (cnpj.Length != 14)
            return false;

        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj.Substring(0, 12);
        int soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        int resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        string digito = resto.ToString();
        tempCnpj += digito;
        soma = 0;

        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();

        return cnpj.EndsWith(digito);
    }

    protected string RemoveNonNumeric(string text)
    {
        return System.Text.RegularExpressions.Regex.Replace(text, @"[^\d]", "");
    }

    public string FormatCnpj(string cnpj)
    {
        cnpj = RemoveNonNumeric(cnpj);
        return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
    }
}
