using System.Collections.Generic;
using System;
using PortableSteam;
using PortableSteam.Fluent;
using PortableSteam.Infrastructure;
using PortableSteam.Interfaces;

namespace SSC
{
    class ListMaker
    {
        
        public  List<string> getFriends(long steamID)
        {
            SteamWebAPI.SetGlobalKey("2E063F9BD27D3C9AED847FAB0D876E01");
            var name = SteamIdentity.FromSteamID(steamID);
            var game = SteamWebAPI.General().ISteamUser().GetFriendList(name, RelationshipType.All).GetResponse();
            var friends = SteamWebAPI.General().ISteamUser().GetFriendList(name, RelationshipType.All).GetResponse();
           
            List<string> result = new List<String>();
            
            List<String> friendNames = new List<string>();
            foreach(var friend in friends.Data.Friends)
            {
                var level = SteamWebAPI.General().IPlayerService().GetSteamLevel(friend.Identity).GetResponse();
                result.Add(friend.Identity.SteamID + " is level: " + level.Data.PlayerLevel.ToString());
            }
            return result;
        }

    }


}
