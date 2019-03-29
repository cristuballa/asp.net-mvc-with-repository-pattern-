# asp.net-mvc-with-repository-pattern-
Repository pattern and unit of work implementation in asp.net mvc with Onion Architecture.

This is a sample web application that introduce repository and unit of work design pattern. It allow us to work directly with the data in the database layers for database operations not in applicaton layer, application’s UI and business logic. It also gives us the ability to decouple our application to the persistence framework and databases.


# NumberToText class 
This class is located in the ApplicationCore.Services project

public class NumberToText : Person
    {

        public decimal Amount { get; set; }
        public string AmountInWords { get; set; }

        public void ConvertAmountToWord(decimal number)
        {
            try
            {
                decimal decimalPart = (Math.Round(number, 2, MidpointRounding.ToEven) % 1.0m) * 100m;
                ulong decimalPartLong = (ulong)decimalPart;
                ulong integralPart = (ulong)number;
                string integralPartStr = ConvertNumberToWord(integralPart);
                string decimalPartStr = decimalPartLong>0 ? "AND" + ConvertNumberToWord(decimalPartLong) + " CENTS" : " ";

                AmountInWords= integralPartStr + " " + decimalPartStr;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private string ConvertNumberToWord(ulong number)
        {

            StringBuilder numberTexts = new StringBuilder();
            string[] units = new string[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
            string[] teens = new string[] { "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN " };
            string[] tens = new string[] { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
            string[] thousands = new string[] { "", "THOUSAND", "MILLION", "BILLION", "TRILLION" };

            if (number < 1000000000000000 && number >= 0)
            {

                if (number >= 1000)
                {
                    for (int i = thousands.Length - 1; i >= 0; i--)
                    {
                        ulong thousandPower = (ulong)Math.Pow(1000, i);
                        ulong thousandCount = (number - (number % thousandPower)) / thousandPower;

                        if (number >= thousandPower)
                        {
                            numberTexts.Append(ConvertNumberToWord(thousandCount) + " " + thousands[i]);
                            number -= thousandCount * thousandPower;
                        }
                    }
                }

                if (number >= 100)
                {
                    ulong hundredscount = (number - (number % 100)) / 100;
                    numberTexts.Append(ConvertNumberToWord(hundredscount) + " HUNDRED");
                    number -= hundredscount * 100;
                }

                // ConvertSmallNumberToText(number, numberTexts);

                if (number >= 20 && number < 100)
                {
                    ulong tensCount = (number - (number % 10)) / 10;
                    numberTexts.Append(" " + tens[tensCount]);
                    number -= tensCount * 10;
                }

                if (number >= 10 && number < 20)
                {
                    numberTexts.Append(" " + teens[number - 10]);
                    number = 0;
                }

                if (number > 0 && number < 10)
                {
                    numberTexts.Append(" " + units[number]);

                }



                return numberTexts.ToString();

            }

            else
            {
                return "Invalid Amount.";
            }



        }
    }
