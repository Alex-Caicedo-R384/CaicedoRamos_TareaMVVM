using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CaicedoRamos_TareaMVVM.ViewModels;

internal class AboutViewModel
{
    public string ACTitle => AppInfo.Name;
    public string ACVersion => AppInfo.VersionString;
    public string ACMoreInfoUrl => "https://aka.ms/maui";
    public string ACMessage => "This app is written in XAML and C# with .NET MAUI.";
    public ICommand ShowMoreInfoCommand { get; }

    public AboutViewModel()
    {
        ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
    }

    async Task ShowMoreInfo() =>
        await Launcher.Default.OpenAsync(ACMoreInfoUrl);
}
