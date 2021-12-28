using Assignment.Models;
using System.Collections.Generic;

namespace Assignment.Business
{
    public interface ILogic
    {
        List<Rectangle> SortRectangle(List<Rectangle> rectangleList, string sortBy);

    }
}
