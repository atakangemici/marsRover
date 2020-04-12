using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Common
{
    public interface IRoverOperation
    {
        void Calculate(int x, int y, string moveDirection);
        Task<string> DirectionMove(char[] directionMove);
        Task TurnRight(string moveDirection);
        Task TurnLeft(string moveDirection);
        Task GoMove(int coordinateX, int coordinateY, string moveDirection);
    }
}
