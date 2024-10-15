using GmailAppWpf.ViewModels;
using System.Windows;

namespace GmailAppWpf.Views;


public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		DataContext=new MainViewModel();
	}
}
