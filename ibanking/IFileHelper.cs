using System;
namespace ibanking
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
