using CommunityToolkit.Maui.Core.Primitives;

namespace MauiBlazorMediaElement;

public partial class MediaPage : ContentPage
{
    private string mediaStatus = string.Empty;
    public string MediaStatus
    {
        get => mediaStatus;
        private set
        {
            mediaStatus = value;
            OnPropertyChanged(nameof(MediaStatus));
        }
    }

    public string State
    {
        get
        {
            if (videoMediaElement != null)
            {
                return Enum.GetName(typeof(MediaElementState), videoMediaElement.CurrentState);
            }
            else
                return "";
        }
    }

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

    public MediaPage()
    {
        BindingContext = this;
        InitializeComponent();
    }

    private void VideoMediaElement_PositionChanged(object sender, MediaPositionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(Position));
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        videoMediaElement.Stop();
        Navigation.PopModalAsync();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        audioMediaElement.Play();
    }

    private void VideoMediaElement_StateChanged(object sender, MediaStateChangedEventArgs e)
    {
        OnPropertyChanged(nameof(State));
    }

    private void videoMediaElement_Loaded(object sender, EventArgs e)
    {
        videoMediaElement.PositionChanged +=
            VideoMediaElement_PositionChanged;

        videoMediaElement.StateChanged +=
            VideoMediaElement_StateChanged;

        videoMediaElement.MediaOpened
            += VideoMediaElement_MediaOpened;

        videoMediaElement.MediaEnded
            += VideoMediaElement_MediaEnded;

        videoMediaElement.MediaFailed
            += VideoMediaElement_MediaFailed;
    }

    private void VideoMediaElement_MediaFailed(object sender, MediaFailedEventArgs e)
    {
        MediaStatus = "Media Failed";
    }

    private void VideoMediaElement_MediaEnded(object sender, EventArgs e)
    {
        MediaStatus = "Media Ended";
    }

    private void VideoMediaElement_MediaOpened(object sender, EventArgs e)
    {
        MediaStatus = "Media Opened";
    }
}