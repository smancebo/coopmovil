using System;
using ibanking.Configuracion;
namespace ibanking.Utils
{
    public interface IItemSelectableNavigationPage
    {
        event OnConfigItemSelectedDelegate OnItemSelected;
    }
}
