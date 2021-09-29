using System;
using System.Collections.Generic;
using System.Linq;

namespace AreaCalculator
{
    public class Triangle : IAreable
    {
        private readonly double _firstSide;
        private readonly double _secondSide;
        private readonly double _thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;
            CheckTriangleExistence();
        }

        private void CheckTriangleExistence()
        {
            if (_firstSide.CompareTo(0) <= 0 || _secondSide.CompareTo(0) <= 0 || _thirdSide.CompareTo(0) <= 0) 
                throw new ArgumentException("Все длины сторон треугольника должны быть больше нуля.");
            if (_firstSide.CompareTo(_secondSide + _thirdSide) >= 0 ||
                _secondSide.CompareTo(_firstSide + _thirdSide) >= 0 ||
                _thirdSide.CompareTo(_firstSide + _thirdSide) >= 0)
                throw new ArgumentException("В треугольнике не может одна из сторон быть больше суммы двух других сторон.");
        }

        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            if (IsRightAngled())
            {
                var sidesList = new List<double>() { _firstSide, _secondSide, _thirdSide };
                sidesList.Remove(sidesList.Max());
                return sidesList[0] * sidesList[1] / 2;
            }
            var semiPerimeter = (_firstSide + _secondSide + _thirdSide) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - _firstSide) * (semiPerimeter - _secondSide) * (semiPerimeter - _thirdSide));
        }

        private bool IsRightAngled()
        {
            var sidesList = new List<double>() { _firstSide, _secondSide, _thirdSide };
            var longestSide = sidesList.Max();
            sidesList.Remove(longestSide);
            return longestSide * longestSide == sidesList[0] * sidesList[0] + sidesList[1] * sidesList[1];
        }
    }
}
