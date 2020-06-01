using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheHat.Handlers;
using TheHat.Models;
using TheHat.Repositories.Interfaces;

namespace TheHat.Controllers
{
    [ExceptionFilter]
    public class HatController : Controller
    {
        private readonly IHatRepository _hatRepository;
        public HatController(IHatRepository hatRepository)
        {
            _hatRepository = hatRepository;
        }

        /// <summary>
        ///     Создание шляпы
        /// </summary>
        /// <param name="hatName">Название шляпы</param>
        /// <returns></returns>
        [HttpGet]
        [Route("CreateHat")]
        public IActionResult CreateHat(string hatName)
        {
            var createdHat = _hatRepository.CreateHat(hatName);
            return Ok(createdHat);
        }

        [HttpGet]
        [Route("GetHats")]
        public IActionResult GetHats()
        {
            var hats = _hatRepository.GetHats();
            return Ok(hats);
        }

        [HttpGet]
        [Route("AddUser")]
        public IActionResult AddUser(string hatName, string userName)
        {
            var user = _hatRepository.AddUser(hatName, userName);
            return Ok(user);
        }

        [HttpGet]
        [Route("GetHatUsers")]
        public IActionResult GetHatUsers(string hatName)
        {
            var users = _hatRepository.GetHatUsers(hatName);
            return Ok(users);
        }

        [HttpGet]
        [Route("AddWords")]
        public IActionResult AddWords(string hatName, string words)
        {
            if (string.IsNullOrWhiteSpace(words))
                return BadRequest();

            _hatRepository.AddWords(hatName, words);

            return Ok("Слова успешно добавлены");
        }

        [HttpGet]
        [Route("GetHatWords")]
        public IActionResult GetHatWords(string hatName)
        {
            var words = _hatRepository.GetHatWords(hatName);
            return Ok(words);
        }

        [HttpGet]
        [Route("GetRandomWord")]
        public IActionResult GetRandomWord(string userName, string hatName)
        {
            var word = _hatRepository.GetRandomWord(userName, hatName);
            return Ok(word);
        }

        [HttpGet]
        [Route("Guessed")]
        public IActionResult Guessed(string hatName)
        {
            var word = _hatRepository.GuessedWord(hatName);
            return Ok(word);
        }

        [HttpGet]
        [Route("SkipWord")]
        public IActionResult SkipWord(string hatName)
        {
            _hatRepository.ResetHatWords(hatName);
            return Ok();
        }

        [HttpGet]
        [Route("ResetHatWords")]
        public IActionResult ResetHatWords(string hatName)
        {
            _hatRepository.ResetHatWords(hatName);
            return Ok();
        }
    }
}