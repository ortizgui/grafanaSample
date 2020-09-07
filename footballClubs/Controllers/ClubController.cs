using System;
using System.Collections.Generic;
using footballClubs.Models;
using Microsoft.AspNetCore.Mvc;

namespace footballClubs.Controllers
{
    [Route("/")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        /// <summary>
        /// GET The list of clubs.
        /// </summary>
        /// <returns>
        /// HTTP Status showing it was found or that there is an error. And the list of people records.
        /// </returns>
        /// <response code="200">Returns the list of Club records</response>
        [HttpGet]
        public ActionResult<IEnumerable<Club>> Get()
        {
            List<Club> clubList = new List<Club>();
            clubList.Add(new Club() {Name = "S.E. Palmeiras", Location = "São Paulo, Brazil", Founded=new DateTime(1914, 8, 26), FifaClubWorldCup=1});
            clubList.Add(new Club() {Name = "Real Madrid C.F.", Location = "Madrid, Spain", Founded=new DateTime(1902, 3, 6), FifaClubWorldCup=7});
            clubList.Add(new Club() {Name = "Liverpool F.C.", Location = "Liverpool, United Kingdom", Founded=new DateTime(1892, 6, 3), FifaClubWorldCup=1});
            return Ok(clubList);
        }
    }
}