using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CS_Player_Info_API.Models;
using CS_Player_Info_API.Dal;
using System.Data;

namespace CS_Player_Info_API.Repository
{
    public class PlayerInfoRepo
    {
        private PlayerInfoDal _dal;
        private DataTable _dt;

        public PlayerInfoRepo()
        {
            _dal = new PlayerInfoDal();
            this._dt = null;
        }

        public List<PlayerInfoModel> GetAllPlayers()
        {
            _dt = _dal.GetAllPlayers();
            List<PlayerInfoModel> players = new List<PlayerInfoModel>();
            return players = (from DataRow row in _dt.Rows
                              select new PlayerInfoModel
                              {
                                  Id = row.Field<int>("Id"),
                                  Name = row.Field<string>("Name"),
                                  Team = row.Field<string>("Team"),
                                  Country = row.Field<string>("Country"),
                                  Age = row.Field<int>("Age"),
                                  Role = row.Field<string>("Role"),
                                  Rating = row.Field<double?>("Rating"),
                                  PrimaryWeapon = row.Field<string>("PrimaryWeapon")

                              }).ToList();
        }

        public PlayerInfoModel GetPlayerById(int id)
        {
            _dt = _dal.GetPlayerById(id);
            PlayerInfoModel player = new PlayerInfoModel();
            return player = (from DataRow row in _dt.Rows
                             select new PlayerInfoModel
                             {
                                 Id = row.Field<int>("Id"),
                                 Name = row.Field<string>("Name"),
                                 Team = row.Field<string>("Team"),
                                 Country = row.Field<string>("Country"),
                                 Age = row.Field<int>("Age"),
                                 Role = row.Field<string>("Role"),
                                 Rating = row.Field<double?>("Rating"),
                                 PrimaryWeapon = row.Field<string>("PrimaryWeapon")
                             }).FirstOrDefault();
        }

        public bool InsertPlayer(PlayerInfoModel player)
        {
            return _dal.InsertPlayer(player);
        }
        public bool UpdatePlayer(PlayerInfoModel player)
        {
            return _dal.UpdatePlayer(player);
        }

        public bool DeletePlayer(int id)
        {
            return _dal.DeletePlayer(id);
        }



    }
}
