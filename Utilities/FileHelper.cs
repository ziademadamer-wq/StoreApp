using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Utilities
{
    public static class FileHelper
    {
        private static readonly Encoding Utf8NoBOM = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        #region Methods

        #region ListDirectoriesAndFiles
        private static string Normalize(string sPath) =>
           Path.GetFullPath(sPath ?? throw new ArgumentNullException(nameof(sPath)));
        private  static void CheckDirectoryExistence(string fullFilePath)
        {
            var directory = Path.GetDirectoryName(fullFilePath);

            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
        }
        public static bool ListDirectoriesAndFiles(string path)
        {

            var FullPath = Normalize(path);

            if (!Directory.Exists(FullPath)) return false;

           Accessories.PrintMessage("Folders :");

            DirectoryInfo directoryInfo = new DirectoryInfo(FullPath);

            var Folders = directoryInfo.GetDirectories();
            foreach (var folder in Folders)
            {
                Console.WriteLine($"....{folder.Name}....");
            }

            //List Of Files

           Accessories.PrintMessage("Files :");

            var Files = directoryInfo.GetFiles();
            foreach (var file in Files)
            {
                Console.WriteLine($"....{file.Name}....");
            }
            return true;
        }


        #endregion


        public static async Task CreateFile(string path, string content)
        {
            string FullPath = Normalize(path);
            CheckDirectoryExistence(FullPath);

          await  File.WriteAllTextAsync(FullPath, content??string.Empty, Utf8NoBOM);
        }
        public static async Task<bool> TryCreateFile(string path, string content)
        {
            try { await CreateFile(path, content); return true; }
            catch { return false; }
        }
        public static async Task<string> ReadFile(string path)
        {
            string FullPath = Normalize(path);
            if (!File.Exists(FullPath))
            {
                CheckDirectoryExistence(FullPath);
             await   File.WriteAllTextAsync(FullPath, string.Empty, Utf8NoBOM);
                return string.Empty;
            }

            return await File.ReadAllTextAsync(FullPath, Utf8NoBOM);
        }
        public static async Task<string[]> ReadAllLines(string path)
        {
            string FullPath = Normalize(path);
            if (!File.Exists(FullPath))
            {
                CheckDirectoryExistence(FullPath);
                await File.WriteAllTextAsync(FullPath, string.Empty, Utf8NoBOM);
                return new string[1];
            }

            return await File.ReadAllLinesAsync(FullPath, Utf8NoBOM);
        }
        public static async Task<bool> TryReadFile(string path)
        {
            try { await ReadFile(path); return true; }
            catch { return false; }
        }

        public static async Task WriteToFile(string path, string content)
        {
            var FullPath = Normalize(path);
            CheckDirectoryExistence(FullPath);

         await File.WriteAllTextAsync(FullPath, content, Utf8NoBOM);
        }  //writeALLText
        public static bool DeleteFile(string path)
        {
            string FullPath = Normalize(path);
            if (!File.Exists(FullPath)) return false;
            File.Delete(FullPath);
            return true;
        }
        public static async Task<bool> ClearFile(string path)
        {
            string FullPath = Normalize(path);
            if (!File.Exists(FullPath)) return false;
          await  File.WriteAllTextAsync(FullPath, string.Empty);
            return true;
        }
        public static void Update(string path, string content)
        {
            var full = Normalize(path);
            CheckDirectoryExistence(full);
            File.WriteAllText(full, content ?? string.Empty, Utf8NoBOM);
        }

        public static bool CreateDirectoryMenu(string path)
        {
            string FullPath = Normalize(path);

            if (Directory.Exists(FullPath))
                return false;

            Directory.CreateDirectory(FullPath);
            return true;
        }
        public static bool DeleteDirectoryMenu(string path)
        {
            string FullPath = Normalize(path);

            if (!Directory.Exists(FullPath))
                return false;

            Directory.Delete(FullPath);
            return true;

        }


       
        #endregion


        
    }
}
