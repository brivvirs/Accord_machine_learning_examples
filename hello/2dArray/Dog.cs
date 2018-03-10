using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello._2dArray
{
    class Dog : Animal, IAnimal
    {
        public Dog()
        {
            Height = GenerateRandom(25, 50);
            Weight = GenerateRandom(10, 20);
        }
    }
}
