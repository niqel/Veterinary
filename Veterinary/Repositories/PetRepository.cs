using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Veterinary.Models;

namespace Veterinary.Repositories
{
    public class PetRepository : BaseRepository, IPetRepository
    {
        public PetRepository(string connectionString)
        {
            base.connectionString = connectionString;
        }

        public void Add(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(PetModel petModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetModel> GetAll()
        {
            var petList = new List<PetModel>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (var command = new SqlCommand())
            {
                sqlConnection.Open();
                command.Connection = sqlConnection;
                command.CommandText = "Select * from Pet order by petId desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.Name = (string)reader[1];
                        petModel.Type = (string)reader[2];
                        petModel.Colour = (string)reader[3];
                        petList.Add(petModel);
                    }
                }
                sqlConnection.Close();
            }
            return petList;
        }

        public IEnumerable<PetModel> GetByValue(string value)
        {
            var petList = new List<PetModel>();

            int petId = int.TryParse(value, out _)? Convert.ToInt32(value) : 0;
            string petName = value;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (var command = new SqlCommand())
            {
                sqlConnection.Open();
                command.Connection = sqlConnection;
                command.CommandText = "Select * from Pet " +
                                      "where petId = @id or name like @name+'%' " +
                                      "order by petId desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = petId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = petName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Id = (int)reader[0];
                        petModel.Name = (string)reader[1];
                        petModel.Type = (string)reader[2];
                        petModel.Colour = (string)reader[3];
                        petList.Add(petModel);
                    }
                }
                sqlConnection.Close();
            }
            return petList;
        }
    }
}
