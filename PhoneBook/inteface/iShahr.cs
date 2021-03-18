using PhoneBook.Entity;
using System.Data;

namespace PhoneBook.inteface
{
    interface iShahr : BaseInterface<ShahrEntity>
    {
        DataTable GetOstanList();
    }
}
