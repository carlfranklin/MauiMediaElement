# Table of Contents

- [Table of Contents](#table-of-contents)
	- [Introduction](#introduction)
	- [Prerequisites](#prerequisites)
		- [.NET 7.0](#net-70)
		- [Visual Studio 2022](#visual-studio-2022)
		- [Required Workloads](#required-workloads)
	- [Demo](#demo)
		- [Create a .NET MAUI Application](#create-a-net-maui-application)
	- [Summary](#summary)
	- [Complete Code](#complete-code)
	- [Resources](#resources)

## Introduction

In this demo, we will explore the capabilities of the **MediaElement** control in a **.NET MAUI** Application. By delving deep into the **MediaElement** control, we'll discover its powerful features.

The **MediaElement** control provides a simple way to play audio and video files. It supports a wide range of media formats, including MP3, WAV, OGG, MPEG, and many others. The control can also be used to play media from URLs or streams.

In addition to basic playback features, the **MediaElement** control provides a number of features, such as the ability to control playback speed, and adjust volume. Developers can also customize the control's appearance and behavior to suit their specific needs.

Overall, the **MediaElement** control is a powerful and flexible tool for adding multimedia capabilities to your cross-platform applications built using **MAUI**.

>:blue_book: The MediaElement control is compatible with a variety of platforms including iOS, Android, Windows, macOS, and Tizen.

By the end of this demo, you will have achieved the following end results:

![Windows](images/403c9681ca22c701ed53df7b7da5039d15fb9455265df317181bf5c10454f9c8.png)  

## Prerequisites

The following prerequisites are needed for this demo.

### .NET 7.0

Download the latest version of the .NET 7.0 SDK [here](https://dotnet.microsoft.com/en-us/download).

### Visual Studio 2022

For this demo, we are going to use the latest version of [Visual Studio 2022](https://visualstudio.microsoft.com/vs/community/).

### Required Workloads

In order to build `.NET MAUI` applications, you also need the `.NET Multi-platform App UI development` workload, so if you do not have it installed let's do that now.

![.NET Multi-platform App UI development](images/34640f10f2d813f245973ddb81ffa401c7366e96e625b3e59c7c51a78bbb2056.png)  

## Demo

In the following demo we will create a **.NET MAUI Application** and we will cover the main features of the **MediaElement** control, including:

- Playing audio and video files
- Playing media from URLs or embedded files
- Customizing appearance and behavior
- Adjusting volume

### Create a .NET MAUI Application

Before we can explore the features of the MediaElement control in MAUI, we need to create a new MAUI application. To do this, follow these steps:

Create a new MAUI project.

![Create a new MAUI project](images/fb54d5c0a15798c89f78f1b64b43682672231b092820be8eacd702516cc0bf20.png)  

Name the project **MauiXamlMediaElement** and choose the location where you want to save it, and click **Next**.  Select **.NET 7.0 (Standard Term Support)** for the **Framework** and click **Create**.

Once your project is created, you'll see the default **MAUI** app with a basic layout.

To add the **MediaElement** control to your layout, you would simply add the following code to your **XAML** file:

```xaml
<MediaElement Source="{URL TO SOURCE LINK}" />
```

To use the **MediaElement** control in your application, you'll need to add the corresponding **NuGet** package. This control is part of the **.NET Multi-platform App UI (.NET MAUI) Community Toolkit**, so the first step is to include the package in your project.

Open the **NuGet Package Console** and run the following command:

```powershell
install-package CommunityToolkit.Maui.MediaElement
```

You will be presented with a *ReadMe.txt* file with instructions on how to enable the **.NET Multi-platform App UI (.NET MAUI) Community Toolkit**. In short, you need to add **.UseMauiCommunityToolkitMediaElement()** to initialize the **.NET MAUI Community Toolkit MediaElement** control in to your **builder** code.

Add **.UseMauiCommunityToolkitMediaElement()** after **.UseMauiApp<App>()**.

Your *MainProgram.cs* file should look like this now:

```csharp
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MauiXamlMediaElement;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
```

>:blue_book: For more information about the **.NET Multi-platform App UI (.NET MAUI) Community Toolkit** go to https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/

Open up *MainPage.xaml* and add the following namespace at the top:

```xaml
xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
```

Now you can use the toolkit. Let's replace the existing image, labels, and buttons in the *MainPage.xaml* file with the following code:

```xaml
<toolkit:MediaElement x:Name="videoMediaElement"
    ShouldAutoPlay="True"
    Aspect="AspectFill"
    Source="https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"/>
```

The full *MainPage.xaml* file should look like this:

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
              xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
             x:Class="MauiXamlMediaElement.MainPage">

	<ScrollView>
		<VerticalStackLayout
			Spacing="25"
			Padding="30,0"
			VerticalOptions="Center">

        <toolkit:MediaElement x:Name="videoMediaElement"
            ShouldAutoPlay="True"
            Aspect="AspectFill"
            Source="https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"/>
		</VerticalStackLayout>
	</ScrollView>

</ContentPage>
```

>:point_up: In the code snippet above, notice that we're configuring the **MediaElement** control by setting three of its properties: **ShouldAutoPlay** property is set to **True**, so that the video starts playing automatically when the application is launched, **Aspect** is set to **AspectFill**. This setting ensures that the video fills the whole area of its parent control, in this case, the screen minus the margins. Lastly, we're setting the **Source** property to the **URL** of the video that we want to play.

Replace *MainPage.xaml.cs* with the following:

```csharp
namespace MauiXamlMediaElement;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
}
```

Run the application keeping **Windows Machine** as the target, and you should see the *BigBuckBunny.mp4* video playing.

![BigBuckBunny.mp4](images/403c9681ca22c701ed53df7b7da5039d15fb9455265df317181bf5c10454f9c8.png)  

If you click on the video, you automatically get player controls, which allows you to jump to any position on the video, pause and play, change the volume, change the aspect ratio, and even cast the video to other devices.

![Player settings](images/04d270caf268a2c0d6faa295dabef9ffcc9e780f3d82762764c2bf37a51b7f26.png)  

>:point_up: At the time of creating this tutorial, the features on the player controls, were tested but found to be non-functional. Casting the video to a **TV** or **Bluetooth** headset, and changing the aspect ratio did not work. 

Notice that the application also works on **Android**:

![**Android**](images/b2913be16abf493ea4c032098bc8d43f4cb6b325c67d8bf5176adf1e44e3f746.png)  

The **Android** player only shows the ability to pause and play, and to jump to any position on the video.

![Android](images/69e41dd74afa050c9e31049fe52833ee531bc653927832abbfab66a67396fa3f.png)  

>:blue_book: You can hide the player controls from the users by setting the **ShouldShowPlaybackControls** property to **False**.

Now, we are going to add an **MP3** audio file to the solution and play it from a button click. 

Go to the *Platforms/Resources/Raw* folder, right-click on it, and click on the **Add/Existing Item...** option, and select an audio file. If you want to use the one I used, download it from the repo.

![Add/Existing Item](images/1282660c7a2d2c412e044852e3a6023ecdf82eff2bdfa3aca4015668f4f881b8.png)  

![Audio File](images/cb6e9f08ab486a9e4de79342d0c51e917fd60c22c767962a711dd844483e6594.png)  

Add the following markup before the video `MediaElement`:

```xaml
<Button Text="Play Audio" Clicked="Button_Clicked" />

<toolkit:MediaElement x:Name="audioMediaElement"
                      IsVisible="False"
                      Source="embed://audio.mp3"
                      ShouldShowPlaybackControls="True"
                      />
```

The complete *MainPage.xaml* file should look like this:

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
			 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
			 xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
			 x:Class="MauiXamlMediaElement.MainPage">

	<ScrollView>
		<VerticalStackLayout Spacing="25"
							 Padding="30,0"
							 VerticalOptions="Center">
            <Button Text="Play Audio" Clicked="Button_Clicked" />

            <toolkit:MediaElement x:Name="audioMediaElement"
								  IsVisible="False"
								  Source="embed://audio.mp3"
                                  ShouldShowPlaybackControls="True"
								  />

            <toolkit:MediaElement x:Name="videoMediaElement"
								  IsVisible="True"
								  ShouldAutoPlay="True"
								  Aspect="AspectFill"
								  Source="https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" 
                                  />
		</VerticalStackLayout>
	</ScrollView>

</ContentPage>
```

Replace *MainPage.xaml.cs* file with the following:

```csharp
namespace MauiXamlMediaElement;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        audioMediaElement.Play();
    }
}
```

Run the application on **Windows**. The video starts playing. You can play the embedded audio file by clicking the **Play Audio** button.

![image-20230306125654951](images/image-20230306125654951.png)

Finally let's add the ability to control the volume of the video, but modifying the **MediaElement's** volume property with a **Slider**.

Go to the *MainPage.xaml* file and add the following code below the **videoMediaElement**.

```xaml
<HorizontalStackLayout x:Name="volumeControl"
           IsVisible="True">

    <Label Text="Volume" />

    <Slider Maximum="1.0"
        Minimum="0.0"
        Margin="10,0,0,0"
        Value="{Binding Volume}"
        WidthRequest="300" />

</HorizontalStackLayout>
```

The complete file should look like this: 

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
             x:Class="MauiXamlMediaElement.MainPage">

    <ScrollView>
        <VerticalStackLayout Spacing="25"
							 Padding="30,0"
							 VerticalOptions="Center">

            <Button Text="Play Audio" Clicked="Button_Clicked" />

            <toolkit:MediaElement x:Name="audioMediaElement"
								  IsVisible="False"
								  Source="embed://audio.mp3"
                                  ShouldShowPlaybackControls="True"
								  />

            <toolkit:MediaElement x:Name="videoMediaElement"
								  IsVisible="True"
								  ShouldAutoPlay="True"
								  Aspect="AspectFill"
								  Source="https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" 
                                  />

            <HorizontalStackLayout x:Name="volumeControl"
								   IsVisible="True">
                <Label Text="Volume" />

                <Slider Maximum="1.0"
						Minimum="0.0"
                        Margin="10,0,0,0"
						Value="{Binding Volume}"
						WidthRequest="300" />
            </HorizontalStackLayout>

        </VerticalStackLayout>
    </ScrollView>

</ContentPage>
```

Replace *MainPage.xaml.cs* with the following:

```csharp
namespace MauiXamlMediaElement;

public partial class MainPage : ContentPage
{
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

    private void Button_Clicked(object sender, EventArgs e)
    {
        audioMediaElement.Play();
    }
}
```

Run the application. You can change the volume for both audio and video using the **Slider**.

 ![image-20230306123525332](images/image-20230306123525332.png)

## Summary

In this demo we looked at the **MediaElement** control in a **.NET MAUI** application. The **MediaElement** control provides a simple way to play audio and video files in a wide range of media formats, including MP3, WAV, OGG, MPEG, and many others, as well as media from URLs or embedded files.

We also learn how to play video and audio files, from a URL and embedded files. 

Finally we learned how to adjust the volume using the **Slider** control.

For more information about the **.NET MAUI MediaElement** control, check-out the resources below.

## Complete Code

The complete code for this demo can be found in the link below.

- <https://github.com/carlfranklin/MauiMediaElement>

## Resources

| Resource                                                               | Url                                                                                 |
| ---------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| The .NET Show with Carl Franklin                                       | <https://www.youtube.com/playlist?list=PL8h4jt35t1wgW_PqzZ9USrHvvnk8JMQy_>          |
| Download .NET                                                          | <https://dotnet.microsoft.com/en-us/download>                                       |
| .NET Multi-platform App UI documentation                               | <https://docs.microsoft.com/en-us/dotnet/maui/>                                     |
| .NET Multi-platform App UI (.NET MAUI) Community Toolkit documentation | <https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/>                   |
| MediaElement                                                           | <https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/mediaelement> |
