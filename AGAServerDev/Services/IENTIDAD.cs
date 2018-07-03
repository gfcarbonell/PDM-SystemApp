using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGAServerDev.Services
{
    interface IENTIDAD<T>
    {
        ICollection<T> Get();
        void Save(T entidad);
        void Update(T entidad);
        void Delete(T entidad);
        bool Exists(int id);
    }
}
