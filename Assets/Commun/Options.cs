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

    public float MusicLevel { get; set; }

    public float SoundsLevel { get; set; }

    private readonly string[] ColorDictionnary = { "#FF0000", "#00FF00", "#0000FF", "#FFD700", "#8A2BE2", "#FF00FF", "#FF4500", "#40E0D0", "#C0C0C0", "#E5B9B7", "#000000", "#FFFFFF" };


    public string GetColorHexa()
    {
        return ColorDictionnary[Color];
    }

    private Options()
    {
        Color = 0;
        MusicLevel = 1;
        SoundsLevel = 0.2f;
    }
}