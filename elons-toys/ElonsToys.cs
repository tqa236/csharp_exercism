using System;

class RemoteControlCar
{
    private int distanceDriven = 0;
    private int batteryPercentage = 100;

    public RemoteControlCar() { }

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {distanceDriven} meters";

    public string BatteryDisplay() => batteryPercentage == 0 ? "Battery empty" : $"Battery at {batteryPercentage}%";

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            distanceDriven += 20;
            batteryPercentage -= 1;
        }
    }
}
