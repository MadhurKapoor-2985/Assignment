using Assignment.Business;
using Assignment.Controllers;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AssignmentTestProject
{
    public class ControllerTests
    {
        [Fact]
        public void Get_InvalidSortType_ThrowsNotFound()
        {
            var logic = new Mock<ILogic>();
            var controller = new RectangleController(logic.Object);

            var rectangles = new List<Rectangle>
            {
                new Rectangle()
                {
                    Length = 5,
                    Width = 10
                },
                new Rectangle()
                {
                    Length = 1,
                    Width = 2
                }
            };

            var result = controller.Sort(rectangles, "abc");
            Assert.IsType<BadRequestResult>(result);
            
        }

        [Fact]
        public void Get_Exception_ThrowsInternalServerError()
        {
            var logic = new Mock<ILogic>();
            var controller = new RectangleController(logic.Object);

            var rectangles = new List<Rectangle>
            {
                new Rectangle()
                {
                    Length = 5,
                    Width = 10
                },
                new Rectangle()
                {
                    Length = 1,
                    Width = 2
                }
            };

            logic.Setup(x => x.SortRectangle(rectangles, "asc")).Throws(new Exception());

            var result = controller.Sort(rectangles, "asc");

            var objectResult = Assert.IsType<ObjectResult>(result);

            Assert.True(objectResult.StatusCode == 500);
        }

        [Fact]
        public void Get_Return_Ok()
        {
            var logic = new Mock<ILogic>();
            var controller = new RectangleController(logic.Object);

            var rectangles = new List<Rectangle>
            {
                new Rectangle()
                {
                    Length = 5,
                    Width = 10
                },
                new Rectangle()
                {
                    Length = 1,
                    Width = 2
                }
            };

            var sortedRectangles = new List<Rectangle>
            {
                new Rectangle()
                {
                    Length = 1,
                    Width = 2
                },
                new Rectangle()
                {
                    Length = 5,
                    Width = 10
                }
            };

            logic.Setup(x => x.SortRectangle(rectangles, "asc")).Returns(sortedRectangles);

            var result = controller.Sort(rectangles, "asc");

            Assert.IsType<OkObjectResult>(result);

            
        }

        [Fact]
        public void Get_Return_DescendingSort_Ok()
        {
            var logic = new Mock<ILogic>();
            var controller = new RectangleController(logic.Object);

            var rectangles = new List<Rectangle>
            {
                new Rectangle()
                {
                    Length = 1,
                    Width = 2
                },
                new Rectangle()
                {
                    Length = 5,
                    Width = 10
                }
            };

            var sortedRectangles = new List<Rectangle>
            {
                new Rectangle()
                {
                    Length = 5,
                    Width = 10
                },
                new Rectangle()
                {
                    Length = 1,
                    Width = 2
                }
            };

            logic.Setup(x => x.SortRectangle(rectangles, "desc")).Returns(sortedRectangles);

            var result = controller.Sort(rectangles, "desc");

            Assert.IsType<OkObjectResult>(result);


        }
    }
}
