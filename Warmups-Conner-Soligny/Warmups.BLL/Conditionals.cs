using System;
using System.Text.RegularExpressions;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            return aSmile == bSmile;
        }


        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {

            if (isWeekday == false)
            {
                return true;
            }
            else if (isVacation == true)
                {
                    return true;
                }
            
            else 
            {
                return false;
            }
        
        }


        public int SumDouble(int a, int b)
        {
            int sum = a + b;
                if (a == b)
            {
                sum = sum * 2;
            }
            return sum;

        }
        

        public int Diff21(int n)
        {
            if (n <= 21)
            {
                return 21 - n;
            }
            else
            {
                return (n - 21) * 2;
            }
        }
        

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            return isTalking && (hour < 7 || hour > 20);
            
        }



        //Given two ints, a and b, return true if one if them is 10 or if their sum is 10. 

        public bool Makes10(int a, int b)
        {
            return (a == 10 || b == 10 || a+b == 10);  
        }



        //Given an int n, return true if it is within 10 of 100 or 200.

        public bool NearHundred(int n)
        {
            return ((Math.Abs(100 - n) <= 10) || (Math.Abs(200 - n) <=10));
        }




        // return true if one is negative and one is positive. 
        // if the parameter "negative" is true, then return true only if both are negative. 

        public bool PosNeg(int a, int b, bool negative)
        {
            if (negative)
            {
                return (a < 0 && b < 0);
            }
            else
            {
                return (a < 0 && b > 0 || a > 0 && b < 0);
            }
            throw new NotImplementedException();
        }

        

        
        //string, return a new string where "not " has been added to the front. 
        //if the string already begins with "not", return the string unchanged.

        public string NotString(string s)
        {
            if (s.Length >= 3 && s.Substring(0, 3).Equals("not"))
            {
                return s;
            }
                return "not " + s;
            throw new NotImplementedException();
        }




        //Given a non-empty string and an int n, return a new string where the char at index n has been removed. 
        //The value of n will be a valid index of a char in the original string (Don't check for bad index). 
                                                        //NOT DONE

        public string MissingChar(string str, int n)
            
        {
            string newFirst = str.Substring(0, n);
            string newLast = str.Substring(n + 1, str.Length);
            return newFirst + newLast;
            throw new NotImplementedException();
        }





        //Given a string, return a new string where the first and last chars have been exchanged. 

        public string FrontBack(string str)
        {
            var first = str[0];
            var last = str[str.Length - 1];
           
            
            if (str.Length <= 1)
            {

                return str;
            }
            else { 
                string mid = str.Substring(1, str.Length - 2);
            return last + mid + first;
            }
            throw new NotImplementedException();
        }

       


        //Given a string, we'll say that the front is the first 3 chars of the string. 
        //If the string length is less than 3, the front is whatever is there. Return a new string which is 3 copies of the front. 

        public string Front3(string str)
        {
            
            if (str.Length <= 2)
            {
                return str + str + str;
            }
            else
            {
                string newFront = str.Substring(0, 3);
                return newFront + newFront + newFront;

            }
            
            throw new NotImplementedException();
        }




       
        //Given a string, take the last char and return a new string with the last char added at the front and back, so "cat" yields "tcatt".
        // The original string will be length 1 or more. 

        public string BackAround(string str)
        {
            char first = str[str.Length - 1];
            return first+str+first;

            throw new NotImplementedException();
        }





       
        //Return true if the given non-negative number is a multiple of 3 or a multiple of 5. Use the % "mod" operator
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        


        
        //Given a string, return true if the string starts with "hi" and false otherwise. 
                                            //NOT DONE
        public bool StartHi(string str)
        { 
            if (str == "hi" ) //|| Regex.IsMatch (str, @"\bhi\b")
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }






        //Given two temperatures, return true if one is less than 0 and the other is greater than 100. 

        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 <= 0 && temp2 >= 100 || temp2 <= 0 && temp1 >= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }




        //Given 2 int values, return true if either of them is in the range 10..20 inclusive. 

        public bool Between10and20(int a, int b)
        {
            return ((a >= 10 && a <= 20) || (b >= 10 && b <= 20));
            throw new NotImplementedException();
        }




        //We'll say that a number is "teen" if it is in the range 13..19 inclusive. 
        //Given 3 int values, return true if 1 or more of them are teen. 

        public bool HasTeen(int a, int b, int c)
        {
           return (((a > 12 & a < 20) ^ (b > 12 & b < 20) ^ (c > 12 & c < 20)));
            throw new NotImplementedException();
        }





        //We'll say that a number is "teen" if it is in the range 13..19 inclusive. 
        //Given 2 int values, return true if one or the other is teen, but not both. 

        public bool SoAlone(int a, int b)
        {
            if ((a > 12 && a < 20) && (b > 12 && b < 20))
            {
                return false;
            }
            else if ((a > 12 && a < 20) || (b > 12 && b < 20))
            {
                    return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }






        //Given a string, if the string "del" appears starting at index 1, return a string where that "del" has been deleted. 
        //Otherwise, return the string unchanged. 

        public string RemoveDel(string str)
        {

            if (str.Substring(1, 3) == "del")
            {
                return str.Remove(1, 3);
            }
            else
            {
                return str;
            }
            throw new NotImplementedException();
        }




        //Return true if the given string begins with "*ix", the '*' can be anything, so "pix", "9ix" .. all count. 

        public bool IxStart(string str)
        {
            if (str.Substring(1, 2) == "ix")
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }





        //Given a string, return a string made of the first 2 chars (if present), 
        //however include first char only if it is 'o' and include the second only if it is 'z', so "ozymandias" yields "oz". 
                                                    //NOT DONE
        public string StartOz(string str)
        {
            if (str.Substring(0,2) == "oz") 
            {
                return "o" + "z";
            }
            else
            {
                return str;
            }
            throw new NotImplementedException();
        }




        //Given three int values, a b c, return the largest. 

        public int Max(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                return a;
            }
            else if (b > a && b > c)
            {
                return b;
            }
            else
            {
                return c;
            }
            throw new NotImplementedException();
        }



        //Given 2 int values, return whichever value is nearest to the value 10, or return 0 in the event of a tie. 

        public int Closer(int a, int b)
        {
            int aDist = Math.Abs(10 - a);
            int bDist = Math.Abs(10 - b);

            if (aDist == bDist)
            {
                return 0;
            }
            else if (aDist < bDist)
            {
                return a;
            }
            else
            {
                return b;
            }
            throw new NotImplementedException();
        }




        //Return true if the given string contains between 1 and 3 'e' chars. 

        public bool GotE(string str)
        {
        
            {
                return true;
            }
            throw new NotImplementedException();
        }




        //Given a string, return a new string where the last 3 chars are now in upper case. 
        //If the string has less than 3 chars, uppercase whatever is there. 

        public string EndUp(string str)
        {
            if (str.Length > 3)
            {
                return (str.Substring(0, str.Length - 3) + (str.Substring((str.Length - 3), str.Length)));
            }
            else
            {
                return str.ToUpper();
            }

            throw new NotImplementedException();
        }





        //Given a non-empty string and an int N, return the string made starting with char 0, 
        //and then every Nth char of the string. So if N is 3, use char 0, 3, 6, ... and so on. N is 1 or more. 

        public string EveryNth(string str, int n)
        {
            string s = "";
            for (int i = 0; i < str.Length;)
            {
                
                i += n;
            }
            return s;
        }
        }
    }

    internal class Regex
    {
    }

