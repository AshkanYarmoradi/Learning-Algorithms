using System;

namespace LearningAlgorithms.Generators
{
    public class ArrayGenerator: IArrayGenerator
    {
        private readonly Random _random;

        public ArrayGenerator()
        {
            _random = new Random();
        }

        public T[] Generate<T>(uint lenght) where T: struct
        {
            var result = new T[lenght];
            
            for (var i = 0; i < lenght; i++)
            {
                result[i] = _random.Next() as dynamic;
            }

            return result;
        }
    }
}