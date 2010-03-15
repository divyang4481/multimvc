using System.Collections.Generic;
using System.IO;

namespace BA.MultiMVC.Framework.Core
{
    public class Extensions
    {
        private readonly string _rootPath;
        public Extensions(string rootPath)
        {
            _rootPath = rootPath;
        }

        public IList<DirectoryInfo> GetBinDirectories()
        {
            var dirInfo = new DirectoryInfo(_rootPath);
            var subDirs = dirInfo.GetDirectories();
            var ret = new List<DirectoryInfo>();
            foreach (var subDir in subDirs)
            {
                if (subDir.GetDirectories("bin").GetLength(0) == 1)
                {
                    ret.Add(subDir.GetDirectories("bin")[0]);
                }
            }
            return ret;
        }
    }
}