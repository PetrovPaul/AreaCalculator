using System;

namespace AreaCalculator
{
    public class Circle : IAreable
    {
        private readonly double _radius;
        public Circle(double radius) {
            if (radius.CompareTo(0) <= 0) 
                throw new ArgumentException("Радиус круга должен быть больше нуля.");
            _radius = radius;
        } 
        /// <summary>
        /// Вычисление площади круга
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            return Math.PI * _radius * _radius;
        }
    }
}
