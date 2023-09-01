using MusicFestivalApp.View;
using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp;

public partial class AppShell : Shell
{
	public Dictionary<string, Type> Routes { get; set; } =new Dictionary<string, Type>();
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddUpdateFestivalEventDetail),typeof(AddUpdateFestivalEventDetail));
        //Routing.RegisterRoute(nameof(ArtistDetailView), typeof(ArtistDetailView));
        Routing.RegisterRoute(nameof(AddUpdateArtistList), typeof(AddUpdateArtistList));
        Routing.RegisterRoute(nameof(AddUpdateSponsorList), typeof(AddUpdateSponsorList));

        Routes.Add(nameof(ArtistDetailView), (typeof(ArtistDetailView)));
		foreach(var route in Routes)
		{
            Routing.RegisterRoute(route.Key, route.Value);

        }
    }
}
