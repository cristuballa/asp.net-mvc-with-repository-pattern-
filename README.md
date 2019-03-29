# asp.net-mvc-with-repository-pattern-
Repository pattern and unit of work implementation in asp.net mvc with Onion Architecture.

This is a sample web application that introduce repository and unit of work design pattern. It allow us to work directly with the data in the infrastructure layers for database operations not in applicaton layer, application’s UI and business logic. It also gives us the ability to decouple our application to the persistence framework and databases.


# NumberToText class 
This class is located in the ApplicationCore.Services project. It converts a number into words which is very useful in scenarios like writing cheque wherein an amount should be written into words.

Analysis: 

    Every digits in a number has place value, for example in the number = 5858,
    
    5 ---> Thousands place
    8 ---> hundreds place
    5 ---> tens place
    8 ---> ones place
    
1. Firstly, we need to initialize an array of number in word string which corresponds to the array index value, so that we can access         the word by using the index value.
   
    Example.
    
        string[] units = new string[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
        string[] teens = new string[] { "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN " };
        string[] tens = new string[] { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
        string[] thousands = new string[] { "", "THOUSAND", "MILLION", "BILLION", "TRILLION" };
       
   In this case we can use units[1] to get value string equal "ONE",  units[2] equal to "TWO" and so on. This is same with thousands, hundreds, tens and ones
   
   
2. Secondly, we will convert a given number by determining the highest place value of the number, 
   
   Example:
          
   a. The highest place value is thousands 
      
          number =5858 
          
   b. This will detemine the highest place value  
   
          if (number >= 1000)
          
    c. This will count the highest place value which is thousands in this case 5000 and the count is 5 of thousands
   
          ulong thousandscount = (number - (number % 1000)) / 1000;  //the result thousandscount = 5
          
    d. But if we execute the code below the result string will be "5 THOUSAND" 
    
          numberTexts.Append( thousandscount + " THOUSAND");
          
    e. That's why we need to convert the digit 5 by calling the same method and passing 5 as parameter. This time it will fall under (number > 0 && number < 10) and will return a string which is "FIVE"
          
          numberTexts.Append(ConvertNumberToWord(thousandscount) + " THOUSAND");  //result string "FIVE THOUSAND"
          
    d. Here, number = 5858, but we already converted 5000 to string, so we need to eliminate 5000 so that the result will be 858 by using the following code
       
       number -= hundredscount * 1000; // result is 858 then execute the same process for the hundreds, tens, ones
   
    
3. Lastly, the code will have the same process for the place value trillions,billions, millions,hundreds, tens, teens and ones as shown below.

        if (number >= 1000000)   
                    {
                        ulong hundredscount = (number - (number % 1000000)) / 1000000; 
                        numberTexts.Append(ConvertNumberToWord(hundredscount) + " MILLION");
                        number -= hundredscount * 1000000;
                    }
       
        if (number >= 1000)   
                    {
                        ulong hundredscount = (number - (number % 1000)) / 1000; 
                        numberTexts.Append(ConvertNumberToWord(hundredscount) + " THOUSAND");
                        number -= hundredscount * 1000;
                    }


         if (number >= 100)   
                    {
                        ulong hundredscount = (number - (number % 100)) / 100; 
                        numberTexts.Append(ConvertNumberToWord(hundredscount) + " HUNDRED");
                        number -= hundredscount * 100;
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



# NumberToText.cs complete code

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
