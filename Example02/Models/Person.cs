using System;
using System.Text;

namespace Example02.Models {
	public class Person {
		public string PersonID { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }

		public Person() {
			this.PersonID = Guid.NewGuid().ToString();
		}

		public override string ToString() {
			StringBuilder builder = new StringBuilder();

			foreach (var property in typeof(Person).GetProperties()) {
				builder.AppendLine($"{property.Name}: {property.GetValue(this)}");
			}

			return builder.ToString();
		}
	}
}
