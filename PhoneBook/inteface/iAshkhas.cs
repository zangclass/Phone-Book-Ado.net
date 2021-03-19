using PhoneBook.Entity;
using System.Data;

namespace PhoneBook.inteface
{
    public interface iAshkhas : BaseInterface<AshkhasEntity>
    {
        DataTable GetOstan();
        DataTable Getshar(int IdOstan);
        DataTable GetShakhs(int? Id);
    }
}
