using System.Collections.Generic;

namespace BookHelper
{
    internal class Book
    {
        private readonly List<PagesRange> _readPages = new List<PagesRange>();

        public readonly int PagesCount;

        public Book(int pagesCount)
        {
            PagesCount = pagesCount;
        }

        public void AddRange(int from, int to)
        {
            _readPages.Add(new PagesRange(from, to));
        }

        public int HowManyPagesLeft()
        {
            // TODO 3: Improve/fix the code here.
            HashSet<int> readPagesSet = new HashSet<int>();
            foreach (var range in _readPages)
            {
                for (int i = range.From; i <= range.To; i++)
                    readPagesSet.Add(i);
            }

            var readPagesNumber = 0;
            for (var page = 1; page <= PagesCount; page++)
            {
                if(readPagesSet.Contains(page))
                    readPagesNumber++;
            }

            var leftPages = PagesCount - readPagesNumber;
            return leftPages;
        }
    }
}
