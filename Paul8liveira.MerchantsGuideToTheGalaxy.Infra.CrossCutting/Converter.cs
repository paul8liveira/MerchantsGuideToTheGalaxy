using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Infra.CrossCutting
{
    public static class Converter
    {
        #region Multiplicadores de credito
        private const double Gold = 14450;
        private const double Silver = 17;
        private const double Iron = 195.5;
        #endregion

        #region Inicia procedimentos de conversao
        public static string Start(string text)
        {            
            //remove ? caso ocorra
            //converte string de entrada para array
            String[] splitedText = text.Replace("?", "").ToUpper().Split(' ');

            //remove array com espaco em branco (causando por " ?" no final da string)
            splitedText = splitedText.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            //conversao intergalactico para romano
            var romanNumeral = IntergalacticToRoman(splitedText);

            //conversao correta?
            if (String.IsNullOrEmpty(romanNumeral))
            {
                return "InvalidInput01: The intergalactics numbers doesn't exists.";
            }            

            //verifica repeticoes validas
            if (repeatedSuccession(romanNumeral))
            {
                return "InvalidInput02: Some intergalactics numbers exceeded the maximum repetition.";
            }

            //conversao dos valores para numeros arabicos
            double romanToArabic = RomanToArabic(romanNumeral);
            string concatText = "IS " + romanToArabic;

            //considero o multiplicador de credito somente se estiver no final do array
            switch (splitedText[splitedText.Length - 1])
            {
                case "GOLD":
                {
                    romanToArabic *= Gold;
                    concatText = "GOLD IS " + romanToArabic + " CREDITS";
                    break;
                }
                case "SILVER":
                {
                    romanToArabic *= Silver;
                    concatText = "SILVER IS " + romanToArabic + " CREDITS";
                    break;
                }
                case "IRON":
                {
                    romanToArabic *= Iron;
                    concatText = "IRON IS " + romanToArabic + " CREDITS";
                    break;
                }                    
            }

            //converte romano para arabico e retorna para o formato de saida
            var romanToIntergalactic = RomanToIntergalactic(romanNumeral) + concatText;
            romanToIntergalactic = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(romanToIntergalactic.ToLower());

            return romanToIntergalactic;
        }
        #endregion

        #region Procedimento de conversao intergalactic x romano e romano x intergalactico
        private static string IntergalacticToRoman(String[] splited)
        {
            string roman = "";
            for (var i = 0; i < splited.Length; i++)
            {
                switch (splited[i])
                {
                    case "GLOB":
                    {
                        roman += "I";
                        break;
                    }
                    case "PROK":
                    {
                        roman += "V";
                        break;
                    }
                    case "PISH":
                    {
                        roman += "X";
                        break;
                    }
                    case "TEGJ":
                    {
                        roman += "L";
                        break;
                    }
                }
            }
            return roman;
        }

        private static string RomanToIntergalactic(string romanNumeral)
        {
            string intergalactic = "";
            for (var i = 0; i < romanNumeral.Length; i++)
            {
                switch (romanNumeral[i])
                {
                    case 'I':
                        {
                            intergalactic += "GLOB ";
                            break;
                        }
                    case 'V':
                        {
                            intergalactic += "PROK ";
                            break;
                        }
                    case 'X':
                        {
                            intergalactic += "PISH ";
                            break;
                        }
                    case 'L':
                        {
                            intergalactic += "TEGJ ";
                            break;
                        }
                }
            }
            return intergalactic;
        }
        #endregion

        #region Procedimento para validacao de repeticoes validas de cada algarismo
        public static bool repeatedSuccession(string source)
        {
            //return Regex.IsMatch(source, "([a-zA-Z])\\1{" + (sequenceLength - 1) + "}");
            string index = new String(source.Distinct().ToArray());
            int sequenceLimit = 0;
            foreach(var c in index)
            {
                switch (c)
                {
                    case 'I':
                    {
                        sequenceLimit = 3;
                        break;
                    }
                    case 'X':
                    {
                        sequenceLimit = 3;
                        break;
                    }
                    case 'V':
                    {
                        sequenceLimit = 1;
                        break;
                    }
                    case 'L':
                    {
                        sequenceLimit = 1;
                        break;
                    }

                }
                //Verifica a repeticao do caracter atraves de expressao regular, utilizando um limitador
                if (Regex.IsMatch(source, "([" + c + "-" + c + "])\\1{" + (sequenceLimit) + "}"))
                    return true;
            }
            return false;            
        }
        #endregion

        #region Procedimento de calculo de romano para arabico 
        //Desenvolvido pelo prof. Francisco Edmundo de Andrade
        //Nao encontrei a referencia original mas, segue link do GUJ
        //http://www.guj.com.br/t/metodo-para-converter-numeros-romanos-para-decimal-alguem-sabe/81923/5
        private static int RomanToArabic(String texto)
        {
            int n = 0;
            int numeralDaDireita = 0;
            for (int i = texto.Length - 1; i >= 0; i--)
            {
                int valor = (int)RomanToArabic(texto[i]);
                n += valor * Math.Sign(valor + 0.5 - numeralDaDireita);
                numeralDaDireita = valor;
            }
            return n;
        }
        private static double RomanToArabic(char caractere)
        {
            return Math.Floor(Math.Pow(10, "IXCM".IndexOf(caractere))) + 5 * Math.Floor(Math.Pow(10, "VLD".IndexOf(caractere)));
        }
        #endregion
    }
}
