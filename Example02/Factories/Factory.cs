using Example02.Factories.Interfaces;
using System;

namespace Example02.Factories {
	public class Factory<T> : IFactory<T> {
		public T Create() {
			T instance = (T)Activator.CreateInstance(typeof(T));

			return instance;
		}
	}
}
