using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateRegister
{
    class ResidentialBuilding: RealEstate
    {
        private string address;

        public string Address
        {
            get { return address; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("A cím kitöltése kötelező!");
                address = value; }
        }

        private BuildingType type;

        public BuildingType Type
        {
            get { return type; }
            private set { type = value; }
        }

        private bool breakDown;

        public bool BreakDown
        {       
            get { return breakDown; }
            set {
                if (breakDown && value != true)
                    throw new Exception("Ha már bontandó akkor nem lehet visszaállítani nem bontandóra!");
                
                breakDown = value; }
        }

        public ResidentialBuilding(string parcelNumber, int price, string address, BuildingType type): base(parcelNumber, price)
        {
            Address = address;
            Type = type;
        }

        public ResidentialBuilding(string parcelNumber, int price, string address): this(parcelNumber, price, address, BuildingType.Family)
        {
        }
    }
}
