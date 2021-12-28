using Assignment.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Business
{
    public class Logic : ILogic
    {
        public List<Rectangle> SortRectangle(List<Rectangle> rectangleList, string sortBy)
        {
            if(sortBy == "asc")
            {
                return rectangleList.OrderBy(x => x.Length * x.Width).ToList();
            }
            else
            {
                return rectangleList.OrderByDescending(x => x.Length * x.Width).ToList();
            }
        }
    }
}
