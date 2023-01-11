using System;

namespace SeaBattle
{
    public class PlacementException : Exception
    {
        public PlacementException(string message)
            : base(message) { }
    }
}
