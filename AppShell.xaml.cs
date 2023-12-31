namespace CaicedoRamos_TareaMVVM;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
    }
}
