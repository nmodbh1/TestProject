using rover.Constants;
using rover.Entities;
using rover.Interfaces;
using rovertest.TestData;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace rovertest
{
    public class MarsRoverUnitTest
    {
        private readonly ITestOutputHelper testOutputHelper;

        public MarsRoverUnitTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void RoverSquadPositiveTestcase_BothRoversAvailable()
        {
            ILandingSurface surface = new Plateau("5 5");
            RoverSquad rovSquad = new RoverSquad(surface);

            rovSquad.PlaceRover("1 2 N", "LMLMLMLMM");
            rovSquad.PlaceRover("3 3 E", "MMRMMRMRRM");

            int totalRovers = 2;

            Assert.True(rovSquad.Count.Equals(totalRovers));

            IRover rover1 = rovSquad[0];
            IRover rover2 = rovSquad[1];

            Assert.NotNull(rover1);
            Assert.NotNull(rover2);
        }
        [Fact]
        public void RoverSquadNegativeTestcase_SecondRoverNotAvailable()
        {
            ILandingSurface surface = new Plateau("5 5");
            RoverSquad rovSquad = new RoverSquad(surface);

            rovSquad.PlaceRover("1 2 N", "LMLMLMLMM");

            int totalRovers = 2;

            Assert.False(rovSquad.Count.Equals(totalRovers));

            IRover rover1 = rovSquad[0];
            IRover rover2 = null;

            Assert.NotNull(rover1);
            Assert.Null(rover2);
        }
        [Theory]
        [ClassData(typeof(PlateauTestDataFail))]
        public void PlateauCoordinatesNegativeTestCases(string plateauCoordinates, string expectedResults)
        {
            ILandingSurface surface = null;
            Exception ex = Assert.Throws<ArgumentException>(() => surface = new Plateau(plateauCoordinates));
            Assert.Equal(expectedResults, ex.Message);

            testOutputHelper.WriteLine($"Output : {expectedResults}");
        }
        [Theory]
        [ClassData(typeof(MarsRoverTestDataPass))]
        public void PlaceRoverPositiveTestCases(string roverPosition, string roverCommands, string expectedResults)
        {
            ILandingSurface surface = new Plateau("5 5");
            RoverSquad rovSquad = new RoverSquad(surface);

            rovSquad.PlaceRover(roverPosition, roverCommands);
            
            IRover rover = rovSquad[0];

            string[] splitExpectedResults = expectedResults.Split(AppConstants.MESSAGESEPERATOR);

            Assert.True(rover.XCoordinate == Convert.ToInt32(splitExpectedResults[0]));
            Assert.True(rover.YCoordinate == Convert.ToInt32(splitExpectedResults[1]));
            Assert.True(rover.Direction == splitExpectedResults[2]);

            testOutputHelper.WriteLine($"{rover.XCoordinate} {rover.YCoordinate} {rover.Direction}");
        }
        [Theory]
        [ClassData(typeof(MarsRoverTestDataFail))]
        public void PlaceRoverNegativeTestCases(string roverPosition, string roverCommands, string expectedResults)
        {
            ILandingSurface surface = new Plateau("5 5");
            RoverSquad rovSquad = new RoverSquad(surface);

            Exception ex = Assert.Throws<ArgumentException>(() => rovSquad.PlaceRover(roverPosition, roverCommands));
            Assert.Equal(expectedResults,ex.Message);

            testOutputHelper.WriteLine($"Output : {expectedResults}");
        }
    }

    

}
