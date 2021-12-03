using System;
using System.IO;
using System.Reflection;

namespace Osb.Core.Infrastructure.Data.Migrations.Utils
{
    public static class ScriptsUtil
    {
        private static readonly string _createSuffix = "Create";
        private static readonly string _dropSuffix = "Drop";
        private static string _ScriptsDirectoryPath
        {
            get
            {
                string path = Assembly.GetExecutingAssembly().Location;
                string directory = Path.GetDirectoryName(path);
                string scriptsDirectory = Path.Combine(directory, "Scripts");
                return scriptsDirectory;
            }
        }

        public static string GetCreateProcedureFilePath(string procedureName)
        {
            string filePath = _GetFullProcedureFilePath(procedureName, _createSuffix);
            return filePath;
        }

        public static string GetDropProcedureFilePath(string procedureName)
        {
            string filePath = _GetFullProcedureFilePath(procedureName, _dropSuffix);
            return filePath;
        }

        private static string _GetFullProcedureFilePath(string procedureName, string suffix)
        {
            string fileName = $"{procedureName}.{suffix}.sql";
            string filePath = Path.Combine(_ScriptsDirectoryPath, fileName);
            return filePath;
        }
    }
}