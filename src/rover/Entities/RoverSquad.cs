using rover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace rover.Entities
{
    public class RoverSquad : List<Rover>, IRoverSquad
    {
        private readonly ILandingSurface landingSurface;

        #region [-Parameterized Constructor-]
        public RoverSquad(ILandingSurface landingSurface)
        {
            this.landingSurface = landingSurface;
        }
        #endregion

        #region [-Public Methods-]
        /// <summary>
        /// This method is actually used to deploy rover
        /// </summary>
        /// <param name="roverPosition">rover coordinates with its heading</param>
        /// <param name="roverCommands">rover instruction</param>
        public void PlaceRover(string roverPosition, string roverCommands)
        {
            Add(new Rover(landingSurface, roverPosition, roverCommands));

        }
        #endregion
    }
}
