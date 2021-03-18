using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.inteface
{
    public interface BaseInterface<EntityName>
    {
        void Add(EntityName obj);
        void Edit(EntityName obj, int? id);
        void Delete(int? id);
        EntityName GetSingleEntity(int? id);
        DataTable GetEntitytList();
    }
}
