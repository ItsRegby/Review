using System;

namespace EndProject.core
{
    public class Position : ICloneable
    {
        public int x;
        public int y;

        public Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public object Clone()
        {
            return new Position(x, y);
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   x == position.x &&
                   y == position.y;
        }

        public void IndexesFromArray(int[] indexes)
        {
            x = indexes[0];
            y = indexes[1];
        }

    }
}
