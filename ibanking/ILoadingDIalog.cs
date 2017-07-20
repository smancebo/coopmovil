using System;
namespace ibanking
{
    [Preserve(AllMembers = true)]
    public interface ILoadingDIalog
    {
        void Show();
        void Hide();
    }


}
