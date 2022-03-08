using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateRegister
{
    class ArableLand: RealEstate
    {
        private Cultivation department;

        public Cultivation Department
        {
            get { return department; }
            protected set { department = value; }
        }

        private double area;

        public double Area
        {
            get { return area; }
            set {
                if (value <= 0)
                    throw new Exception("Nem lehet negatív szám!");

                area = value; }
        }

        public ArableLand(string parcelNumber, double area, Cultivation department, int price) : base(parcelNumber, price)
        {
            Area = area;
            Department = department;
        }

        public override void PriceIncrease(int amount)
        {
            this.Price += (int)(amount * area);
        }

        public override string ParcelNumber
        {
            protected set
            {
                if (!value.StartsWith("0"))
                    throw new Exception("A termőföld helyrajzi száma nullával kell kezdődnie!");

                base.ParcelNumber = value;
            }
        }
    }
}
