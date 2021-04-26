using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing_Game
{
    sealed class RangedRandomInteger : RandomInteger
    {
        //Adding the private fields
        private int randomNumber = 1;
        private int minimum;
        private int maximum;

        //setters for private fields
        public void setMinimum(int min)
        {
            if (min >= 1)
                minimum = min;
        }

        public void setMaximum(int max )
        {
            if (max <= 1000)
                maximum = max;
        }
        
        //getters for private fields
        public int getMinimum() { return minimum; }
        public int getMaximum() { return maximum; }

        //function to generate the random number
        public new int GenerateRandomNumber()
        {
            randomNumber = random.Next(minimum, maximum + 1);
            return randomNumber;
        }

        //default constructor
        public RangedRandomInteger()
        {
        }
        //overloaded constructor
        public RangedRandomInteger(int min, int max)
        {
            //validating the passed arguments
            setMinimum(min);
            setMaximum(max);
        }
    }
}