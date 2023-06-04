using Tasker_MAUI.MVVM.ViewModes;
using Tasker_MAUI.MVVM.Views;

namespace Tasker_MAUI;

public partial class MainView : ContentPage
{
	private MainViewModel mainViewModel = new MainViewModel();
	public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

    private void checkBox_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
		mainViewModel.UpdateData();
    }

    private void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		var taskView = new NewTaskView()
		{
			BindingContext = new NewTaskViewModel()
			{
				Tasks = mainViewModel.Tasks,
				Categories = mainViewModel.Categories,
			}
		};

		Navigation.PushAsync(taskView);
    }
}
