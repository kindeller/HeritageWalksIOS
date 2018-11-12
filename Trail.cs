using System;
using SQLite;
namespace HeritageWalk
{
    [Table("trails")]
    public class Trail
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public string colourCode { get; set; }
        public string photoName { get; set; }
        public string distance { get; set; }
        public int totalTime { get; set; }


        public Trail()
        {
            
        }
    }
}
