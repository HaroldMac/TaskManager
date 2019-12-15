using System;
using System.Windows.Input;
using Task_Manager.ViewModels;

namespace Task_Manager.Command
{
	class DeleteCommand : ICommand
	{
		public DeleteCommand(TaskListViewModel ViewModel)
		{
			_ViewModel = ViewModel;
		}

		private TaskListViewModel _ViewModel;


		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _ViewModel.CanDelete();
		}

		public void Execute(object parameter)
		{
			_ViewModel.OnDelete();
		}
	}
}
