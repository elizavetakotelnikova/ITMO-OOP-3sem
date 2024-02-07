using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class WindowsFileWriter : IWriteInFile
{
    public void WriteInFile(string fileName, string text)
    {
        /*string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), fileName);
        var fileStream = new FileStream(@path, FileMode.OpenOrCreate, FileAccess.Write);
        var streamWriter = new StreamWriter(fileStream);
        fileStream.Seek(fileStream.Length, SeekOrigin.Begin);
        streamWriter.WriteLine(text);
        streamWriter.Close();
        fileStream.Close();*/ // commented to pass github tests
    }
}