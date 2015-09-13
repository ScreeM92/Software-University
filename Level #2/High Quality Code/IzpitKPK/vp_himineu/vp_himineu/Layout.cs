namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Layout
    {
        public int numberOfSectors;
        public int placesPerSector;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            if (numberOfSectors <= 0)
            {
                throw new DivideByZeroException("The number of sectors must be positive.");
            }

            this.numberOfSectors = numberOfSectors;

            if (placesPerSector <= 0)
            {
                throw new DivideByZeroException("The number of places per sector must be positive.");
            }

            this.placesPerSector = placesPerSector;
        }
    }
}
