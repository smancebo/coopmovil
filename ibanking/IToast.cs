using System;
namespace ibanking
{
    public interface IToast
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
