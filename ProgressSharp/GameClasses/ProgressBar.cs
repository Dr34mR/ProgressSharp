using System;

namespace ProgressSharp.GameClasses
{
    public class ProgressBar
    {
        public delegate void ProgressEventHandler(object sender, ProgressArgs args);

        public event ProgressEventHandler ProgressChanged;

        public float Position { get; set; }
        public int Max { get; set; }

        public void Reset(int newMax, float position = 0)
        {
            Position = position;
            Max = newMax;
            ProgressChanged?.Invoke(this, new ProgressArgs());
        }

        public bool Done()
        {
            return Position >= Max;
        }

        public void Increment(float increment)
        {
            Reposition(Position + increment);
        }

        public void Reposition(float newPos)
        {
            var newPosition = Math.Min(newPos, Max);

            Position = newPosition;
            ProgressChanged?.Invoke(this, new ProgressArgs());
        }
    }
}
