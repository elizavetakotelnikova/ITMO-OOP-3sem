using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public interface IImplementFileSystem
{
    public void Connect(ExecutionContext context, Mode? mode, string address);

    public void Disconnect(ExecutionContext context);

    public void CopyFile(ExecutionContext context, string sourcePath, string destinationPath);

    public void DeleteFile(ExecutionContext context, string filePath);

    public void MoveFile(ExecutionContext context, string sourcePath, string destinationPath);

    public void RenameFile(ExecutionContext context, string filePath, string newName);

    public void ShowFile(ExecutionContext context, string path, ShowMode? mode);

    public void GoToCommand(ExecutionContext context, string path);

    public void PrintTreeList(ExecutionContext context, int depth, TreeListCommandParameters parameters);

    public void PrintDirectoryTree(string pathToRootDirectory, int depth, TreeListCommandParameters parameters);

    public void PrintCurrentDirectory(DirectoryInfo directory, int currentDepth, int depth, TreeListCommandParameters parameters);
}