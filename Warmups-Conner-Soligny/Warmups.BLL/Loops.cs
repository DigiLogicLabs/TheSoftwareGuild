using System;

namespace Warmups.BLL
{
    public class Loops
    {
        //Given a string and a non-negative int n, 
        //return a larger string that is n copies of the original string. 

        public string StringTimes(string str, int n)
        {
            string suhh = "";

            for (int i = 0; i < n; i++)
            {
                suhh = suhh + str;
            }
            return suhh;
            throw new NotImplementedException();
        }



        //Given a string and a non-negative int n, we'll say that the front of the string is the first 3 chars, 
        //or whatever is there if the string is less than length 3. Return n copies of the front; 

        public string FrontTimes(string str, int n)
        {
            string ayy = "";
            string front = str.Length < 3 ? str : str.Substring(0, 3);

            for (int i = 0; i < n; i++)
            {
                ayy += front;
            }
            return ayy;
            throw new NotImplementedException();
        }





        //NOT DONE
        //Count the number of "xx" in the given string. We'll say that overlapping is 
        //allowed, so "xxx" contains 2 "xx". 
        public int CountXX(string str)
        {
            int counter = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {

                if(str[i] == 'x')
                {
                    counter += 1;
                }
            }
            return counter;

        }



        //Given a string, return true if the first instance of "x" 
        //in the string is immediately followed by another "x". 

        public bool DoubleX(string str)
        {
            for (int i = 0; i < str.Length -1; i++)
            {
                if(str[i] == 'x' && str[i + 1] == 'x')
                {
                    return true;
                }
                else if (str[i] == 'x' && str [i +1] != 'x')
                {
                    return false;
                }
                
            }
            return false;
        }



        //Given a string, return a new string made of every other char 
        //starting with the first, so "Hello" yields "Hlo". 

        public string EveryOther(string str)
        {
            string firstString = "";

            for (int i = 0; i < str.Length; i = i+2)
            {
                firstString += str[i];
            }

            return firstString;
            
        }





        //Given a non-empty string like "Code" return a string like "CCoCodCode".  
        //(first char, first two, first 3, etc)

        public string StringSplosion(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                result += str.Substring(0, i + 1);
            }
            return result;
            throw new NotImplementedException();
        }





        //Given a string, return the count of the number of times that a substring 
        //length 2 appears in the string and also as the last 2 chars of the string, 
        //so "hixxxhi" yields 1 (we won't count the end substring). 

        public int CountLast2(string str)
        {

            string end = str.Substring(str.Length - 2);
             int count = 0;


            for (int i = 0; i < str.Length -2; i++)
            {
                
                if(str.Substring(i, 2) == end)
                {
                    count = count + 1;
                }
            }


            return count;


            throw new NotImplementedException();
        }





        //Given an array of ints, return the number of 9's in the array. 

        public int Count9(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    count++;
                    
                }

            }
            return count;
            throw new NotImplementedException();
        }





        //Given an array of ints, return true if one of the first 4 elements in the 
        //array is a 9. The array length may be less than 4. 


        public bool ArrayFront9(int[] numbers)
        {
            int len = numbers.Length;
            if (len > 4)
                len = 4;
            for (int i = 0; i < len; i++)
            {
                if (numbers[i] == 9)
                    return true;
            }
            return false;
        }




      


        //Given an array of ints, return true if .. 1, 2, 3, .. 
        //appears in the array somewhere. 

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }           }
            return false;
            throw new NotImplementedException();
        }





        //Given 2 strings, a and b, return the number of the positions where they 
        //contain the same length 2 substring. So "xxcaazz" and "xxbaaz" yields 3, 
        //since the "xx", "aa", and "az" substrings appear in the same place in both 
        //strings. 

        public int SubStringMatch(string a, string b)
        {
            int count = 0;
            
            
            if(a.Length >3 )
            {
                for (int i = 0; i < a.Length - 2; i++)
                {
                    if(a.Substring(i,2) == b.Substring(i,2))
                    {
                        count++;
                    }

                }
            }
            else
            {
                for (int i = 0; i < a.Length -1; i++)
                {
                    if (a.Substring(i,2) == b.Substring(i,2))
                    {
                        count++;
                    }

                }
            }
            return count;
            

            throw new NotImplementedException();
        }





        //Given a string, return a version where all the "x" have been removed. 
        //Except an "x" at the very start or end should not be removed. 

        public string StringX(string str)
        {
            string newString = "";
            string oldString = "";
            string firtPart = str.Substring(0,1);
            string secondPart = str.Substring(str.Length - 1, 1);
           
            if (str.Substring(0,1) != "x" || (str.Substring(str.Length-1,1) != "x"))
            {

                newString = str.Substring(0, str.Length-1).Replace(@"x","" );


                return newString + secondPart;
            }
            else if (str.Substring(0, 1) == "x" && (str.Substring(str.Length - 1, 1) == "x"))
            {
                oldString = str.Substring(1, str.Length - 1).Replace(@"x", "");
            }
            return firtPart + oldString + secondPart ;
        }





        //Given a string, return a string made 
        //of the chars at indexes 0,1, 4,5, 8,9 ... 
        //so "kittens" yields "kien". 


        public string AltPairs(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i += 4)
            {
                
                result += str[i];

                if (i+1 < str.Length)
                {
                    result += str[i + 1];               
                }
                
            }

            return result;

        }





        //Suppose the string "yak" is unlucky. Given a string, return a version where 
        //all the "yak" are removed, but the "a" can be any char. The "yak" strings will 
        //not overlap. 

        public string DoNotYak(string str)
        {
            string ifIneed = str.Replace("yak", "");
            
            
            for (int i = 0; i < str.Length -2  ; i++)
            {
                if (str.Substring(i,3) == "yak")
                {
                    return ifIneed;
                    
                }
            }
            return str;
                

            
        }





        //Given an array of ints, return the number of times that two 6's are next to each 
        //other in the array. Also count instances where the second "6" is actually a 7. 

        public int Array667(int[] numbers)
        {
            int counter = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if ((numbers[i] == 7 || numbers[i] == 6) && numbers[i - 1] == 6)
                    counter++;
            }
            return counter;
            throw new NotImplementedException();
        }





        //Given an array of ints, we'll say that a triple is a value appearing 3 times 
        //in a row in the array. Return true if the array does not contain any triples. 

        public bool NoTriples(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i] == numbers[i + 2])
                    return false;
            }
            return true;
            throw new NotImplementedException();
        }





        //Given an array of ints, return true if it contains a 2, 7, 1 pattern -- 
        //a value, followed by the value plus 5, followed by the value minus 1.

        public bool Pattern51(int[] numbers)
        {
            int yes;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] + 5 == numbers[i + 1])
                {
                    yes = numbers[i] - numbers[i + 2];
                    if (yes <= 3 && yes >= -1)
                        return true;
                }
            }
            return false;
            throw new NotImplementedException();
        }

    }
}
