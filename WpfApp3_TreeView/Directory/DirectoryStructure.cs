using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3_TreeView
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get every logical drive on the machine
            return Directory.GetLogicalDrives().Select(drive=> new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Gets directories top-level content
        /// </summary>
        /// <param name="fullPath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            //Create empty list
            var items = new List<DirectoryItem>();

            #region Get Folders

            //try and get directories ; ignore issues
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }

            #endregion

            #region Get Files


            //try and get files ; ignore issues
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(file=> new DirectoryItem { FullPath=file, Type=DirectoryItemType.File }));
            }
            catch { }
            #endregion

            return items;
        }

        #region Helpers

        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            //If we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            //Normalize backslashes
            var normalizedPath = path.Replace('/', '\\');

            //find the last backhlash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            //If we dont have a backslash, return full path
            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex + 1);
        }
        #endregion

    }
}
