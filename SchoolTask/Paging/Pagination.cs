using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTask.Paging
{
    public class Pagination
    {
        
        public int TotalItems { get; }
        public int CurrentPage { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int NextPage { get; }
        public int PreviewsPage { get;  }
        public int Skip { get; }
        
        public Pagination(int totalItems, int currentPage = 1, int pageSize = 10)
        {
            // calculate total pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            
            // ensure current page isn't out of range
            if (currentPage >= 1)
            {
                if (currentPage > totalPages)
                {
                    currentPage = totalPages;
                }
            }
            else
            {
                currentPage = 1;
            }

            // Get the next and preview page
            var nextPage = currentPage + 1;
            var previewsPage = currentPage - 1;
            
            // Get the skip value
            var skip = (currentPage - 1) * pageSize;

            // Update object instance with all pagination properties required by the view
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            NextPage = nextPage;
            PreviewsPage = previewsPage;
            Skip = skip;
        }
    }
}