using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Hangman.Services.Models.POCO;
using Hangman.Services.Repositories.Interfaces;
using Hangman.Services.Utilities;

namespace Hangman.Services.Repositories.Implementations
{

    public class PlayerRepository : IPlayerRepository
    {

        public Player LogIn(string email, string password)
        {
            
            using(DataContext dataSource = DBConnection.GetConnection())
            {

                if (dataSource != null)
                {

                    try
                    {
                        Table<Player> playerTable = dataSource.GetTable<Player>();

                        var player = from p in playerTable
                                     where p.Email == email && p.Password == password
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