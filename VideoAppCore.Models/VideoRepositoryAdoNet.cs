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

        // 출력
        public List<Video> GetVideos()
        {
            List<Video> videos = new List<Video>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "Select * From Videos;";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Video video = new Video
                    {
                        Id = dr.GetInt32(0),
                        Title = dr["Title"].ToString(),
                        Url = dr["Url"].ToString(),
                        Name = dr["Name"].ToString(),
                        Company = dr["Company"].ToString(),
                        CreatedBy = dr["CreatedBy"].ToString(),
                        Created = Convert.ToDateTime(dr["Created"])
                    };
                    videos.Add(video);
                }
                con.Close();
            }

            return videos;
        }

        // 출력
        public async Task<List<Video>> GetVideosAsync()
        {
            List<Video> videos = new List<Video>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "Select * From Videos;";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    Video video = new Video
                    {
                        Id = dr.GetInt32(0),
                        Title = dr["Title"].ToString(),
                        Url = dr["Url"].ToString(),
                        Name = dr["Name"].ToString(),
                        Company = dr["Company"].ToString(),
                        CreatedBy = dr["CreatedBy"].ToString(),
                        Created = Convert.ToDateTime(dr["Created"])
                    };
                    videos.Add(video);
                }
                con.Close();
            }

            return videos;
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
