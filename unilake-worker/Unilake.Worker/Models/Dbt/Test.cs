namespace Unilake.Worker.Models.Dbt;

public class Test : Node
{
    public Test(string label, string key, string url) : base(label, key, url)
    {
        IconPath = new IconPath
        {
            Light = Path.Join(Path.GetDirectoryName(typeof(Node).Assembly.Location), "../media/images/source_light.svg"),
            Dark = Path.Join(Path.GetDirectoryName(typeof(Node).Assembly.Location), "../media/images/source_dark.svg")
        };
    }
}