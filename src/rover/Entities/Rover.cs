using rover.Constants;
using rover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace rover.Entities
{
    public class Rover : IRover
    {
        #region [-Public Properties-]
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Direction { get; set; }
        #endregion

        #region [-Parameterized Constructor-]
        public Rover(ILandingSurface landingSurface, string roverPosition, string roverCommands)
        {
            // translate rover position
            ProcessingRoverPosition(roverPosition);

            // verify rover's coordinates against the landing surface coordinates
            if (!ValidateRoverPosition(landingSurface)) 
                throw new ArgumentException(ErrorMessages.ERR_COORDINATES_OUTOFRANGE);
            
            // process rover commands
            ProcessingRoverCommands(roverCommands);
        }
        #endregion

        #region [-Public Methods-]
        /// <summary>
        /// This method is used to translate rover commands / instructions
        /// </summary>
        /// <param name="roverCommands">rover's instructions</param>
        public void ProcessingRoverCommands(string roverCommands)
        {
            if (string.IsNullOrEmpty(roverCommands))
                throw new ArgumentException(ErrorMessages.ERR_MISSING_COMMAND);

            char[] commands = roverCommands.ToCharArray();

            foreach (char command in commands)
            {
                switch (command.ToString())
                {
                    case Commands.MOVEFORWARD:
                        this.MoveRoverForward();
                        break;

                    default:
                        this.RotateRover(command.ToString());
                        break;
                }
            }
        }

        /// <summary>
        /// This method is used to translate rover coordinates and it's heading
        /// </summary>
        /// <param name="roverPosition">rover's coordinates and its position - separated by space</param>
        public void ProcessingRoverPosition(string roverPosition)
        {
            if (string.IsNullOrEmpty(roverPosition))
                throw new ArgumentException(ErrorMessages.ERR_MISSING_COORDINATE_DIRECTION);
            
            string[] splitMessage = roverPosition.Split(AppConstants.MESSAGESEPERATOR);

            int coordinateX, coordinateY;
            
            int.TryParse(splitMessage[AppConstants.XCOORDINATEIDX], out coordinateX);
            XCoordinate = coordinateX;
            
            if (splitMessage.Length < 2)
                throw new ArgumentException(ErrorMessages.ERR_MISSING_COORDINATE);

            int.TryParse(splitMessage[AppConstants.YCOORDINATEIDX], out coordinateY);
            YCoordinate = coordinateY;
            
            if (splitMessage.Length < 3)
                throw new ArgumentException(ErrorMessages.ERR_MISSING_DIRECTION);

            ValidateAndSetRoverDirection(Convert.ToString(splitMessage[AppConstants.FACINGDIRECTIONIDX]));

        }

        /// <summary>
        /// This method is used to validate rover position against the landing surface
        /// </summary>
        /// <param name="landingSurface">landing surface coordinates</param>
        /// <returns>return bool value as per the results of this check </returns>
        public bool ValidateRoverPosition(ILandingSurface landingSurface)
        {
            if (landingSurface == null)
                throw new ArgumentException(ErrorMessages.ERR_MISSING_PLATEAU_COORDINATES);

            return (XCoordinate >= 0) && (XCoordinate < landingSurface.Width) &&
                (YCoordinate >= 0) && (YCoordinate < landingSurface.Height);
        }

        #endregion

        #region [-Private Methods-]
        private void RotateRover(string direction)
        {
            switch (direction.ToUpper())
            {
                case Commands.ROTATELEFT:
                    this.TurnRoverLeft();
                    break;

                case Commands.ROTATERIGHT:
                    this.TurnRoverRight();
                    break;

                default:
                    throw new ArgumentException(ErrorMessages.ERR_INVALID_COMMAND);
            }
        }

        private void TurnRoverRight()
        {
            switch (this.Direction)
            {
                case Face.NORTH:
                    this.Direction = Face.EAST;
                    break;

                case Face.EAST:
                    this.Direction = Face.SOUTH;
                    break;

                case Face.SOUTH:
                    this.Direction = Face.WEST;
                    break;

                case Face.WEST:
                    this.Direction = Face.NORTH;
                    break;
            }
        }

        private void TurnRoverLeft()
        {
            switch (this.Direction)
            {
                case Face.NORTH:
                    this.Direction = Face.WEST;
                    break;

                case Face.WEST:
                    this.Direction = Face.SOUTH;
                    break;

                case Face.SOUTH:
                    this.Direction = Face.EAST;
                    break;

                case Face.EAST:
                    this.Direction = Face.NORTH;
                    break;
            }
        }

        private void MoveRoverForward()
        {
            switch (this.Direction)
            {
                case Face.NORTH:
                    this.YCoordinate += 1;
                    break;

                case Face.EAST:
                    this.XCoordinate += 1;
                    break;

                case Face.SOUTH:
                    this.YCoordinate -= 1;
                    break;

                case Face.WEST:
                    this.XCoordinate -= 1;
                    break;
            }
        }

        /// <summary>
        /// This method is used to validate and set rover direction 
        /// </summary>
        /// <param name="direction">rover's direction / heading </param>
        private void ValidateAndSetRoverDirection(string direction)
        {
            switch (direction.ToUpper())
            {
                case Face.WEST:
                case Face.SOUTH:
                case Face.NORTH:
                case Face.EAST:
                    Direction = direction;
                    break;
                default:
                    throw new ArgumentException(ErrorMessages.ERR_INVLID_DIRECTION);
            }
        }

        #endregion
    }
}
