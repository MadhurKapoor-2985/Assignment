using Assignment.Business;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AssignmentTestProject
{
    public class LogicTests
    {
        [Fact]
        public void CheckAscendingSort()
        {
            var logic = new Logic();
 
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
                },
                
                new Rectangle()
                {
                    Length = 10,
                    Width = 10
                }
            };

            var result = logic.SortRectangle(rectangles, "asc");
            Assert.Equal(1, result[0].Length);
            Assert.Equal(2, result[0].Width);

        }

        [Fact]
        public void CheckDescendingSort()
        {
            var logic = new Logic();

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
                },

                new Rectangle()
                {
                    Length = 10,
                    Width = 10
                }
            };

            var result = logic.SortRectangle(rectangles, "desc");
            Assert.Equal(10, result[0].Length);
            Assert.Equal(10, result[0].Width);

        }
    }
}
