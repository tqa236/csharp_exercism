class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven()
    {
        return 40;
    }
    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int numLayers)
    {
        return ExpectedMinutesInOven() - numLayers;
    }
    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int numLayers)
    {
        return 2 * numLayers;
    }
    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int numLayers, int elapsedTime)
    {
        return PreparationTimeInMinutes(numLayers) + elapsedTime;
    }
}
