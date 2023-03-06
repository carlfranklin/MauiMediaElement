namespace MauiXamlMediaElement;

public partial class MainPage : ContentPage
{
    public string Position
    {
        get
        {
            if (videoMediaElement != null)
            {
                var pos = videoMediaElement.Position;
                var dur = videoMediaElement.Duration;
                // Using a TimeSpan extension method
                return pos.ToShortTimeString() + "/" + dur.ToShortTimeString();
            }
            else
                return "";
        }
    }

    public double Volume
    {
        get
        {
            if (videoMediaElement != null)
            {
                return videoMediaElement.Volume;
            }
            else return 1;
        }
        set
        {
            bool setFlag = false;
            if (videoMediaElement != null && videoMediaElement.Volume != value)
            {
                videoMediaElement.Volume = value;
                setFlag = true;
            }
            if (audioMediaElement != null && audioMediaElement.Volume != value)
            {
                audioMediaElement.Volume = value;
                setFlag = true;
            }
            if (setFlag)
                OnPropertyChanged(nameof(Volume));
        }
    }

    public MainPage()
    {
        BindingContext = this;

        InitializeComponent();
    }

    private void VideoMediaElement_PositionChanged(object sender, CommunityToolkit.Maui.Core.Primitives.MediaPositionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Position));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        audioMediaElement.Play();
    }

    private void videoMediaElement_Loaded(object sender, EventArgs e)
    {
        videoMediaElement.PositionChanged +=
            VideoMediaElement_PositionChanged;
    }
}