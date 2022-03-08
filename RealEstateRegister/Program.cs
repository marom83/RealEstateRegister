using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RealEstateRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            LandOffice landOffice = new LandOffice();

            StreamReader reader = new StreamReader("real_estate.txt");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(';');

                switch (data.Length)
                {
                    case 2:
                        landOffice.AddRealEstate(new RealEstate(
                            data[0],
                            int.Parse(data[1])
                    ));
                        break;
                    case 4:
                        landOffice.AddRealEstate(new ArableLand(
                            data[0],
                            double.Parse(data[1]),
                            (Cultivation)Enum.Parse(typeof(Cultivation), data[2]),
                            int.Parse(data[3])
                        ));
                        break;
                    case 5:
                        landOffice.AddRealEstate(new ResidentialBuilding(
                           data[0],
                           int.Parse(data[1]),
                           data[2]),
                           (BuildingType)Enum.Parse(typeof(BuildingType), data[3]),
                           bool.Parse(data[4])
                        ));
                        break;
                    default:
                        throw new Exception("Nem megfelelő a bemenet hossza.");
                }
            }
            reader.Close();

            RealEstate z = landOffice.MoreExpensive;
            Console.WriteLine("A legdrágább ingatlan helyrajzi száma: {0}, az ingatlan {1} Ft-ba kerül.", z.ParcelNumber, z.Price);

            Console.WriteLine("Az erdők átlagos területe: {0}", landOffice.Average(Cultivation.Forest));

            Console.WriteLine("A bontandó családi házak címe: {0}", landOffice.SummaryBreakDown(BuildingType.Family));

            Console.ReadLine();
        }
    }
}
