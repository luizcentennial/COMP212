using Example02.Models;

namespace Example02.Factories {
	public class PersonFactory<TPerson> : Factory<TPerson> where TPerson : Person { 
		// ...
	}
}
