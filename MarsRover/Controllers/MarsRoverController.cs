using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MarsRover.Controllers
{
    [Route("api/get")]
    [ApiController]
    public class MarsRoverController : ControllerBase
    {
        private IRoverOperation _roverRepository;

        public MarsRoverController(IRoverOperation roverRepository)
        {
            _roverRepository = roverRepository;
        }

        [Route("mars_rover"), HttpGet]
        public async Task<string> MarsRover()
        {
            //Verilen bilgiler doğrultusunda iniş yapılan alanın ölçüleri setlendi.
            var areaSize = "5,5";

            //Hesaplama methodu ile verilen koordinatlar ve yön bilgisi setleniyor.
            _roverRepository.Calculate(1, 2, "N");

            //Rover 1 için gerekli talimatlar verilerek rehberlik ediliyor.Rover 1 işlemlerini bitirene kadar Rover 2 bekliyor.
            string directionMoveInfoFirst = "LMLMLMLMM";
            char[] directionMoveArrayFirst = directionMoveInfoFirst.ToCharArray();

            //DirectionMove methodu ile girilen bilgiler doğrultusunda alan üzerinde hangi yönde ilermesi gerektiği gibi bilgiler işleniyor.
            var directionMoveFirst = await _roverRepository.DirectionMove(directionMoveArrayFirst);
            var firstRover = directionMoveFirst;

            //Hesaplama methodu ile verilen koordinatlar ve yön bilgisi setleniyor.
            _roverRepository.Calculate(3, 3, "E");

            //Rover 2 için gerekli talimatlar verilerek rehberlik ediliyor.Rover 1 işlemini bitirdikten sonra Rover 2 işlemlerine başlıyor.
            string directionMoveInfoSecond = "MMRMMRMRRM";
            char[] directionMoveArraySecond = directionMoveInfoSecond.ToCharArray();

            var directionMoveSecond = await _roverRepository.DirectionMove(directionMoveArraySecond);
            var secondRover = directionMoveSecond;

            //Rover 1 ve Rover 2 nin plato keşif işlemleri bitiyor ve gerekli bilgiler sonuç olarak gösteriliyor.
            var result = "First Rover : " + " " + firstRover + " | " + "Second Rover : " + " " + secondRover;

            return result;
        }
    }
}