using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirtelSales.Models
{
    public class Profile
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public int ZoneId { get; set; }
        public int AreaId { get; set; }
        public int MarketId { get; set; }
        public int RegionalManagerId { get; set; }
        public int ZonalManagerId { get; set; }
        public int AreaManagerId { get; set; }
        public int MarketDeveloperId { get; set; }
        public int DealerId { get; set; }
        public int SubDealerId { get; set; }

        public string DealerCode { get; set; }
        public string SubDealerCode { get; set; }
        public string ResellerCode { get; set; }
        //public int AreaManagerId { get; set; }

    }

    public class RegionalManagerModel
    { 
        public string UserId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class ZonalManagerModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegionalManagerId { get; set; }

    }

    public class AreaManagerModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegionalManagerId { get; set; }
        public int ZonalManagerId { get; set; }

    }

    public class DealerModel
    {
        public string UserId { get; set; }
        public int RegionalManagerId { get; set; }
        public int ZonalManagerId { get; set; }
        public int AreaManagerId { get; set; }
        public int MarketDeveloperId { get; set; }
        public int DealerId { get; set; }
        public int SubDealerId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DealerCode { get; set; }
        public string SubDealerCode { get; set; }
        public string ResellerCode { get; set; }

    }

    public class SubDealerModel
    {
        public string UserId { get; set; }
        public int RegionalManagerId { get; set; }
        public int ZonalManagerId { get; set; }
        public int AreaManagerId { get; set; }
        public int MarketDeveloperId { get; set; }
        public int DealerId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SubDealerCode { get; set; }

    }

    public class ResellerModel
    {
        public string UserId { get; set; }
        public int RegionalManagerId { get; set; }
        public int ZonalManagerId { get; set; }
        public int AreaManagerId { get; set; }
        public int MarketDeveloperId { get; set; }
        public int DealerId { get; set; }
        public int SubDealerId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResellerCode { get; set; }

    }


}