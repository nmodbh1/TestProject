using rover.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace rovertest.TestData
{

    /// <summary>
    /// Mars Rover - This class is used to specify test data for the postive test cases. 
    /// </summary>
    public class MarsRoverTestDataPass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "1 2 N", "LMLMLMLMM", "1 3 N" };
            yield return new object[] { "3 3 E", "MMRMMRMRRM", "5 1 E" };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    // Mars Rover - This class is used to specify test data for the negative test cases.
    public class MarsRoverTestDataFail : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "1 2 N", "", ErrorMessages.ERR_MISSING_COMMAND };
            yield return new object[] { "1 2 N", "ABCD", ErrorMessages.ERR_INVALID_COMMAND };
            yield return new object[] { "1 2", "LMLMLMLMM", ErrorMessages.ERR_MISSING_DIRECTION };
            yield return new object[] { "1 2 G", "LMLMLMLMM", ErrorMessages.ERR_INVLID_DIRECTION };
            yield return new object[] { "", "LMLMLMLMM", ErrorMessages.ERR_MISSING_COORDINATE_DIRECTION };
            yield return new object[] { "1", "LMLMLMLMM", ErrorMessages.ERR_MISSING_COORDINATE };
            yield return new object[] { "6 7 N", "LMLMLMLMM", ErrorMessages.ERR_COORDINATES_OUTOFRANGE };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    /// <summary>
    /// Plateau - This class is used to specify test data for the negative test cases.
    /// </summary>
    public class PlateauTestDataFail : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "", ErrorMessages.ERR_MISSING_PLATEAU_COORDINATES };
            yield return new object[] { "ABCD", ErrorMessages.ERR_INVALID_PLATEAU_COORDINATES };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
