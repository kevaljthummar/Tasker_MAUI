using System.Collections.ObjectModel;
using PropertyChanged;
using Tasker_MAUI.MVVM.Models;

namespace Tasker_MAUI.MVVM.ViewModes
{
    [AddINotifyPropertyChangedInterface]
    public class NewTaskViewModel
	{
		public string Task { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }
    }
}

