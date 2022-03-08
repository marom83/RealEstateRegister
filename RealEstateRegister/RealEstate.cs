using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateRegister
{
    class RealEstate
    {
        private string parcelNumber;

        public virtual string ParcelNumber
        {
            get { return parcelNumber; }
            protected set {
                if (value.Length < 3)
                    throw new Exception("A helyrajzi számnak minimum 3 karakter hosszúnak kell lennie.");
                
                parcelNumber = value; }
        }

        private int price;

        public int Price
        {
            get { return price; }
            protected set {
                if (value <= 0)
                    throw new Exception("Az ár nem lehet 0 és pozitív számnak kell lennie!");
                if (value % 100000 != 0)
                    throw new Exception("Az árnak osztahónak kell lennie 100000-el!");
                price = value; }
        }

        public RealEstate(string parcelNumber, int price)
        {
            ParcelNumber = parcelNumber;
            Price = price;
        }

        public RealEstate(string parcelNumber) 
            : this(parcelNumber, 1000000000)
        {
        }

        public virtual void PriceIncrease(int amount)
        {
            if (amount <= 0)
                throw new Exception("Az összeg nem lehet nulla, vagy negatív!");
            Price += amount;
        }
    }
}
