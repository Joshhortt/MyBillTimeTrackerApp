﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBillTimeLibrary.Models
{
	public class DefaultsModel
	{
		//Properties
		public double HourlyRate { get; set; } 
		public int PreBill { get; set; }  
		public int HasCutOff { get; set; }  
		public int CutOff { get; set; }  
		public double MinimumHours { get; set; } 
		public double BillingIncrement { get; set; }  
		public int RoundUpAfterXMinutes { get; set; }  
	}
}
