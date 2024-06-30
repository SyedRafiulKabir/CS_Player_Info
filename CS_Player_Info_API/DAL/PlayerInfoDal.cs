using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CS_Player_Info_API.DAL;
using CS_Player_Info_API.Models;

namespace CS_Player_Info_API.Dal
{
    public class PlayerInfoDal
    {
        private DataTable _dt;
        private string _connectionString;
        private string _spName;
        private SqlParameter[] _spParameters;

        public PlayerInfoDal()
        {
            this._dt = null;
            this._connectionString = null;
            this._spName = null;
            this._spParameters = null;
        }

        public DataTable GetAllPlayers()
        {
            _dt = new DataTable();
            _connectionString = WebConfigDataProvider.GetConnString();
            _spName = "_spGetPlayerInfo";
            _spParameters = new SqlParameter[]
            {
                new SqlParameter("@QryOption",1),
            };

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = _spName;
                    cmd.Parameters.AddRange(_spParameters);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(_dt);
                        conn.Close();
                        da.Dispose();
                    }
                }
            }

            return _dt;
        }

        public DataTable GetPlayerById(int id)
        {
            _dt = new DataTable();
            _connectionString = WebConfigDataProvider.GetConnString();
            _spName = "_spGetPlayerInfo";
            _spParameters = new SqlParameter[]
            {
                 new SqlParameter("@QryOption",2),
                 new SqlParameter(@"id",id)
            };

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = _spName;
                    cmd.Parameters.AddRange(_spParameters);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(_dt);
                        conn.Close();
                        da.Dispose();
                    }
                }
            }

            return _dt;
        }
        public bool InsertPlayer(PlayerInfoModel player)
        {
            _connectionString = WebConfigDataProvider.GetConnString();
            _spName = "_spInsertPlayer";
            _spParameters = new SqlParameter[]
            {
                new SqlParameter("@Name", player.Name),
                new SqlParameter("@Team", player.Team),
                new SqlParameter("@Country", player.Country),
                new SqlParameter("@Age", player.Age),
                new SqlParameter("@Role", player.Role),
                new SqlParameter("@Rating", player.Rating),
                new SqlParameter("@PrimaryWeapon", player.PrimaryWeapon)
            };

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = _spName;
                    cmd.Parameters.AddRange(_spParameters);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected > 0;
                }
            }
        }
        public bool UpdatePlayer(PlayerInfoModel player)
        {
            _connectionString = WebConfigDataProvider.GetConnString();
            _spName = "_spUpdatePlayer";
            _spParameters = new SqlParameter[]
            {
        new SqlParameter("@Id", player.Id),
        new SqlParameter("@Name", player.Name),
        new SqlParameter("@Team", player.Team),
        new SqlParameter("@Country", player.Country),
        new SqlParameter("@Age", player.Age),
        new SqlParameter("@Role", player.Role),
        new SqlParameter("@Rating", player.Rating),
        new SqlParameter("@PrimaryWeapon", player.PrimaryWeapon)
            };

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = _spName;
                    cmd.Parameters.AddRange(_spParameters);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected != 0;
                }
            }
        }

        public bool DeletePlayer(int id)
        {
            _connectionString = WebConfigDataProvider.GetConnString();
            _spName = "_spDeletePlayer";
            _spParameters = new SqlParameter[]
            {
        new SqlParameter("@Id", id)
            };

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = _spName;
                    cmd.Parameters.AddRange(_spParameters);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected != 0;
                }
            }
        }

    }
}
