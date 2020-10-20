using ApiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ApiLibrary.Models
{


    public class Infractions
    {
        public string last_infraction_date { get; set; }
        public int afk { get; set; }
        public int leaver { get; set; }
        public int qm_not_checkedin { get; set; }
        public int qm_not_voted { get; set; }
    }

    public class Platforms
    {
        public string steam { get; set; }
    }

    public class EU
    {
        public string selected_ladder_id { get; set; }
    }

    public class Regions
    {
        public EU EU { get; set; }
    }

    public class Csco
    {
        public string game_profile_id { get; set; }
        public string region { get; set; }
        public Regions regions { get; set; }
        public string skill_level_label { get; set; }
        public string game_player_id { get; set; }
        public int skill_level { get; set; }
        public int faceit_elo { get; set; }
        public string game_player_name { get; set; }
    }

    public class RocketLeague
    {
        public string game_profile_id { get; set; }
        public string region { get; set; }
        public Regions regions { get; set; }
        public string skill_level_label { get; set; }
        public string game_player_id { get; set; }
        public int skill_level { get; set; }
        public int faceit_elo { get; set; }
        public string game_player_name { get; set; }
    }

    public class Valorant
    {
        public string game_profile_id { get; set; }
        public string region { get; set; }
        public Regions regions { get; set; }
        public string skill_level_label { get; set; }
        public string game_player_id { get; set; }
        public int skill_level { get; set; }
        public int faceit_elo { get; set; }
        public string game_player_name { get; set; }
    }

    public class Csgo
    {
        public string game_profile_id { get; set; }
        public string region { get; set; }
        public Regions regions { get; set; }
    public string skill_level_label { get; set; }
    public string game_player_id { get; set; }
    public int skill_level { get; set; }
    public int faceit_elo { get; set; }
    public string game_player_name { get; set; }
}

public class Dota2
{
    public string game_profile_id { get; set; }
    public string region { get; set; }
    public Regions regions { get; set; }
public string skill_level_label { get; set; }
public string game_player_id { get; set; }
public int skill_level { get; set; }
public int faceit_elo { get; set; }
public string game_player_name { get; set; }
    }

    public class Games
{
    public Csco csco { get; set; }
    public RocketLeague rocket_league { get; set; }
    public Valorant valorant { get; set; }
    public Csgo csgo { get; set; }
    public Dota2 dota2 { get; set; }
}

public class Settings
{
    public string language { get; set; }
}

public class Example
{
    public string player_id { get; set; }
    public string nickname { get; set; }
    public string avatar { get; set; }
    public string country { get; set; }
    public string cover_image { get; set; }
    public string cover_featured_image { get; set; }
    public Infractions infractions { get; set; }
    public Platforms platforms { get; set; }
    public Games games { get; set; }
    public Settings settings { get; set; }
    public IList<string> friends_ids { get; set; }
    public IList<object> bans { get; set; }
    public string new_steam_id { get; set; }
    public string steam_id_64 { get; set; }
    public string steam_nickname { get; set; }
    public string membership_type { get; set; }
    public IList<string> memberships { get; set; }
    public string faceit_url { get; set; }
}


}
