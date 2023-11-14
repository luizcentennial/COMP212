using System.Collections.Generic;

namespace Example21.Services.Definitions {
    public interface IService<T> {
        public void Create(T obj);
        public void Update(T obj);
        public void Delete(T obj);
        public T Get(string id);
        public IEnumerable<T> GetAll();
    }
}
