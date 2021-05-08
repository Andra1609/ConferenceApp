using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceWebApp.Interfaces
{
    interface IUpdateSponsor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public string Description { get; set; }
        public int ConferenceID { get; set; }

        // a company can sponsor only one conference
        //public virtual Conference Conference { get; set; }
    }
}
