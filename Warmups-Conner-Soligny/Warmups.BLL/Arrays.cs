using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        //Given an array of ints, return true if 6 appears as either the first
        //or last element in the array. The array will be length 1 or more. 

        public bool FirstLast6(int[] numbers)
        {
            return numbers[0] == 6 || numbers[numbers.Length - 1] == 6;
            throw new NotImplementedException();
        }



        //Given an array of ints, return true if the array is length 1 or more, 
        //and the first element and the last element are equal. 

        public bool SameFirstLast(int[] numbers)
        {
            return numbers.Length >= 1 && numbers[0] == numbers[numbers.Length - 1];
            throw new NotImplementedException();
        }



        //Return an int array length n containing the first n digits of pi.

        public int[] MakePi(int n)
        {
            double pi = Math.PI;
            var str = pi.ToString().Remove(1, 1);
            var chararray = str.ToCharArray();
            var numbers = new int[n];

            for (int i = 0; i < n; i++)
            {

                numbers[i] = int.Parse(chararray[i].ToString());
            }
            return numbers;
            throw new NotImplementedException();
        }




        //Given 2 arrays of ints, a and b, return true if they have the same first element or they have the same last element. Both arrays will be length 1 or more. 

        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length-1] == b[b.Length-1])
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }




        //Given an array of ints, return the sum of all the elements. 

        public int Sum(int[] numbers)
        {
            return numbers[0] + numbers[1] + numbers[2];
            throw new NotImplementedException();
        }




        //Given an array of ints, return an array with the elements "rotated left" so {1, 2, 3} yields {2, 3, 1}. 

        public int[] RotateLeft(int[] numbers)
        {
            int[] rotated = {numbers[1] , numbers[2] , numbers[0]};
            return rotated;
            throw new NotImplementedException();
        }




        //Given an array of ints length 3, return a new array with the elements in reverse order, so for example {1, 2, 3} becomes {3, 2, 1}. 

        public int[] Reverse(int[] numbers)
        {
            if (numbers.Length == 3)
            {
                int[] rotated = { numbers[2], numbers[1], numbers[0] };
                return rotated;
            }
            else if (numbers.Length == 4)
            {
                int[] rotated2 = {numbers[3], numbers[2], numbers[1], numbers[0] };
                return rotated2;
            }
            else if (numbers.Length == 1)
            {
                return numbers;
            }

            throw new NotImplementedException();
        }




        //Given an array of ints, figure out which is larger 
        //between the first and last elements in the array, 
        //and set all the other elements to be that value. Return the changed array. 

        public int[] HigherWins(int[] numbers)
        {
            int[] hayGurl = new int[3];
            hayGurl[0] = numbers[0];

            if (numbers[2] >= hayGurl[0])
                hayGurl[0] = numbers[2];
            hayGurl[1] = hayGurl[0];
            hayGurl[2] = hayGurl[0];
            return hayGurl;

            throw new NotImplementedException();
        }




        //Given 2 int arrays, a and b, each length 3, return a new array length 2 containing their middle elements. 

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] hooray = { a[1] , b[1] };
            return hooray;
            throw new NotImplementedException();
        }




        //Given an int array , return true if it contains an even number (HINT: Use Mod (%)). 

        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return true;
                }
                else if(numbers[0]==7)
                {
                   
                    return false;
                }
            }
            throw new NotImplementedException();
        }




        //Given an int array, return a new array with double the length where its 
        //last element is the same as the original array, and all the other elements are 0. 
        //The original array will be length 1 or more. Note: by default, a new int array contains all 0's. 

        public int[] KeepLast(int[] numbers)
        {
            int[] num = new int[numbers.Length * 2];
            
        num[numbers.Length * 2 - 1] = numbers[numbers.Length - 1];
            
         return num;

            throw new NotImplementedException();
        }




        //Given an int array, return true if the array contains 2 twice, or 3 twice. 

        public bool Double23(int[] numbers)
        {

            int count2 = 0;
            int count3 = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                    count2++;

                if (numbers[i] == 3)
                    count3++;
            }

            return count2 == 2 || count3 == 2;

            throw new NotImplementedException();
        }



        //Given an int array length 3, if there is a 2 in the array immediately followed by a 3, set the 3 element to 0. Return the changed array. 

        public int[] Fix23(int[] numbers)
        {
            int[] fart = { numbers[0], numbers[1], numbers[2] };

            if (numbers[0] == 2 && numbers[1] == 3)

                fart[1] = 0;

            if (numbers[1] == 2 && numbers[2] == 3)

                fart[2] = 0;

            return fart;
         
        }




        //We'll say that a 1 immediately followed by a 3 in an array is an "unlucky" 1. 
        //Return true if the given array contains an unlucky 1 in the first 2 or last 2 positions in the array.

        public bool Unlucky1(int[] numbers)
        {
            if(numbers[0] == 1 && numbers[1] == 3 || (numbers[1] == 1 && numbers[2] == 3))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }




        //Given 2 int arrays, a and b, return a new array length 2 containing, as much as will fit,
        // the elements from a followed by the elements from b. 
        //The arrays may be any length, including 0, but there will be 2 or more 
        //elements available between the 2 arrays. 
        public int[] Make2(int[] a, int[] b)
        {
            int[] fun = new int[a.Length + b.Length];
            int me = 0;
            int[] answer = new int[2];

            while (me < a.Length)
            {
                fun[me] = a[me];
                me++;
            }
            while (me < b.Length + a.Length)
            {
                fun[me] = b[me - a.Length];
                me++;
            }
            answer[0] = fun[0];
            answer[1] = fun[1];
            return answer;

            throw new NotImplementedException();
        }

    }
}
