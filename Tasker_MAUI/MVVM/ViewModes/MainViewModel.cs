using System;
using System.Collections.ObjectModel;
using PropertyChanged;
using Tasker_MAUI.MVVM.Models;

namespace Tasker_MAUI.MVVM.ViewModes
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
	{
		public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }


        public MainViewModel()
		{
			FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
		}

        private void Tasks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
			Categories = new ObservableCollection<Category>
			{
				new Category
				{
					Id = 1,
					CategoryName = ".Net MAUI Cource",
					Color = "#CF14DF"
				},
                new Category
                {
                    Id = 2,
                    CategoryName = "Tutorials",
                    Color = "#df6f14"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Shopping",
                    Color = "#14df80"
                },
            };

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Upload exercies files",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Plan next cource",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Upload exercies files",
                    Completed = false,
                    CategoryId = 1
                }
            };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach(var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;

                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }

            foreach(var t in Tasks)
            {
                var catColor = (from c in Categories
                                where c.Id == t.CategoryId
                                select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}

