using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Practices.CompositeUI.Configuration;
using Microsoft.Practices.CompositeUI.Services;

namespace WordCAB
{
    public class CustomModuleEnumerator : IModuleEnumerator
    {
        #region Constants
        private const string ModuleName = "CustomModule.dll"; 
        #endregion

        #region IModuleEnumerator Members

        public IModuleInfo[] EnumerateModules()
        {
            List<IModuleInfo> result = new List<IModuleInfo>();

            string path = GetModulePath(ModuleName);
            if ( File.Exists(path) )
                result.Add(new ModuleInfo(ModuleName));
            return result.ToArray();
        }

        #endregion

        #region Private Methods
        private string GetModulePath(string assemblyFile)
        {
            if ( !Path.IsPathRooted(assemblyFile) )
                assemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyFile);

            return assemblyFile;
        } 
        #endregion
    }
}
