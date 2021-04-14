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

		// Start Validating
		private (bool isValid, DefaultsModel model) ValidateForm()
		{
			bool isValid = true;
			DefaultsModel model = new DefaultsModel();
			
			try
			{
				// 1 means if it is checked / True --- O if it is not checked / false
				model.PreFatura = (bool)preBillCheckbox.IsChecked ? 1 : 0;
				model.LimiteRomper = (bool)hasCutOffCheckBox.IsChecked ? 1 : 0; 
				model.TaxaHora = double.Parse(hourlyRateTextbox.Text);
				model.Romper = int.Parse(cutOffTextbox.Text);
				model.HorasMinimas = double.Parse(minimumHoursTextbox.Text);
				model.IncrementoCobrado = double.Parse(billingIncrementTextbox.Text);
				model.ArredondarCimaMinutos = int.Parse(roundUpTextbox.Text);
			}
			catch
			{

				isValid = false;
			}

			return(isValid,model);
		}

		// Create call to Database
		private void SaveToDatabase(DefaultsModel model)
		{
			string sql = "delete from Defaults";
			SqliteDataAccess.SaveData(sql, new Dictionary<string, object>());

			sql = "insert into Defaults(TaxaHora, PreFatura, LimiteRomper, Romper, HorasMinimas, IncrementoCobrado, ArredondarCimaMinutos)" +
				"values (@TaxaHora, @PreFatura, @LimiteRomper, @Romper, @HorasMinimas,  @IncrementoCobrado,  @ArredondarCimaMinutos)";

			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{"@TaxaHora", model.TaxaHora },
				{"@PreFatura", model.PreFatura },
				{"@LimiteRomper", model.LimiteRomper },
				{"@Romper", model.Romper },
				{"@HorasMinimas", model.HorasMinimas },
				{"@IncrementoCobrado", model.IncrementoCobrado },
				{"@ArredondarCimaMinutos", model.ArredondarCimaMinutos }
			};
			SqliteDataAccess.SaveData(sql, parameters);
		}

		private void submitForm_Click(object sender, RoutedEventArgs e)
		{

			var form = ValidateForm();

			if (form.isValid == true)
			{
				SaveToDatabase(form.model);
				MessageBox.Show("Success");
			}
			else
			{
				MessageBox.Show("O Formulario não é válido. Confira e Tente novamente!");
				return;
			}

		}
	}
}
