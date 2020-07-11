using rover.Constants;
using rover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace rover.Entities
{
    public class Plateau : ILandingSurface, IPlateau
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        #region [-Parameterized Constructor-]
        public Plateau(string plateauCoordinates)
        {
            if (string.IsNullOrEmpty(plateauCoordinates))
                throw new ArgumentException(ErrorMessages.ERR_MISSING_PLATEAU_COORDINATES);

            DecodePlateauInputMessage(plateauCoordinates);
        }
        #endregion

        #region [-Public Methods-]
        /// <summary>
        /// This method is used to decode plateau input message
        /// </summary>
        /// <param name="plateauCoordinates">plateau coordinates -- separated by space</param>
        public void DecodePlateauInputMessage(string plateauCoordinates)
        {
            string[] coordinates = plateauCoordinates.Split(AppConstants.MESSAGESEPERATOR);
            if (coordinates.Length != 2) {
                throw new ArgumentException(ErrorMessages.ERR_INVALID_PLATEAU_COORDINATES);
            }

            int width, height;
            int.TryParse(coordinates[AppConstants.XCOORDINATEIDX], out width);
            int.TryParse(coordinates[AppConstants.YCOORDINATEIDX], out height);
            Width = width;
            Height = height;
        }
        #endregion
    }
}
