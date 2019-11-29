// Install-Package System.Data.SqlClient
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace VideoAppCore.Models
{
    public class VideoRepositoryAdoNet
    {
        private readonly string _connectionString;

        public VideoRepositoryAdoNet(string connectionString)
        {
            this._connectionString = connectionString;
        }

        // 동기 방식
        public Video AddVideo(Video model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = 
                    "Insert Into Videos(Title, Url, Name, Company, CreatedBy) Values(@Title, @Url, @Name, @Company, @CreatedBy);" +
                    "Select Cast(SCOPE_IDENTITY() As Int);";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Url", model.Url);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                con.Open();
                model.Id = Convert.ToInt32(cmd.ExecuteScalar()); 
                con.Close();
            }

            return model; 
        }

        // 비동기 방식
        public async Task<Video> AddVideoAsync(Video model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query =
                    "Insert Into Videos(Title, Url, Name, Company, CreatedBy) Values(@Title, @Url, @Name, @Company, @CreatedBy);" +
                    "Select Cast(SCOPE_IDENTITY() As Int);";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Url", model.Url);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                con.Open();
                object result = await cmd.ExecuteScalarAsync();
                if (int.TryParse(result.ToString(), out int id))
                {
                    model.Id = id; 
                }
                con.Close();
            }

            return model;
        }

        public Video GetVideoById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Video> GetVideos()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveVideo(int id)
        {
            throw new System.NotImplementedException();
        }

        public Video UpdateVideo(Video model)
        {
            throw new System.NotImplementedException();
        }
    }
}
