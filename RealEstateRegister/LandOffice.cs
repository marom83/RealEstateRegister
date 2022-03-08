using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateRegister
{
    class LandOffice
    {
        private List<RealEstate> realEstates = new List<RealEstate>();

        public void AddRealEstate(RealEstate a)
        {
            realEstates.Add(a);
            //Ha létezik már ingatlan ilyen helyrajzi számon, akkor dobj kivételt! (szorgalmi: Equals + Contains)
        }

        public RealEstate MoreExpensive
        {
            get
            {
                if (realEstates.Count == 0)
                    throw new Exception("Üres a nyilvántartás!");

                RealEstate max = realEstates[0];
                foreach (RealEstate a in realEstates)
                {
                    if (a.Price > max.Price)
                        max = a;
                }
                return max;
            }
        }
        
        public double Average(Cultivation department)
        {
            double sum = 0;
            int count = 0;
            foreach (RealEstate ab in realEstates)
            {
                if(ab is ArableLand)
                {
                    ArableLand abc = ab as ArableLand;
                    if(abc.Department == department) 
                    { 
                        sum += abc.Area;
                        count++;
                    }
                }    
            }return sum / count;
        }

        public List<string> SummaryBreakDown(BuildingType type)
        {
            List<string> addresses = new List<string>();
            foreach (RealEstate x in realEstates)
            {
                if(x is ResidentialBuilding)
                {
                    ResidentialBuilding y = x as ResidentialBuilding;
                    if (y.BreakDown && y.Type == type)
                    {
                        addresses.Add(y.Address);
                    }
                }
            }return addresses;
        }
    }
}
