using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Hangman.Services.Models.DTO;
using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using Hangman.Services.Utilities;

namespace Hangman.Services.Repositories.Implementations
{

    public class PlayerRepository : IPlayerRepository
    {

        public Dictionary<string, object> LogIn(string email, string password)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();

            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {
                        Table<Player> playerTable = dataSource.GetTable<Player>();

                        var player = from p in playerTable
                                     where p.Email == email && p.Password == password
                                     select new PlayerDTO
                                     {
                                         Name = p.Name,
                                         FirstLastName = p.FirstLastName,
                                         SecondLastName = p.SecondLastName,
                                         BirthDate = p.BirthDate,
                                         Email = p.Email,
                                     };

                        if (player.Any())
                        {
                            response.Add("Data", player);
                            response.Add("ResponseCode", 0);
                        }
                        else
                        {
                            response.Add("ResponseCode", 1);
                        }

                    }
                    catch (SqlException sqlEx)
                    {
                        Debug.WriteLine("Error: " + sqlEx.Message + ": \n" + sqlEx.StackTrace);
                        response.Add("ResponseCode", 2);
                    }

                }
                else
                {
                    response.Add("ResponseCode", 3);
                }
                return response;
            }

        }

        public Player SignUp(Player newPlayer)
        {
            
            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Player> playerTable = dataSource.GetTable<Player>();

                        var player = from p in playerTable
                                     where p.Email == newPlayer.Email
                                     select p;

                        if (!player.Any())
                        {
                            playerTable.InsertOnSubmit(newPlayer);
                            dataSource.SubmitChanges();
                            return newPlayer;
                        }
                        else
                        {
                            return null;
                        }

                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine("Error: " + ex.Message + ": \n" + ex.StackTrace);

                        return null;

                    }

                }
                else
                {
                    return null;
                
                }

            }

        }

        public Player UpdateProfile(Player updatedPlayer)
        {
            
            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Player> playerTable = dataSource.GetTable<Player>();

                        var player = from p in playerTable
                                     where p.PlayerId == updatedPlayer.PlayerId
                                     select p;

                        if (player.Any())
                        {

                            Player playerToUpdate = player.First();
                            playerToUpdate.Name = updatedPlayer.Name;
                            playerToUpdate.FirstLastName = updatedPlayer.FirstLastName;
                            playerToUpdate.SecondLastName = updatedPlayer.SecondLastName;
                            playerToUpdate.BirthDate = updatedPlayer.BirthDate;
                            playerToUpdate.Email = updatedPlayer.Email;

                            dataSource.SubmitChanges();

                            return playerToUpdate;

                        }
                        else
                        {
                            return null;
                        }

                    }
                    catch (Exception ex)
                    {

                        Console.Write("Error: " + ex.StackTrace);
                        return null;

                    }

                }
                else
                {
                    return null;
                }

            }

        }

        public Player GetPlayerById(int playerId)
        {
            
            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {

                        Table<Player> playerTable = dataSource.GetTable<Player>();

                        var player = from p in playerTable
                                     where p.PlayerId == playerId
                                     select p;

                        if (player.Any())
                        {
                            return player.First();
                        }
                        else
                        {
                            return null;
                        }

                    }
                    catch (Exception ex)
                    {

                        Console.Write("Error: " + ex.StackTrace);
                        return null;

                    }

                }
                else
                {
                    return null;
                }

            }

        }

    }

}