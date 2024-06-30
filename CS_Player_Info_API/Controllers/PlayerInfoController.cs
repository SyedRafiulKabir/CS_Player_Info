using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
//using System.Web.Http.Cors;
using CS_Player_Info_API.Models;
using CS_Player_Info_API.Repository;

namespace CS_Player_Info_API.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlayerInfoController : ApiController
    {
        PlayerInfoRepo playerInfoRepo = new PlayerInfoRepo();
        public PlayerInfoController()
        {
            this.playerInfoRepo = new PlayerInfoRepo();
        }

        [HttpGet]
        [Route("api/PlayerInfo/Get")]
        public IEnumerable<PlayerInfoModel> Get()
        {
            List<PlayerInfoModel> players = new List<PlayerInfoModel>();
            players = playerInfoRepo.GetAllPlayers();
            return players;
        }

        [HttpGet]
        [Route("api/PlayerInfo/Get/{id}")]
        public PlayerInfoModel Get(int id)
        {
            PlayerInfoModel player = new PlayerInfoModel();
            player = playerInfoRepo.GetPlayerById(id);
            return player;
        }

        [HttpPost]
        [Route("api/PlayerInfo/Insert")]
        public IHttpActionResult Insert(PlayerInfoModel player)
        {
            if (playerInfoRepo.InsertPlayer(player))
            {
                return Ok("Player inserted successfully.");
            }
            else
            {
                return BadRequest("Failed to insert player.");
            }
        }

        [HttpPut]
        [Route("api/PlayerInfo/Update")]
        public IHttpActionResult Update(PlayerInfoModel player)
        {
            if (playerInfoRepo.UpdatePlayer(player))
            {
                return Ok("Player updated successfully.");
            }
            else
            {
                return BadRequest("Failed to update player.");
            }
        }

        [HttpDelete]
        [Route("api/PlayerInfo/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (playerInfoRepo.DeletePlayer(id))
            {
                return Ok("Player deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete player.");
            }
        }

    }

}
