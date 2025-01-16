public class Options
{
    private static Options _instance;

    public static Options Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Options();

            return _instance;
        }
    }

    public int Color { get; set; }

    public float MusicLevel {get; set;}

    public float SoundsLevel {get; set;}

    private readonly string[] ColorDictionnary = {"#FF0000", "#00FF00", "#0000FF"};

    public string GetColorHexa()
    {
        return ColorDictionnary[Color];
    }

    private Options()
    {
        Color = 0;
        MusicLevel = 100;
        SoundsLevel = 100;
    }
}