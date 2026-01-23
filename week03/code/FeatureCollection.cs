public class FeatureCollection
{
    // The JSON has a "features" array containing earthquake data
    public Feature[] Features { get; set; }
}

public class Feature
{
    // Each feature has a "properties" object with earthquake details
    public Properties Properties { get; set; }
}

public class Properties
{
    // The magnitude of the earthquake
    public double? Mag { get; set; }

    // The location/place description of the earthquake
    public string Place { get; set; }
}