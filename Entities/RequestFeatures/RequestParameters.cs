using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 10;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 5;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }

        public string OrderBy { get; set; }
    }

    public class PaintigsParameters : RequestParameters 
    {
        public PaintigsParameters()
        {
            OrderBy = "name";
        }

        public string Category { get; set; } 

        public string SearchTerm { get; set; }
    }
    public class ArtistsParameters : RequestParameters 
    {
        public ArtistsParameters()
        {
            OrderBy = "name";
        }
        public string SearchTerm { get; set; }
    }
    public class ExhibitionsParameters : RequestParameters 
    {
        public ExhibitionsParameters()
        {
            OrderBy = "name";
        }
        public string SearchTerm { get; set; }
    }
    public class ToursParameters : RequestParameters 
    {
        public ToursParameters()
        {
            OrderBy = "places";
        }
        public uint MinPlaces { get; set; }
        public uint MaxPlaces { get; set; } = 25;
        public bool ValidPlacesRange => MaxPlaces > MinPlaces;

        public string SearchTerm { get; set; }
    }

    public class MuseumParameters : RequestParameters 
    {
        public MuseumParameters()
        {
            OrderBy = "name";
        }
        public string SearchTerm { get; set; }
    }

    public class PurchaseParameters : RequestParameters { }
}
