using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomben
{
            
    public class SvSInfo
    {
        public object error { get; set; }
        public Requestinfo requestInfo { get; set; }
        public string requestId { get; set; }
        public string sessionId { get; set; }
        public string deviceId { get; set; }
        public object session { get; set; }
        public object sessionUser { get; set; }
        public object clientInfo { get; set; }
        public Draw[] draws { get; set; }
    }

    public class Requestinfo
    {
        public string elapsedTime { get; set; }
        public int apiVersion { get; set; }
    }

    public class Draw
    {
        public int productId { get; set; }
        public int drawNumber { get; set; }
        public string description { get; set; }
        public bool enabled { get; set; }
        public string drawState { get; set; }
        public int drawStateId { get; set; }
        public int matchCount { get; set; }
        public int eventCount { get; set; }
        public DateTime regCloseTime { get; set; }
        public DateTime cancelCloseTime { get; set; }
        public string currentNetSales { get; set; }
        public Fund fund { get; set; }
        public Sport sport { get; set; }
        public Event[] events { get; set; }
    }

    public class Fund
    {
        public string rolloverIn { get; set; }
        public string extraMoney { get; set; }
    }

    public class Sport
    {
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public int numCountries { get; set; }
    }

    public class Event
    {
        public int eventNumber { get; set; }
        public string eventDescription { get; set; }
        public Match match { get; set; }
        public string comment { get; set; }
        public bool hasLiveEvent { get; set; }
        public Svenskafolket[] svenskaFolket { get; set; }
    }

    public class Match
    {
        public int matchId { get; set; }
        public DateTime matchStart { get; set; }
        public string status { get; set; }
        public int statusId { get; set; }
        public DateTime statusTime { get; set; }
        public int coverage { get; set; }
        public Participant[] participants { get; set; }
        public League league { get; set; }
        public object leagueTable { get; set; }
        public object[] result { get; set; }
        public Medium[] media { get; set; }
        public object mutuals { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public int uniqueLeagueId { get; set; }
        public string uniqueLeagueName { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public Country country { get; set; }
        public string code { get; set; }
        public string printAbbreviation { get; set; }
        public Season season { get; set; }
        public bool doShow { get; set; }
        public bool isHome { get; set; }
        public int legacyKey { get; set; }
        public int numTeams { get; set; }
        public bool popular { get; set; }
        public int rank { get; set; }
    }

    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public string isoCode { get; set; }
        public int population { get; set; }
    }

    public class Season
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int legacyKey { get; set; }
    }

    public class Participant
    {
        public string mediumName { get; set; }
        public string shortName { get; set; }
        public string code { get; set; }
        public int countryId { get; set; }
        public int managerId { get; set; }
        public int arenaId { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int trend { get; set; }
        public string goalAvg { get; set; }
    }

    public class Medium
    {
        public int channelId { get; set; }
        public string channelName { get; set; }
        public DateTime startTime { get; set; }
        public object endTime { get; set; }
        public int competitionId { get; set; }
    }

    public class Svenskafolket
    {
        public string score { get; set; }
        public string home { get; set; }
        public string away { get; set; }
    }

}
    
