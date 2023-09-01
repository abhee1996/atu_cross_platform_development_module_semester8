using MusicFestivalApp.ViewModel;

namespace MusicFestivalApp.View;

public partial class FestivalListView : ContentPage
{
	//private bool _isPanelTranslated;

    private FestivalListViewModel _viewModel;
    public FestivalListView(FestivalListViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        this.BindingContext = viewModel;
       // panelLeft.TranslateTo(-80, 0, 150);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
       _viewModel.GetFestivalListCommand.Execute(null);
    }
 



























 //   private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
	//{
	//	var viewModel = (FestivalListViewModel)BindingContext;
	//	//viewModel.BindDataToFestivalEventList();
	//}

	//private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	//{
	//	if (_isPanelTranslated)
	//	{
	//		//panelLeft.TranslateTo(-80, 0, 150);
	//	}
	//	else
	//	{
	//		//panelLeft.TranslateTo(0, 0, 150);
	//	}
	//	_isPanelTranslated = !_isPanelTranslated;
	//}
}