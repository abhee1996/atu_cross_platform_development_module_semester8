using MusicFestivalApp.Services;
using MusicFestivalApp.View;
using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


        //SERVICES//
        builder.Services.AddSingleton<IFestivalService, FestivalServices>();//Festival
        builder.Services.AddSingleton<IArtistService, ArtistService>();//Artist
        builder.Services.AddSingleton<ISponsorService, SponsorService>();//Sponsor


        // VIEWS REGISTERATION//
        //Festival views 
        builder.Services.AddSingleton<FestivalListView>();
        builder.Services.AddTransient<AddUpdateFestivalEventDetail>();
        //Artist views
        builder.Services.AddSingleton<ArtistListView>();
        builder.Services.AddTransient<AddUpdateArtistList>();
        //Sponsor views
        builder.Services.AddSingleton<SponsorsListView>();
        builder.Services.AddTransient<AddUpdateSponsorList>();


        //--------------------------------------------------------------------//

        //VIEW MODEL// 
        //FestivalVM
        builder.Services.AddSingleton<FestivalListViewModel>();
        builder.Services.AddTransient<AddUpdateFestivalEventDetailViewModel>();
        //ArtistVM
        builder.Services.AddSingleton<ArtistListViewModel>();
        builder.Services.AddTransient<AddUpdateArtistViewModel>();
        //SponsorVM
        builder.Services.AddSingleton<SponsorsListViewModel>();
        builder.Services.AddTransient<AddUpdateSponsorViewModel>();


        return builder.Build();
	}
}
