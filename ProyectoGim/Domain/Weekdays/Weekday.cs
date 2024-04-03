using Domain.Instructors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Weekdays
{
	public class Weekday : Entity
	{
		public Weekday()
		{ }

		public static Weekday Create
			(int id, string idDiaSemana, string dia)
		{
			return new()
			{
				Id = id,
				IdDiaSemana = idDiaSemana,
				Dia = dia,
				
			};
		}

		public static Weekday Create
			(int id, Weekday weekday)
		{
			return new()
			{
				Id = id,
				IdDiaSemana = weekday.IdDiaSemana,
				Dia = weekday.Dia,
			};
		}

		[Key]
		[JsonInclude]
		[JsonPropertyName("id")]
		public int Id { get; private set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(10, MinimumLength = 5)]
		[JsonInclude]
		[JsonPropertyName("idEntrenador")]
		public string IdDiaSemana { get; private set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(9, MinimumLength = 5)]
		[JsonInclude]
		[JsonPropertyName("dia")]
		public string Dia { get; private set; }

		
		
		
		
		/*
[JsonIgnore]
public List<Course> Courses { get; private set; } 
*/
	}
}

