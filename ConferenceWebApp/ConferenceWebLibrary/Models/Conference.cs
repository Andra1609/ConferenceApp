using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebLibrary.Models
{
    public class Conference
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public string PictureURL { get; set; }
        public string Place { get; set; }
        public DateTime ConferenceTime { get; set; }
        public string Free { get; set; }
        public float Price { get; set; }

        // link conference to sponsor
        public virtual List<Sponsor> Sponsors { get; set; }
    }
}
