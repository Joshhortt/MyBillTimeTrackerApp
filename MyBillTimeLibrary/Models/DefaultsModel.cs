using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBillTimeLibrary.Models
{
	public class DefaultsModel
	{
		//Properties
		public double  TaxaHora { get; set; }  //HourlyRate
		public int PreFatura { get; set; }  //PreBill
		public int LimiteRomper { get; set; }  //HasCutOff
		public int Romper { get; set; }  //CutOff
		public double HorasMinimas { get; set; } //MinimumHour
		public double IncrementoCobrado { get; set; }  //BillingIncrement
		public int ArredondarCimaMinutos { get; set; }  //RoundUpAfterXMinutes
	}
}
