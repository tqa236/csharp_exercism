using System;

class RemoteControlCar
{
    public int Speed { get; private set; }
    public int BatteryDrain { get; private set; }
    private int distanceDriven;
    private int battery;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        Speed = speed;
        BatteryDrain = batteryDrain;
        distanceDriven = 0;
        battery = 100;
    }

    public bool BatteryDrained() => battery < BatteryDrain;

    public int DistanceDriven() => distanceDriven;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDriven += Speed;
            battery -= BatteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance) => this.distance = distance;

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int maxPossibleDistance = 0;
        int remainingBattery = 100;

        while (remainingBattery >= car.BatteryDrain)
        {
            maxPossibleDistance += car.Speed;
            remainingBattery -= car.BatteryDrain;
        }

        return maxPossibleDistance >= distance;
    }
}
