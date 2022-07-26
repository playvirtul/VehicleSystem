namespace VehicleSystem
{
    public class CargoAutomobile : Automobile
    {
        public const int INFLUENCE_LOAD_CAPACITY = 200;
        public const int LOAD_CAPACITY_PERCENT = 4;

        public CargoAutomobile(double averageFuel, int fuelVolume, double speed, int loadCapacity) 
            : base(averageFuel, fuelVolume, speed)
        {
            if(loadCapacity <= 0)
                throw new ArgumentException($"Грузоподъёмность не может быть меньше 0");

            if(loadCapacity > INFLUENCE_LOAD_CAPACITY * (100 / LOAD_CAPACITY_PERCENT))
                throw new ArgumentException($"Грузоподъёмность не может превышать {INFLUENCE_LOAD_CAPACITY * (100 / LOAD_CAPACITY_PERCENT)}");

            LoadCapacity = loadCapacity;
        }

        /// <summary>
        /// Грузоподъёмность.
        /// </summary>
        public int LoadCapacity { get; }
        
        public override int PowerReserveDistance(int fuelQuantity)
        {
            var distance = (fuelQuantity * 100) / (int)AverageFuel;

            var percent = (distance / 100) * ((LoadCapacity / INFLUENCE_LOAD_CAPACITY) * LOAD_CAPACITY_PERCENT);
            distance -= percent;

            return distance;
        }

        public override string InfoAboutPowerReserve(int fuelQuantity)
        {
            var powerReserve = PowerReserveDistance(fuelQuantity);

            return new string($"Состояние запаса хода на данный момент - {powerReserve}");
        }

        public override double CalculateTime(int fuelQuantity, int distance)
        {
            if (distance > PowerReserveDistance(fuelQuantity))
                throw new Exception("");

            var time = Math.Round(distance / Speed, 1);

            return time;
        }
    }
}
