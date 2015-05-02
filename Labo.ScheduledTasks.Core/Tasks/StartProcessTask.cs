namespace Labo.ScheduledTasks.Core.Tasks
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;

    [BuiltInTask]
    public sealed class StartProcessTask : ITask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible"), Serializable]
        public sealed class Configuration
        {
            public string FileName { get; set; }

            public string Arguments { get; set; }
        }

        private readonly Process m_Process;

        public StartProcessTask(string fileName, string arguments = null)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            if (!File.Exists(fileName))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "'{0}' file does not exists.", fileName));
            }

            if (!Path.GetFileName(fileName).Equals(".exe", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "'{0}' file is not an exe.", fileName));
            }

            m_Process = new Process();
            m_Process.StartInfo.UseShellExecute = false;
            m_Process.StartInfo.FileName = fileName;
            m_Process.StartInfo.CreateNoWindow = true;

            if (!string.IsNullOrWhiteSpace(arguments))
            {
                m_Process.StartInfo.Arguments = arguments;
            }
        }

        public void Run()
        {
            m_Process.Start();
        }

        public void Dispose()
        {
            m_Process.Dispose();
        }
    }
}
