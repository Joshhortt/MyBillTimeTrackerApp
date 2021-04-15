﻿using MyBillTimeLibrary.DataAccess;
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
	/// Interaction logic for ClientControl.xaml
	/// </summary>
	public partial class ClientControl : UserControl
	{
		List<ClientModel> clients;

		public ClientControl()
		{
			InitializeComponent();

			InitializeClientList();

			WireUpClientDropDown();

		}

		private void WireUpClientDropDown()
		{
			clientDropDown.ItemsSource = clients;
			clientDropDown.DisplayMemberPath = "Name";
			clientDropDown.SelectedValuePath = "Id";
		}

		private void InitializeClientList()
		{
			string sql = "select * from Client";
			clients = SqliteDataAccess.LoadData<ClientModel>(sql, new Dictionary<string, object>());
		}
	}
}
