using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        //When squirrels get together for a party, they like to have cigars. 
        //A squirrel party is successful when the number of cigars is between 40 and 60, inclusive. 
        //Unless it is the weekend, in which case there is no upper bound on the number of cigars. 
        //Return true if the party with the given values is successful, or false otherwise. 

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool partyIsSuccessfulAtWeekday = 39 < cigars && cigars < 61 && !isWeekend;
            bool partyWeekend = 39 < cigars && isWeekend;

            return partyIsSuccessfulAtWeekday || partyWeekend;
            throw new NotImplementedException();
        }



        //You and your date are trying to get a table at a restaurant. 
        //The parameter "you" is the stylishness of your clothes, in the range 0..10, 
        //and "date" is the stylishness of your date's clothes. 
        //The result getting the table is encoded as an int value with 0=no, 1=maybe, 2=yes. If either of you is very stylish, 8 or more, then the result is 2 (yes). 
        //With the exception that if either of you has style of 2 or less, then the result is 0 (no). Otherwise the result is 1 (maybe). 


        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle < 3 || dateStyle < 3)
            {
                return 0;
            }
            else if (yourStyle > 7 || dateStyle > 7)
            {
                return 2;
            }
            else
            {
                return 1;
            }
            throw new NotImplementedException();
        }





        //The children in Cleveland spend most of the day playing outside. 
        //In particular, they play if the temperature is between 60 and 90 (inclusive). 
        //Unless it is summer, then the upper limit is 100 instead of 90. 
        //Given an int temperature and a boolean isSummer, return true if the children 
        //play and false otherwise. 

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (isSummer)
            {
                return 60 <= temp && temp <= 100;
            }
            else
            {
                return 60 <= temp && temp <= 90;
            }
            throw new NotImplementedException();
        }






        //You are driving a little too fast, and a police officer stops you. 
        //Write code to compute the result, encoded as an int value: 
        //0=no ticket, 1=small ticket, 2=big ticket. If speed is 60 or less, 
        //the result is 0. If speed is between 61 and 80 inclusive, the result is 1. 
        //If speed is 81 or more, the result is 2. Unless it is your birthday -- 
        //on that day, your speed can be 5 higher in all cases. 

        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int noTicket = 0;
            int smallTicket = 1;
            int bigTicket = 2;
            int receivedTicket = -1;

            if (!isBirthday)
            {
                if (speed <= 60)
                {
                    receivedTicket = noTicket;
                }
                else if (speed <= 80)
                {
                    receivedTicket = smallTicket;
                }
                else
                {
                    receivedTicket = bigTicket;
                }
            }
            else
            {
                if (speed <= 65)
                {
                    receivedTicket = noTicket;
                }
                else if (speed <= 85)
                {
                    receivedTicket = smallTicket;
                }
                else
                {
                    receivedTicket = bigTicket;
                }
            }

            return receivedTicket;

            throw new NotImplementedException();
        }





        //Given 2 ints, a and b, return their sum. However, sums in the range 10..19 
        //inclusive are forbidden, so in that case just return 20. 

        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            bool sumIs = 10 <= sum && sum <= 19;

            if (sumIs)
            {
                sum = 20;
            }

            return sum;
            throw new NotImplementedException();
        }





        //Given a day of the week encoded as 0=Sun, 1=Mon, 2=Tue, ...6=Sat, 
        //and a booleanean indicating if we are on vacation, return a string of 
        //the form "7:00" indicating when the alarm clock should ring. Weekdays, 
        //the alarm should be "7:00" and on the weekend it should be "10:00". 
        //Unless we are on vacation -- then on weekdays it should be "10:00" 
        //and weekends it should be "off". 

        public string AlarmClock(int day, bool vacation)
        {
            int monday = 1;
            int friday = 5;
            bool itIsWeekday = monday <= day && day <= friday;
            String alarmTime = null;

            if (vacation)
            {
                if (itIsWeekday)
                {
                    alarmTime = "10:00";
                }
                else
                {
                    alarmTime = "off";
                }
            }
            else
            {
                if (itIsWeekday)
                {
                    alarmTime = "7:00";
                }
                else
                {
                    alarmTime = "10:00";
                }
            }

            return alarmTime;
            throw new NotImplementedException();
        }





        //The number 6 is a truly great number. Given two int values, a and b, 
        //return true if either one is 6. Or if their sum or difference is 6.

        public bool LoveSix(int a, int b)
        {
            bool conditionIsFulfilled = false;

            if (a == 6 || b == 6)
            {
                conditionIsFulfilled = true;
            }
            else if (a + b == 6)
            {
                conditionIsFulfilled = true;
            }
            else if (Math.Abs(a - b) == 6)
            {
                conditionIsFulfilled = true;
            }

            return conditionIsFulfilled;
            throw new NotImplementedException();
        }





        //Given a number n, return true if n is in the range 1..10, inclusive. 
        //Unless "outsideMode" is true, in which case return true 
        //if the number is less or equal to 1, or greater or equal to 10. 

        public bool InRange(int n, bool outsideMode)
        {
            bool inRangeNot = 1 <= n && n <= 10 && !outsideMode;
            bool inRange = (n <= 1 || 10 <= n) && outsideMode;

            return inRangeNot || inRange;
            throw new NotImplementedException();
        }





        //We'll say a number is special if it is a multiple of 11 
        //or if it is one more than a multiple of 11. Return true if the 
        //given non-negative number is special. Use the % "mod" operator

        public bool SpecialEleven(int n)
        {
            bool remainderZero = n % 11 == 0;
            bool remainderOne = n % 11 == 1;

            return remainderZero || remainderOne;
            throw new NotImplementedException();
        }




        //Return true if the given non-negative number is 1 or 2 more 
        //than a multiple of 20. See also: Introduction to Mod 


        public bool Mod20(int n)
        {
            bool reminderOne = n % 20 == 1;
            bool reminderTwo = n % 20 == 2;

            return reminderOne || reminderTwo;
            throw new NotImplementedException();
        }





        //Return true if the given non-negative number is a multiple of 3 or 5, 
        //but not both. Use the % "mod" operator

        public bool Mod35(int n)
        {
            bool three = n % 3 == 0 && n % 5 != 0;
            bool fivee = n % 3 != 0 && n % 5 == 0;

            return three || fivee;
            throw new NotImplementedException();
        }





        //Your cell phone rings. Return true if you should answer it. 
        //Normally you answer, except in the morning you only answer if it 
        //is your mom calling. In all cases, if you are asleep, you do not answer. 

        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            return (!isMorning || isMom) && !isAsleep;

            throw new NotImplementedException();
        }





        //Given three ints, a b c, return true if it is possible to add two 
        //of the ints to get the third. 

        public bool TwoIsOne(int a, int b, int c)
        {
            bool first = b + c == a;
            bool second = a + c == b;
            bool third = a + b == c;

            return third || second || first;
            throw new NotImplementedException();
        }





        //Given three ints, a b c, return true if b is greater than a, and c 
        //is greater than b. However, with the exception that if "bOk" is true, 
        //b does not need to be greater than a. 

        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            return (b > a || bOk) && c > b;
            throw new NotImplementedException();
        }





        //Given three ints, a b c, return true if they are in strict increasing order, 
        //such as 2 5 11, or 5 6 7, but not 6 5 7 or 5 5 7. 
        //However, with the exception that if "equalOk" is true, equality is allowed, 
        //such as 5 5 7 or 5 5 5. 

        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            bool strict = a < b && b < c && !equalOk;
            bool equal = a <= b && b <= c && equalOk;

            return strict || equal;
            throw new NotImplementedException();
        }





        //Given three ints, a b c, return true if two or more of them have the same 
        //rightmost digit.The ints are non-negative.

        public bool LastDigit(int a, int b, int c)
        {
            int aYa = a % 10;
            int bYa = b % 10;
            int cYa = c % 10;

            return aYa == bYa || aYa == cYa || bYa == cYa;
            throw new NotImplementedException();
        }





        //Return the sum of two 6-sided dice rolls, each in the range 1..6. 
        //However, if noDoubles is true, if the two dice show the same value, 
        //increment one die to the next value, wrapping around to 1 if its value was 6. 

        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int min = 1;
            int max = 6;

            if (noDoubles && die1 == die2)
            {
                ++die1;
                if (die2 == max)
                {
                    die1 = min;
                }
            }

            return die1 + die2;
        }

        

    }
}
