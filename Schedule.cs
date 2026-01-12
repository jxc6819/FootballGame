//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Conference 
{
    public string name;
    public List<Division> divisions;

    public Conference(string name, List<Division> divisions)
    {
        this.name = name;
        this.divisions = divisions;
    }

    public void Sort()
    {
        for (int i = 0; i < this.divisions.Count; i++)
        {
            this.divisions[i].Sort();
        }
    }
}


public class Division : IComparable
{
    public Division division;
    public string name;
    public List<Team> teams;
    public int[] order = {0, 1, 2, 3};
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;
        Division other = (Division)obj;
        return String.Compare(this.name, other.name);
    }

public Division(string name, List<Team> teams)
    {
        this.name = name;
        this.teams = teams;
    }

    public void Sort()
    {
        this.teams.Sort();
        int first = -1;
        int second = -1;
        int third = -1;

        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < this.teams.Count; i++)
            {
                if (j == 0)
                {
                    if (first == -1)
                    {
                        first = i;
                    }
                    else if (this.teams[first].Record < this.teams[i].Record)
                    {
                        first = i;
                    }

                }
                else if (j == 1)
                {

                    if (second == -1 && i != first)
                    {
                        second = i;
                    }
                    else if (i != first && this.teams[second].Record < this.teams[i].Record)
                    {
                        second = i;
                    }

                }
                else if (j == 2)
                {

                    if (third == -1 && i != first && i != second)
                    {
                        third = i;
                    }
                    else if (i != first && i != second && third != -1 && this.teams[third].Record < this.teams[i].Record)
                    {
                        third = i;
                    }
                }

            }
        }
       
        int fourth = 6 - (first + second + third);
        this.order[0] = first;
        this.order[1] = second;
        this.order[2] = third;
        this.order[3] = fourth;

    }
}



public class Player
{
    
    public string name;
    public int jerseyNumber;
    public float runningSpeed;
    public Player(string name, int jersey, float runningSpeed = 1.0f)
    {
        this.name = name;
    }
}

public class Team : IComparable
{
    public string name;
    public List<Player> players;
    public int Record;

    public Team(string name, int record)
    {
        this.Record = record;
        this.name = name;
        this.players = new List<Player>();
    }
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;
        Team other = (Team)obj;
        return String.Compare(this.name, other.name);
    }

    public static implicit operator int(Team v)
    {
        throw new NotImplementedException();
    }
}
public class Schedule : MonoBehaviour
{
    void Sort()
    {
        Console.WriteLine("Successful");
        for (int i = 0; i < AGC.divisions.Count; i++)
        {
            AGC.divisions[i].Sort();
        }
        //foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(AGC.divisions[0].order))
        //{
        //    string name = descriptor.Name;
        //    object value = descriptor.GetValue(AGC.divisions[0].order);
    }
        void Start()
    {
        Debug.Log("Start");
        this.aNorth();
        Debug.Log(agcNorth.order[0]);
        Debug.Log(agcNorth.order[1]);
        Debug.Log(agcNorth.order[2]);
        Debug.Log(agcNorth.order[3]);
      
        
      
    }
    void aNorth()
    {
        Debug.Log("Successful");
        AGC.divisions.Sort();
    }
    void aSouth()
    {
        AGC.divisions.Sort();
    }
    void aEast()
    {
        AGC.divisions.Sort();
    }
    void aWest()
    {
        AGC.divisions.Sort();
    }

    void nNorth()
    {
        NGC.divisions.Sort();
    }
    void nSouth()
    {
        NGC.divisions.Sort();
    }
    void nEast()
    {
        NGC.divisions.Sort();
    }
    void nWest()
    {
        NGC.divisions.Sort();
    }



    //INTS:
    Conference AGC = new Conference("AGC", _AGC);
    Conference NGC = new Conference("NGC", _NGC);

    //AGC North
   public static Division agcNorth = new Division("agcNorth", _AGCNorth);
    public static int _Baltimore = 11;
    public static int _Cincinnati = 4;
    public static int _Cleveland = 11;
    public static int _Pittsburgh = 12;
   public static List<string> BaltimoreSchedule = new List<string>();
   public static List<string> CincinnatiSchedule = new List<string>();
   public static List<string> ClevelandSchedule = new List<string>();
   public static List<string> PittsburghSchedule = new List<string>();
    static Team Baltimore = new Team("Baltimore", _Baltimore);
    static Team Cincinnati = new Team("Cincinnati", _Cincinnati);
    static Team Cleveland = new Team("Cleveland", _Cleveland);
    static Team Pittsburgh = new Team("Pittsburgh", _Pittsburgh);
    //AGC South
   public static Division agcSouth = new Division("agcSouth", _AGCSouth);
    public static int _Houston = 4;
    public static int _Indianapolis = 11;
    public static int _Jacksonville = 1;
    public static int _Tennessee = 11;
    static List<string> HoustonSchedule = new List<string>();
    static List<string> IndianapolisSchedule = new List<string>();
    static List<string> JacksonvilleSchedule = new List<string>();
    static List<string> TennesseeSchedule = new List<string>();
    static Team Houston = new Team("Houston", _Houston);
    static Team Indianapolis = new Team("Indianapolis", _Indianapolis);
    static Team Jacksonville = new Team("Jacksonville", _Jacksonville);
    static Team Tennessee = new Team("Tennessee", _Tennessee);
    //AGC East
   public static Division agcEast = new Division("agcEast", _AGCEast);
    public static int _Buffalo = 13;
    public static int _Miami = 10;
    public static int _NewEngland = 7;
    public static int _NewYorkJ = 2;
    static List<string> BuffaloSchedule = new List<string>();
    static List<string> MiamiSchedule = new List<string>();
    static List<string> NewEnglandSchedule = new List<string>();
    static List<string> NewYorkJSchedule = new List<string>();
    static Team Buffalo = new Team("Buffalo", _Buffalo);
    static Team Miami = new Team("Miami", _Miami);
    static Team NewEngland = new Team("New England", _NewEngland);
    static Team NewYorkJ = new Team("New York J", _NewYorkJ);
    //AGC West
    static Division agcWest = new Division("agcWest", _AGCEast);
    public static int _Denver = 5;
    public static int _KansasCity = 14;
    public static int _LasVegas = 8;
    public static int _LAC = 7;
    static List<string> DenverSchedule = new List<string>();
    static List<string> KansasCitySchedule = new List<string>();
    static List<string> LasVegasSchedule = new List<string>();
    static List<string> LACSchedule = new List<string>();
    static Team Denver = new Team("Denver", _Denver);
    static Team KansasCity = new Team("Kansas City", _KansasCity);
    static Team LasVegas = new Team("Las Vegas", _LasVegas);
    static Team LAC = new Team("Los Angeles C", _LAC);


    //NGC North
   public static Division ngcNorth = new Division("ngcNorth", _NGCNorth);
    public static int _Chicago;
    public static int _Detroit;
    public static int _GreenBay;
    public static int _Minnesota;
    static List<string> ChicagoSchedule = new List<string>();
    static List<string> DetroitSchedule = new List<string>();
    static List<string> GreenBaySchedule = new List<string>();
    static List<string> MinnesotaSchedule = new List<string>();

    static Team Chicago = new Team("Chicago", _Chicago);
    static Team Detroit = new Team("Detroit", _Detroit);
    static Team GreenBay = new Team("Green Bay", _GreenBay);
    static Team Minnesota = new Team("Minnesota", _Minnesota);

    //NGC South
    static Division ngcSouth = new Division("ngcSouth", _NGCSouth);
    public static int _Atlanta;
    public static int _Carolina;
    public static int _NewOrleans;
    public static int _TampaBay;
    static List<string> AtlantaSchedule = new List<string>();
    static List<string> CarolinaSchedule = new List<string>();
    static List<string> NewOrleansSchedule = new List<string>();
    static List<string> TampaBaySchedule = new List<string>();
    static Team Atlanta = new Team("Atlanta", _Atlanta);
    static Team Carolina = new Team("Carolina", _Carolina);
    static Team NewOrleans = new Team("New Orleans", _NewOrleans);
    static Team TampaBay = new Team("Tampa Bay", _TampaBay);
    //NGC East
    static Division ngcEast = new Division("ngcEast", _NGCEast);
    public static int _Dallas;
    public static int _NewYorkG;
    public static int _Philadelphia;
    public static int _Washington;
    static List<string> DallasSchedule = new List<string>();
    static List<string> NewYorkGSchedule = new List<string>();
    static List<string> PhiladelphiaSchedule = new List<string>();
    static List<string> WashingtonSchedule = new List<string>();
    static Team Dallas = new Team("Dallas", _Dallas);
    static Team NewYorkG = new Team("New York G", _NewYorkG);
    static Team Philadelphia = new Team("Philadelphia", _Philadelphia);
    static Team Washington = new Team("Washington", _Washington);
    //NGC West
    static Division ngcWest = new Division("ngcWest", _NGCWest);
    public static int _Arizona;
    public static int _LAR;
    public static int _SanFrancisco;
    public static int _Seattle;
    static List<string> ArizonaSchedule = new List<string>();
    static List<string> LARSchedule = new List<string>();
    static List<string> SanFranciscoSchedule = new List<string>();
    static List<string> SeattleSchedule = new List<string>();
    static Team Arizona = new Team("Arizona", _Arizona);
    static Team LAR = new Team("Los Angeles R", _LAR);
    static Team SanFrancisco = new Team("San Francisco", _SanFrancisco);
    static Team Seattle = new Team("Seattle", _Seattle);

    //Division Lists
    static List<Team> _AGCNorth = new List<Team> { Baltimore, Cincinnati, Cleveland, Pittsburgh };
    static List<Team> _AGCSouth = new List<Team> { Houston, Indianapolis, Jacksonville, Tennessee };
    static List<Team> _AGCEast = new List<Team> { Buffalo, Miami, NewEngland, NewYorkJ };
    static List<Team> _AGCWest = new List<Team> { Denver, KansasCity, LasVegas, LAC };
    static List<Division> _AGC = new List<Division> { agcNorth, agcSouth, agcEast, agcWest };

    static List<Team> _NGCNorth = new List<Team> { Chicago, Detroit, GreenBay, Minnesota };
    static List<Team> _NGCSouth = new List<Team> { Atlanta, Carolina, NewOrleans, TampaBay };
    static List<Team> _NGCEast = new List<Team> { Dallas, NewYorkG, Philadelphia, Washington };
    static List<Team> _NGCWest = new List<Team> { Arizona, LAR, SanFrancisco, Seattle };
    static List<Division> _NGC = new List<Division> { ngcNorth, ngcSouth, ngcEast, ngcWest };

}
