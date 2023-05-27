using System;

namespace Converter
{
    class Program
    {
        static void Main()
        {
            Converter.ShowAllValues(Console.ReadLine()); //(hodnota)cislo sustavy   (1011)2
        }
    }
    class Converter
    {
        static int dec_val;

        public static void ShowAllValues(string input){
            string[] parsedInput = input.Split(')');
            parsedInput[0] = parsedInput[0].Remove(0,1);
            GetDecimal(parsedInput[0], Convert.ToInt32(parsedInput[1]));
            for(int i = 2; i <= 16; i=i*2){
                if(i.ToString() != parsedInput[1] & i!=4)
                    FromDec(dec_val, i);
                    if(i == 8 & parsedInput[1]!= "10")
                        Console.WriteLine("Dec: " + dec_val);
            }
        }
        static void GetDecimal(string val, int entered_digit){
            string all_values = "0123456789ABCDEF";
            for(int i = 0; i < val.Length; i++)
                dec_val += Convert.ToInt32(Math.Pow(entered_digit,val.Length-i-1))*all_values.IndexOf(val[i]);
        }
        
        static void FromDec(int dec, int wanted_val){
            string result = null;
            
            string add_values = "0123456789ABCDEF";
            while(dec>0){
                result = add_values[dec%wanted_val] + result;
                dec /= wanted_val;
            }
            
            if(wanted_val == 2)
                System.Console.WriteLine("Bin: " + result);
            else if(wanted_val == 8)
                System.Console.WriteLine("Oct: " + result);
            else
                System.Console.WriteLine("Hex: " + result);
        }
    }
}