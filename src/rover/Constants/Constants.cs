using System;
using System.Collections.Generic;
using System.Text;

namespace rover.Constants
{
    public static class Face
    {
        public const string NORTH = "N";
        public const string EAST = "E";
        public const string SOUTH = "S";
        public const string WEST = "W";
    }
    public static class Commands
    {
        public const string MOVEFORWARD = "M";
        public const string ROTATELEFT = "L";
        public const string ROTATERIGHT = "R";
    }
    public static class AppConstants
    {
        public const char MESSAGESEPERATOR = ' ';
        public const int TOTALPLATEAUCOORDINATES = 2;
        public const int XCOORDINATEIDX = 0;
        public const int YCOORDINATEIDX = 1;
        public const int FACINGDIRECTIONIDX = 2;
    }

    public static class ErrorMessages
    {
        public const string ERR_INVLID_ARGUMENT = "Value does not fall within the expected range.";
        public const string ERR_COORDINATES_OUTOFRANGE = "Rover coordinates are out of range and does not fall within the plateau range.";
        public const string ERR_INVLID_DIRECTION = "Rover direction is not valid.";
        public const string ERR_INVALID_COMMAND = "Rover instructions are not valid.";
        public const string ERR_MISSING_DIRECTION = "Rover direction is not available.";
        public const string ERR_MISSING_COORDINATE = "Rover coordinates are not available";
        public const string ERR_MISSING_COMMAND = "Rover instructions are not available.";
        public const string ERR_MISSING_PLATEAU_COORDINATES = "Plateau coordinates are not available.";
        public const string ERR_MISSING_COORDINATE_DIRECTION = "Rover coordinates and its direction are not available.";
        public const string ERR_INVALID_PLATEAU_COORDINATES = "Plateau coordinates are not valid.";
    }
}
