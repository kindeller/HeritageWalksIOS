using System;
using SQLite;
namespace HeritageWalk
{
    [Table("stops")]
    public class stop
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public string photoName { get; set; }
        public string timeSpent { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string audioName { get; set; }
        public int trailId { get; set; }

        public stop()
        { 
        }
       
    }
}

