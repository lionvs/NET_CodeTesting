namespace BookHelper
{
    internal struct PagesRange
    {
        public readonly int From;
        public readonly int To;

        public PagesRange(int from, int to)
        {
            From = from;
            To = to;
        }
    }
}