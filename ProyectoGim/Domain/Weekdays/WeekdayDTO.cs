using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Weekdays
{
	public class WeekdayDTO
	{
		public WeekdayDTO() { }

		public WeekdayDTO(int id, string idDiaSemana, string dia)
		{
			Id = id;
			IdDiaSemana = idDiaSemana;
			Dia = dia;
		}

		public int Id { get; set; }

		public string IdDiaSemana { get; set; }

		public string Dia { get; set; }
	}
}
