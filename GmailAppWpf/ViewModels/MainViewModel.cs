using GmailAppWpf.Models;
using GmailAppWpf.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace GmailAppWpf.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
	private Page _currentPage;
	private MenuItemModel _selectedMenuItem;

	public Page CurrentPage
	{
		get { return _currentPage; }
		set
		{
			_currentPage = value;
			OnPropertyChanged(nameof(CurrentPage));
		}
	}

	public MenuItemModel SelectedMenuItem
	{
		get { return _selectedMenuItem; }
		set
		{
			_selectedMenuItem = value;
			OnPropertyChanged(nameof(SelectedMenuItem));
			NavigateToPage(_selectedMenuItem?.Name); // Call method to navigate
		}
	}

	public ObservableCollection<MenuItemModel> MenuItems { get; set; }

	public MainViewModel()
	{
		// Initialize the menu items
		MenuItems = new ObservableCollection<MenuItemModel>
		{
			new MenuItemModel { Name = "Inbox", Icon = "Inbox" },
			new MenuItemModel { Name = "Starred", Icon = "Star" }
            // Add other items like "Snoozed", "Sent", etc.
        };

		// Set a default page
		CurrentPage = new InboxPage();
	}

	private void NavigateToPage(string pageName)
	{
		switch (pageName)
		{
			case "Inbox":
				CurrentPage = new InboxPage();
				break;
			case "Starred":
				
				break;
				// Add more cases for other pages
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;
	protected void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
