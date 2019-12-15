using System;
using System.Windows.Input;
using Task_Manager.ViewModels;

namespace Task_Manager.Command
{
	class AddCommand : ICommand
	{

		public AddCommand(TaskListViewModel ViewModel) {
			_ViewModel = ViewModel;
		}

		private TaskListViewModel _ViewModel;

		public event EventHandler CanExecuteChanged {
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _ViewModel.CanAdd();
		}

		public void Execute(object parameter)
		{
			_ViewModel.OnAdd();
		}
	}
}
