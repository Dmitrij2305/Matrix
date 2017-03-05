using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Vector
    {
        protected int count;
        public int Count
        {
            get { return count; }
        }

        protected double[] values;

        protected Vector(int count)
        {
            if (count <= 0)
                throw new ArgumentException("Count of vector elemenst must be positive");

            this.count = count;
            this.values = new double[count];
        }

        public Vector(double[] values)
        {
            this.count = values.Count();
            this.values = values;
        }

        public double this[int index]
        {
            get { return values[index]; }
        }

        public static Vector operator *(Vector vector, double factor)
        {
            Vector factored = new Vector(vector.count);
            for (int index = 0; index < vector.count; index++)
                factored.values[index] = vector.values[index] * factor;

            return factored;
        }

        public static Vector operator *(double factor, Vector vector)
        {
            return vector * factor;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if (vector1.count != vector2.count)
                throw new ArgumentException("Vectors must be the same size to be additable");

            Vector sum = new Vector(vector1.count);
            for (int index = 0; index < vector1.count; index++)
                sum.values[index] = vector1.values[index] + vector2.values[index];

            return sum;
        }

        public static Vector operator -(Vector vector)
        {
            return vector * (-1.0);
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return vector1 + vector2 * (-1.0);
        }

        public static double operator *(Vector vector1, Vector vector2)
        {
            if (vector1.count != vector2.count)
                throw new ArgumentException("Vectors must be the same size to be have multiplied");

            double product = 0;
            for (int index = 0; index < vector1.count; index++)
                product += vector1.values[index] * vector2.values[index];

            return product;
        }
    }
}
