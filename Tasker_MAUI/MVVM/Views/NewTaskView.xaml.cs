using Tasker_MAUI.MVVM.Models;
using Tasker_MAUI.MVVM.ViewModes;

namespace Tasker_MAUI.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
        InitializeComponent();
	}

    private async void AddNewTaskClicked(System.Object sender, System.EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        if(string.IsNullOrEmpty(vm.Task))
        {
            await DisplayAlert("Enter Task!!", "You must enter a task value", "Ok");
        }

        var selectedCategory =
            vm.Categories.Where(x => x.IsSelected).FirstOrDefault();

        if(selectedCategory != null)
        {
            var task = new MyTask
            {
                TaskName = vm.Task,
                CategoryId = selectedCategory.Id,
            };
            vm.Tasks.Add(task);
            await Navigation.PopAsync();
        }
        else {
            await DisplayAlert("Invalid Selection", "You must select a category", "Ok");
        }
    }

    private async void AddCategoryClicked(System.Object sender, System.EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        string category =
                await DisplayPromptAsync("New Category",
                "Write the new category name",
                maxLength: 15,
                keyboard: Keyboard.Text);

        var r = new Random();

        if(!string.IsNullOrEmpty(category))
        {
            vm.Categories.Add(new Category()
            {
                Id = vm.Categories.Max(x => x.Id) + 1,
                Color = Color.FromRgb(
                            r.Next(0, 255),
                            r.Next(0, 255),
                            r.Next(0, 255)).ToHex(),
                CategoryName = category
            });
        }
    }
}
