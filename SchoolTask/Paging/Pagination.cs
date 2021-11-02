using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTask.Paging
{
    public class Pager
    {
        
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int NextPage { get; private set; }
        public int PreviewsPage { get; private set; }
        public int Skip { get; private set; }
        public IEnumerable<int> Pages { get; private set; }
        
        public Pager(int totalItems, int currentPage = 1, int pageSize = 10, int maxPages = 10)
        {
            // calculate total pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            
            // ensure current page isn't out of range
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            else if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }
 
            int startPage, endPage;
            if (totalPages <= maxPages) 
            {
                // total pages less than max so show all pages
                startPage = 1;
                endPage = totalPages;
            }
            else 
            {
                // total pages more than max so calculate start and end pages
                var maxPagesBeforeCurrentPage = (int)Math.Floor((decimal)maxPages / (decimal)2);
                var maxPagesAfterCurrentPage = (int)Math.Ceiling((decimal)maxPages / (decimal)2) - 1;
                if (currentPage <= maxPagesBeforeCurrentPage) 
                {
                    // current page near the start
                    startPage = 1;
                    endPage = maxPages;
                } 
                else if (currentPage + maxPagesAfterCurrentPage >= totalPages) 
                {
                    // current page near the end
                    startPage = totalPages - maxPages + 1;
                    endPage = totalPages;
                }
                else 
                {
                    // current page somewhere in the middle
                    startPage = currentPage - maxPagesBeforeCurrentPage;
                    endPage = currentPage + maxPagesAfterCurrentPage;
                }
            }

            // Get the next and preview page
            int nextPage = currentPage + 1;
            int previewsPage = currentPage - 1;
            
            // create an array of pages that can be looped over
            var pages = Enumerable.Range(startPage, (endPage + 1) - startPage);
            
            // Get the skip value
            var skip = (currentPage - 1) * pageSize;

            // update object instance with all pager properties required by the view
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            NextPage = nextPage;
            Skip = skip;
            PreviewsPage = previewsPage;
            Pages = pages;
        }
    }
}