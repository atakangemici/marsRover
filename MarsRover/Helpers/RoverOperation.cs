using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Common
{
    public class RoverOperation : IRoverOperation
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string MoveDirection { get; set; }

        //Verilen talimatlar doğrultusunda koordinat ve yön bilgilerinin setlenmesi.
        public void Calculate(int x, int y, string moveDirection)
        {
            CoordinateX = x;
            CoordinateY = y;
            MoveDirection = moveDirection;
        }

        //Bu method verilen talimatlar doğrultusunda rovers'ların koordinatlarını ve yönünü hesaplıyor.
        public async Task<string> DirectionMove(char[] directionMove)
        {
            if (directionMove.Length > 0)
            {
                foreach (var directionMoveItem in directionMove)
                {
                    if (directionMoveItem.ToString() == "R")
                        await TurnRight(MoveDirection);
                    else if (directionMoveItem.ToString() == "L")
                        await TurnLeft(MoveDirection);
                    else
                        await GoMove(CoordinateX, CoordinateY, MoveDirection);
                }
            }

            //Roverların sırasıyla koordinat ve yön bilgilerini ilgili yere iletiyor.
            var result = CoordinateX + " " + CoordinateY + " " + MoveDirection;

            return result;
        }

        //Pusula yönlerine uygun olarak talimatlar doğrultusunda sağa dönme işlemi için görevlendirilen method.
        public async Task TurnRight(string moveDirection)
        {
            switch (moveDirection)
            {
                case "N":
                    MoveDirection = "E";
                    break;
                case "S":
                    MoveDirection = "W";
                    break;
                case "W":
                    MoveDirection = "N";
                    break;
                case "E":
                    MoveDirection = "S";
                    break;
            }
        }

        //Pusula yönlerine uygun olarak Talimatlar doğrultusunda sola dönme işlemi için görevlendirilen method.
        public async Task TurnLeft(string moveDirection)
        {
            switch (moveDirection)
            {
                case "N":
                    MoveDirection = "W";
                    break;
                case "S":
                    MoveDirection = "E";
                    break;
                case "W":
                    MoveDirection = "S";
                    break;
                case "E":
                    MoveDirection = "N";
                    break;
            }
        }

        //Talimatlar doğrultusunda verilen koordinatlara göre hareket etmek üzere görevlendirilen method.
        public async Task GoMove(int coordinateX, int coordinateY, string moveDirection)
        {
            switch (moveDirection)
            {
                case "N":
                    CoordinateY += 1;
                    break;
                case "S":
                    CoordinateY -= 1;
                    break;
                case "W":
                    CoordinateX -= 1;
                    break;
                case "E":
                    CoordinateX += 1;
                    break;
            }
        }
    }
}
