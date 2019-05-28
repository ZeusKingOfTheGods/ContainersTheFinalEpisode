﻿using ContainerOpdrachtVersion3;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ShipTests
    {
        [Fact]
        public void Should_Add200ContainersToList_When_Adding200Containers()
        {
            //Arrange
            Ship ship = new Ship(5, 5, 5, 1000);
            for (int i = 0; i < 200; i++)
            {
                ship.AddContainer(20, false, false);
            }

            //Act
            int containerCount = ship.ContainersLookingForLocation.Count;

            //Assert
            Assert.True(containerCount == 200);
        }
    }
}
