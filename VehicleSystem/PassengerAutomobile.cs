namespace VehicleSystem
{
    public class PassengerAutomobile : Automobile
    {
        public const int MAX_PASSENGERS_AMOUNT = 3;
        public const int PASSENGER_PERCENT = 6;

        /// <summary>
        /// Инициализирует новый экземпляр класса PassengerAutomobile.
        /// </summary>
        /// <param name="averageFuel">Ссредний расход топлива на 100км.</param>
        /// <param name="fuelVolume">Объем топливного бака.</param>
        /// <param name="speed">Скорость автомобиля.</param>
        /// <param name="passengersAmount">Количество пассажиров.</param>
        public PassengerAutomobile(double averageFuel, int fuelVolume, double speed, int passengersAmount)
            : base(averageFuel, fuelVolume, speed)
        {
            if (passengersAmount > 3)
                throw new ArgumentException($"Пассажиров не может быть больше {MAX_PASSENGERS_AMOUNT}");

            PassengersAmount = passengersAmount;
        }

        public int PassengersAmount { get; } = 0;

        public override int PowerReserveDistance(int fuelQuantity)
        {
            var distance = (fuelQuantity * 100) / (int)AverageFuel;

            if (PassengersAmount != 0)
            {
                var percent = (distance / 100) * (PassengersAmount * PASSENGER_PERCENT);
                distance -= percent;
            }

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
