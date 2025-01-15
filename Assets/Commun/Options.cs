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

    public string test;

    public bool IsBackgroundMusicEnabled { get; set; }

    private readonly string[] ColorDictionnary = {"#FF0000", "#00FF00", "#0000FF"};

    public string GetColorHexa()
    {
        return ColorDictionnary[Color];
    }

    private Options()
    {
        Color = 0;
        IsBackgroundMusicEnabled = true;
        test = "hello";
    }
}