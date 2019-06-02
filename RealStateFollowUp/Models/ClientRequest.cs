using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models
{
    public class ClientRequest
    {
        public int ID { get; set; }
        public int ClientID { get; set; }

        [ForeignKey("ClientID")]
        public Client Client { get; set; }
        [Display(Name = "שם הבקשה")]
        public String Name { get; set; }
        [Display(Name="תאריך יצירה")]
        public DateTime CreateDate { get; set; }
        [Display(Name="סטטוס")]
        public int StatusID { get; set; }

        [ForeignKey("StatusID")]
        public ClientRequestStatus ClientRequestStatus { get; set; }

        [Display(Name="שכונה")]
        public int NeighborhoodID { get; set; }

        [ForeignKey("NeighborhoodID")]
        public Neighborhood Neighborhood { get; set; }
        [Display(Name="גבול צפוני")]
        public String NorthLimit { get; set; }
        [Display(Name="גבול מערבי")]
        public String EastLimit { get; set; }
        [Display(Name = "גבול דרומי")]
        public String SouthLimit { get; set; }
        [Display(Name = "גבול מזרחי")]
        public String WestLimit { get; set; }
        [Display(Name = "סוג נכס")]
        public int? PropertyTypeID { get; set; }

        [ForeignKey("PropertyTypeID")]
        public PropertyType PropertyType { get; set; }

        [Display(Name = "חדש")]
        public bool IsNewProperty { get; set; }
        [Display(Name = "יד שנייה")]
        public bool IsUsedProperty { get; set; }
        [Display(Name = "גיל הנכס")]
        public int? AgeOfProperty { get; set; }
        [Display(Name = "חדרים")]
        public decimal? NumberOfRooms { get; set; }
        [Display(Name = "שטח")]
        public String Area { get; set; }
        [Display(Name = "קומה")]
        public String Floor { get; set; }
        [Display(Name = "מעלית")]
        public bool HaveElevator { get; set; }
        [Display(Name = "חניות")]
        public int? NumberOfParkings { get; set; }
        [Display(Name = "מחסן")]
        public bool HaveStoreRoom { get; set; }
        [Display(Name = "מרתף")]
        public bool HaveBasement { get; set; }
        [Display(Name = "חזיתי")]
        public bool IsFront { get; set; }
        [Display(Name = "עורפי")]
        public bool IsRear { get; set; }
        [Display(Name = "כיוונים")]
        public int? MainDirectionID { get; set; }

        [ForeignKey("MainDirectionID")]
        public MainDirection MainDirection { get; set; }
        [Display(Name = "גינה")]
        public bool HaveGarden { get; set; }
        [Display(Name = "מרפסת")]
        public bool HaveBalcony { get; set; }
        [Display(Name = "ח.טלויזיה")]
        public bool HaveTVRoom { get; set; }
        [Display(Name = "ח.עבודה")]
        public bool HaveWorkingRoom { get; set; }
        [Display(Name = "ח.הורים")]
        public int? MasterBedroomID { get; set; }

        [ForeignKey("MasterBedroomID")]
        public MasterBedroom MasterBedroom { get; set; }
        [Display(Name = "מקלחות")]
        public int? NumberOfBathrooms { get; set; }
        [Display(Name = "שירותים")]
        public int? NumberOfToilets { get; set; }
        [Display(Name = "חודש מועדף לכניסה")]
        public int? PreferredEntryMonth { get; set; }
        [Display(Name = "שנה מועדפת לכניסה")]
        public int? PreferredEntryYear { get; set; }
    }
}
