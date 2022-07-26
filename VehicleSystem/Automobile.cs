namespace VehicleSystem
{
    public abstract class Automobile
    {
        /// <summary>
        /// Средний расход топлива в литрах на 100км.
        /// </summary>
        public double AverageFuel { get; }

        /// <summary>
        /// Объем топливного бака в литрах на данный момент.
        /// </summary>
        public int FuelVolume { get; }

        /// <summary>
        /// Скорость автомобиля.
        /// </summary>
        public double Speed { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса  Automobile.
        /// </summary>
        /// <param name="averageFuel">Ссредний расход топлива на 100км.</param>
        /// <param name="fuelVolume">Объем топливного бака.</param>
        /// <param name="speed">Скорость автомобиля в км/ч.</param>
        protected Automobile(double averageFuel, int fuelVolume, double speed)
        {
            // сделать проверки
            if (averageFuel <= 0 )
                throw new ArgumentException("Средний расход топлива не может быть меньше 0.");
            if (fuelVolume <= 0)
                throw new ArgumentException("Объем топливного бака не может быть меньше 0.");
            if (speed <= 0)
                throw new ArgumentException("Скорость не может быть меньше 0.");

            AverageFuel = averageFuel;
            FuelVolume = fuelVolume;
            Speed = speed;
        }

        /// <summary>
        /// Метод, вычисляющий сколько автомобиль может проехать на полном баке топлива или на остаточном
        /// количестве топлива в баке на данный момент.
        /// </summary>
        /// <param name="fuelQuantity">Количество топлива на данный момент.</param>
        /// <returns>Возвращает расстояние в км, которое автомобиль может проехать на данный момент.</returns>
        public abstract int PowerReserveDistance(int fuelQuantity);


        /// <summary>
        /// Метод для отображения текущей информации о состоянии запаса хода.
        /// </summary>
        /// <param name="fuelQuantity">Количество топлива на данный момент.</param>
        /// <returns>Возвращает строку с иформацией о состоянии запаса хода.</returns>
        public abstract string InfoAboutPowerReserve(int fuelQuantity);

        /// <summary>
        /// Метод, который на основе параметров количества топлива и заданного расстояния вычисляет за сколько автомобиль его преодолеет.
        /// </summary>
        /// <param name="fuelQuantity">Количество топлива.</param>
        /// <param name="distance">Расстояние.</param>
        /// <returns>Время в часах, за которое автомобиль преодолевает расстояние.</returns>
        public abstract double CalculateTime(int fuelQuantity, int distance);
    }
}