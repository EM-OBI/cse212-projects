public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public List<Feature> features { get; set; }

}

public class Feature
{
    public Properties properties { get; set; }

}

public class Properties
{
    public decimal mag { get; set; }
    public string place { get; set; }
}