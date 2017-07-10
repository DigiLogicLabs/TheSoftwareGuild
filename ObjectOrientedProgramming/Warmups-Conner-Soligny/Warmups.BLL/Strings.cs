using System;

namespace Warmups.BLL
{
    public class Strings
    {
        
        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }




        //Given two strings, a and b, return the result of putting them together in the order abba, e.g. 
        //"Hi" and "Bye" returns "HiByeByeHi". 

        public string Abba(string a, string b)
        {
            return (a + b + b + a);
            throw new NotImplementedException();
        }




        //The web is built with HTML strings like "<i>Yay</i>" which draws Yay as italic text. 
        //In this example, the "i" tag makes <i> and </i> which surround the word "Yay". 
        //Given tag and word strings, create the HTML string with tags around the word, e.g. "<i>Yay</i>". 

        public string MakeTags(string tag, string content)
        {
            return ("<"+tag+">" + content + "</"+tag+">");
            throw new NotImplementedException();
        }



        //Given an "out" string length 4, such as "<<>>", and a word, 
        //return a new string where the word is in the middle of the out string, e.g. "<<word>>".
//Hint: Substrings are your friend here


        public string InsertWord(string container, string word)
        {
            return (container.Substring(0, 2)) + word + container.Substring(2, 2);
            
            
            throw new NotImplementedException();
        }


        //Given a string, return a new string made of 3 copies of the last 2 chars of the original string. 
        //The string length will be at least 2. 

        public string MultipleEndings(string str)
        {
            if (str.Length <= 3)
            {
                int ayy = str.Length;
                string bee = str.Substring(ayy - 2, ayy);
                return (bee + bee + bee);
            }
            else
                return str.Substring(3, 2) + str.Substring(3, 2) + str.Substring(3, 2);
            throw new NotImplementedException();
        }



        //Given a string of even length, return the first half. So the string "WooHoo" yields "Woo". 
        public string FirstHalf(string str)
        {

                return (str.Substring(0,str.Length/2));
            
            throw new NotImplementedException();
        }



        //Given a string, return a version without the first and last char, so 
        //"Hello" yields "ell". The string length will be at least 2. 

        public string TrimOne(string str)
        {

            return (str.Substring(1, str.Length - 2));
            throw new NotImplementedException();
        }





        //Given 2 strings, a and b, return a string of the form short+long+short, 
        //with the shorter string on the outside and the longer string on the inside. 
        //The strings will not be the same length, but they may be empty (length 0). 

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return b + a + b;
            }
            else
            {
                return a + b + a;
            }
            throw new NotImplementedException();
        }





        //Given a string, return a "rotated left 2" version where the first 2 chars are moved to the end. 
        //The string length will be at least 2. 

        public string RotateLeft2(string str)
        {
            if (str.Length > 2)
            {
                string bruh = str.Substring(0, 2);
                return str.Substring(2) + bruh;
            }
            else
            {
                return str;
            }
            throw new NotImplementedException();
        }



        //Given a string, return a "rotated right 2" version where the last 2 chars are moved to the start. The string length will be at least 2. 



        public string RotateRight2(string str)
        {
            if (str.Length > 2)
            {
                int bruh = str.Length - 2;
                return  str.Substring(bruh) + str.Substring(0 , bruh);
            }
            else
            {
                return str;
            }
            throw new NotImplementedException();
        }





        //Given a string, return a string length 1 from its front, unless front is false, 
        //in which case return a string length 1 from its back. The string will be non-empty. 

        public string TakeOne(string str, bool fromFront)
        {
            string newString = str.Substring(0, 1);

            if (fromFront == true)
            {
                
                return newString;

            }
            else
            {
               
            }
            return str.Substring(str.Length-1,1);
            
        }






        //Given a string of even length, return a string made of the middle two chars, so the string "string" yields "ri". The string length will be at least 2. 

        public string MiddleTwo(string str)
        {
            return str.Substring((str.Length / 2) - 1, 2);
            throw new NotImplementedException();
        }





        //Given a string, return true if it ends in "ly". 

        public bool EndsWithLy(string str)
        {
            if(str.EndsWith("ly"))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }





        //Given a string and an int n, return a string made of the first and 
        //last n chars from the string. The string length will be at least n. 
                  
            
        public string FrontAndBack(string str, int n)
        {
            int iThinkIGotit = str.Length;

            return str.Substring(0, n) + str.Substring(iThinkIGotit - n);
            
        }






        //Given a string and an index, return a string length 2 starting at the given index. If the index is too big or too small to define a string length 2, use the first 2 chars. The string length will be at least 2. 

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n + 2 > str.Length)
            {
                return str.Substring(0, 2);
            }
            else
            {
                return str.Substring(n, 2);
            }
            
            throw new NotImplementedException();
        }






        //Given a string, return true if "bad" appears starting at index 0 or 1 in the string, 
        //such as with "badxxx" or "xbadxx" but not "xxbadxx". The string may be any length, including 0.

        public bool HasBad(string str)
        {

            if (str.Length >= 4)
            {
                return str.Substring(0, 3).Equals("bad") ||
                      str.Substring(1, 3).Equals("bad");
            }

            else if (str.Length == 3)

                return str.Substring(0, 3).Equals("bad");
            return false;
            throw new NotImplementedException();
        }




        //Given a string, return a string length 2 made of its first 2 chars. 
        //If the string length is less than 2, use '@' for the missing chars. 

        public string AtFirst(string str)
        {
            int bruh = str.Length;
            if (bruh >= 2)
                return str.Substring(0, 2);
            else if (bruh == 1)
                return (str.Substring(0) + "@");
            else
                return "@@";
            throw new NotImplementedException();
        }




        //Given 2 strings, a and b, return a new string made of the 
        //first char of a and the last char
        // of b, so "yo" and "java" yields "ya". If either string is length 0, 
        //use '@' for its missing char. 

        public string LastChars(string a, string b)
        {

            int lengthOfB = b.Length;
            string combinedString = "";


                combinedString += (a.Length >= 1) ? a[0] : '@';
            combinedString += (lengthOfB >= 1) ? b[lengthOfB - 1] : '@';

            return combinedString;
        }




        //Given two strings, append them together (known as "concatenation") 
        //and return the result. However, if the concatenation creates a double-char, 
        //then omit one of the chars, so "abc" and "cat" yields "abcat". 


           
        public string ConCat(string a, string b)
        {
            int ia = a.Length;
            int ib = b.Length;

            if (ia >= 1 && ib >= 1)
            {
                if (a[ia - 1] == b[0])
                {
                    return (a + b.Substring(1));
                }
                else
                    return (a + b);
            }


            else return a += b;

        }





        //Given a string of any length, return a new string where the last 2 chars, 
        //if present, are swapped, so "coding" yields "codign". 

        public string SwapLast(string str)
        {
            int holy = str.Length;
            if(holy >=2)
            {
                return str.Substring(0, holy - 2) + str.Substring(holy - 1) + str.Substring(holy-2,1);
                
            }
            else { return str; }
            throw new NotImplementedException();
        }





        //Given a string, return true if the first 2 chars in the string 
        //also appear at the end of the string, such as with "edited". 

        public bool FrontAgain(string str)
        {
            if(str.Substring(0,2) == str.Substring(str.Length-2,2))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }





        //Given two strings, append them together (known as "concatenation") 
        //and return the result. However, if the strings are different lengths, 
        //omit chars from the longer string so it is the same length as the shorter string. 
        //So "Hello" and "Hi" yield "loHi". The strings may be any length. 

        public string MinCat(string a, string b)
        {
            int holy = a.Length;
            int moly = b.Length;
            if (holy >= moly)
            {
                return (a.Substring(holy - moly) + b);
            }
            else
            {
                return (a + b.Substring(moly - holy));
            }
        }






        //Given a string, return a version without the first 2 chars. 
        //Except keep the first char if it is 'a' and keep the second char if it is
        //'b'. The string may be any length.

        public string TweakFront(string str)
        {
            if (str == null || str.Length < 2) return "";

            bool keepFirst = str[0] == 'a';
            bool keepSecond = str[1] == 'b';
            
            if (!keepFirst && !keepSecond)
            {
                return str.Substring(2);
            }
            else if (!keepFirst && keepSecond)
            {
                return str.Substring(1);
            }
            else if (keepFirst && keepSecond)
            {
                return str.Substring(0);
            }
            else if (keepFirst && !keepSecond)
            {
                return str.Substring(0, 1) + str.Substring(2, str.Length - 2);
            }
            else return str;
        }
        





        //Given a string, if the first or last chars are 'x', 
        //return the string without those 'x' chars, and otherwise 
        //return the string unchanged. 

        public string StripX(string str)
        {
            string toReturn = "";

            if (str.Length > 0)
            {
                if (str.Length > 1)
                {
                   
                    toReturn = str.Substring(1, str.Length - 2);

                    if (str[0] != 'x')
                    {
                        toReturn = str[0] + toReturn;
                    }
                    if (str[str.Length-1] != 'x')
                    {
                        toReturn = toReturn + str[str.Length - 1];
                    }

               
                }
                else if (str != "x")
                    
                {
                    toReturn = str;
                }
            }

            
            return toReturn;
                
        }
    }
}
