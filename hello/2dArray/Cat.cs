using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello._2dArray
{
    class Cat : Animal, IAnimal
    {
        public Cat()
        {
            Height = GenerateRandom(20, 35);
            Weight = GenerateRandom(5, 12);
        }
    }
}
