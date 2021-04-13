using MyBillTimeTracker.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyBillTimeTracker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//content.Content = new MainControl();
			//content.Content = new ClientControl();
			//content.Content = new DefaultsControl();
			//content.Content = new PaymentsControl();
			//content.Content = new WorkControl();
			content.Content = new AboutControl();
		}
	}
}
