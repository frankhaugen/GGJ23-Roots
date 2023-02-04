
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DirectoryManager : MonoBehaviour
{
    [SerializeField] private string rootDirectory;

    private void Start()
    {
        rootDirectory = Application.dataPath;
        Debug.Log(rootDirectory);
    }
    
    public IEnumerable<DirectoryInfo>   GetDirectories(DirectoryInfo directory) => directory.GetDirectories();
    
    public DirectoryInfo GetRootDirectory() => new DirectoryInfo(Path.GetPathRoot(Directory.GetCurrentDirectory()));
}