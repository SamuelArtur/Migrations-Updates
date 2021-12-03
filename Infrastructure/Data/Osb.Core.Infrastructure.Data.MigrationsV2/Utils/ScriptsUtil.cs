using System;
using System.IO;
using System.Reflection;

namespace Osb.Core.Infrastructure.Data.MigrationsV2.Utils
{
    public static class ScriptsUtil
    {
        private static readonly string _createSuffix = "Create";
        private static readonly string _dropSuffix = "Drop";
        private static string _ScriptsDirectoryPath
        {
            get
            {
                string path = Environment.CurrentDirectory;
                string directory = Path.GetFullPath(path);
                string scriptsDirectory = Path.Combine(directory, "Scripts");
                return scriptsDirectory;
            }

        }

        public static string GetCreateProcedureFilePath(string procedureName,string namePathScripts)
        {
            string filePath = _GetFullProcedureFilePath(procedureName, _createSuffix,namePathScripts);
            return filePath;
        }

        public static string GetDropProcedureFilePath(string procedureName,string namePathScripts)
        {
            string filePath = _GetFullProcedureFilePath(procedureName, _dropSuffix,namePathScripts);
            return filePath;
        }

        private static string _GetFullProcedureFilePath(string procedureName, string suffix,string namePathScripts)
        {
            string fileName = $"{procedureName}.{suffix}.sql";
            string filePath = Path.Combine(Path.Combine(_ScriptsDirectoryPath,namePathScripts), fileName);
            return filePath;
        }
    }
}