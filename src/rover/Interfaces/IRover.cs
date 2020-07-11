using System;
using System.Collections.Generic;
using System.Text;

namespace rover.Interfaces
{
    public interface IRover
    {
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        string Direction { get; set; }

        void ProcessingRoverPosition(string roverPosition);
        void ProcessingRoverCommands(string roverCommands);
        bool ValidateRoverPosition(ILandingSurface landingSurface);
    }
}
