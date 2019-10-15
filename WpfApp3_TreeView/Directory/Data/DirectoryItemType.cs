using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3_TreeView
{

    /// <summary>
    /// The type of a directory item
    /// </summary>
    public enum DirectoryItemType
    {
        /// <summary>
        /// A logical drive
        /// </summary>
        Drive,
        /// <summary>
        /// a physical file
        /// </summary>
        File,
        /// <summary>
        /// A folder
        /// </summary>
        Folder
    }
}
