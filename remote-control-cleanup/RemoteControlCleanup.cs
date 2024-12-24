public class RemoteControlCar
{
    private Speed currentSpeed;
    public string CurrentSponsor { get; private set; }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = SpeedUnits == SpeedUnits.CentimetersPerSecond 
                ? "centimeters per second" 
                : "meters per second";
            return $"{Amount} {unitsString}";
        }
    }

    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    public TelemetrySystem Telemetry { get; }

    public class TelemetrySystem
    {
        private readonly RemoteControlCar car;

        internal TelemetrySystem(RemoteControlCar car)
        {
            this.car = car;
        }

        public void Calibrate()
        {
        }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName)
        {
            car.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            var speedUnits = unitsString == "cps" 
                ? SpeedUnits.CentimetersPerSecond 
                : SpeedUnits.MetersPerSecond;
            
            car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public RemoteControlCar()
    {
        Telemetry = new TelemetrySystem(this);
    }

    public string GetSpeed() => currentSpeed.ToString();

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
}
