using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ContainerTypeTests
    {
        

        [Fact]
        public void Should_ReturnTrue_When_TheContainerHasValuablesAndIfItWillBePlacedInFrontOrInTheBack()
        {
            //Arrange
            Container containerCoolAndVal = new Container(4, true, true);
            Container containerVal = new Container(4, true, false);
            ContainerRow row = new ContainerRow(5, 5, 5);

            //Act
            bool resultCoolAndValInFront = row.CanPlaceCoolingOrValuables(containerCoolAndVal, 1, 5);
            bool resultCoolAndValNotInFront = row.CanPlaceCoolingOrValuables(containerCoolAndVal, 2, 5);

            bool resultValInFront = row.CanPlaceCoolingOrValuables(containerVal, 1, 5);
            bool resultValInBack = row.CanPlaceCoolingOrValuables(containerVal, 5, 5);
            bool resultValNotInFrontOrBack = row.CanPlaceCoolingOrValuables(containerVal, 2, 5);
            
            //Assert
            Assert.True(resultCoolAndValInFront);
            Assert.False(resultCoolAndValNotInFront);

            Assert.True(resultValInFront);
            Assert.True(resultValInBack);
            Assert.False(resultValNotInFrontOrBack);
        }

        [Fact]
        public void Should_ReturnFalse_When_PlaceingOnValuablesOnValuables()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container containerCoolAndVal = new Container(4, true, true);
            Container containerVal = new Container(4, true, false);
            column.containerStack.Add(new Container(4, true, true));
            
            //Act
            bool resultVal = column.PlaceingWontDestroyValuables(containerVal);
            bool resultCoolAndVal = column.PlaceingWontDestroyValuables(containerCoolAndVal);

            //Assert
            Assert.False(resultVal);
            Assert.False(resultCoolAndVal);
        }

        [Fact]
        public void Should_ReturnTrue_When_PlaceingValuablesOnAStackWithoutValuables()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            Container containerCoolAndVal = new Container(4, true, true);
            Container containerVal = new Container(4, true, false);
            column.containerStack.Add(new Container(4, false, true));

            //Act
            bool resultVal = column.PlaceingWontDestroyValuables(containerVal);
            bool resultCoolAndVal = column.PlaceingWontDestroyValuables(containerCoolAndVal);

            //Assert
            Assert.True(resultVal);
            Assert.True(resultCoolAndVal);
        }

    }
}
