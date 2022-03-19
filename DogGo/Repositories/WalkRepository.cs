using DogGo.Models;
using Microsoft.Data.SqlClient;

namespace DogGo.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly IConfiguration _config;

        public WalkRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Walks> GetAllWalks()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT *
                        FROM Walks
                    ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walks> walks = new List<Walks>();

                    while (reader.Read())
                    {
                        Walks walk = new Walks
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                        };

                        walks.Add(walk);
                    }

                    reader.Close();

                    return walks;
                }
            }
        }

        public List<Walks> GetWalksByWalkerId(int walkerId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Walk.Id,
                               Walk.[Date],
                               Walk.Duration,
                               Own.[Name],
                               Walk.DogId,
                               Walk.WalkerId
                        FROM Walks Walk
                        LEFT JOIN Dog Dog ON Dog.Id = Walk.DogId
                        LEFT JOIN [Owner] Own ON Dog.OwnerId = Own.Id
                        WHERE WalkerId = @walkerId;
                    ";

                    cmd.Parameters.AddWithValue("@walkerId", walkerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walks> walks = new List<Walks>();

                    while (reader.Read())
                    {
                        Walks walk = new Walks()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId"))
                        };

                        walks.Add(walk);
                    }

                    reader.Close();

                    return walks;
                }
            }
        }
    }
}
