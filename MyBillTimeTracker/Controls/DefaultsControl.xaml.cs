using MyBillTimeLibrary.DataAccess;
using MyBillTimeLibrary.Models;
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

namespace MyBillTimeTracker.Controls
{
	/// <summary>
	/// Interaction logic for DefaultsControl.xaml
	/// </summary>
	public partial class DefaultsControl : UserControl
	{
		public DefaultsControl()
		{
			InitializeComponent();
			LoadDefaultsFromDatabase();
		}

		private void LoadDefaultsFromDatabase()
		{
			string sql = "select * from Defaults";
			DefaultsModel model = SqliteDataAccess.LoadData<DefaultsModel>(sql, new Dictionary<string, object>()).FirstOrDefault();

			if(model != null)
			{
				hourlyRateTextbox.Text = model.HorasMinimas.ToString();
				preBillCheckbox.IsChecked = (model.HorasMinimas > 0);
				hasCutOffCheckBox.IsChecked = (model.LimiteRomper > 0);
				cutOffTextbox.Text = model.Romper.ToString();
				minimumHoursTextbox.Text = model.HorasMinimas.ToString();
				billingIncrementTextbox.Text = model.IncrementoCobrado.ToString();
				roundUpTextbox.Text = model.ArredondarCimaMinutos.ToString();
			}

			else
			{
				hourlyRateTextbox.Text = "0";
				preBillCheckbox.IsChecked = true;
				hasCutOffCheckBox.IsChecked = false;
				cutOffTextbox.Text = "0";
				minimumHoursTextbox.Text = "0.25";
				billingIncrementTextbox.Text = "0.25";
				roundUpTextbox.Text = "0";
			}
		}
	}
}
