using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ValidadorCartao.Repositorio;

namespace ValidadorCartao.Controllers
{
    [Route("api/validator")]
    public class ValidatorController : Controller
    {
        Validator validator = new Validator();
        
        [HttpGet("{card}")]
        public string Get(string card)
        {
            var obj = validator.ValidateCard(card);

            var response = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            return response;

        }
    }
}