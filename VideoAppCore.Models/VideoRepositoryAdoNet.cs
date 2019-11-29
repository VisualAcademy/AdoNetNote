// Install-Package System.Data.SqlClient
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

        public Video AddVideo(Video model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = 
                    "Insert Into Videos(Title, Url, Name, Company, CreatedBy) Values(@Title, @Url, @Name, @Company, @CreatedBy);";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Url", model.Url);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                con.Open();
                cmd.ExecuteNonQuery(); 
                con.Close();
            }

            return model; 
        }

        public async Task<Video> AddVideoAsync(Video model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query =
                    "Insert Into Videos(Title, Url, Name, Company, CreatedBy) Values(@Title, @Url, @Name, @Company, @CreatedBy);";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Url", model.Url);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
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
