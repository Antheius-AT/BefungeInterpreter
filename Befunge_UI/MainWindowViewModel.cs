using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace Befunge_UI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string programContent;
        private string path;

        public MainWindowViewModel()
        {
            this.PathToInterpreter = "undefined";
            this.ProgramContent = "\"***reterpretni ym ot emocleW***\"      v\r\nSimple interpreter by Gregor Faiman.\r\n@,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,      <";
        }

        public string ProgramContent
        {
            get
            {
                return this.programContent.Replace(@"\""", "\"");
            }

            set
            {
                string transformed = value;

                var indexes = transformed.AllIndexesOf('"');

                for (int i = 0; i < indexes.Count; i++)
                {
                    transformed = transformed.Insert(indexes[i] + i, "\\");
                }

                this.programContent = transformed;
            }
        }

        public ICommand LoadInputCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    throw new NotImplementedException();
                },
                p => false);
            }
        }

        public ICommand SpecifyInterpreterCommand
        {
            get
            {
                return new RelayCommand(p =>
                {
                    var dialog = new OpenFileDialog();
                    dialog.Filter = "Executable Files | *.exe";
                    dialog.CheckFileExists = true;
                    dialog.CheckPathExists = true;
                    dialog.ReadOnlyChecked = true;

                    if (dialog.ShowDialog() == true)
                    {
                        this.PathToInterpreter = dialog.FileName;
                    }
                },
                p => true);
            }
        }

        /// <summary>
        /// Runs the code in the UI window in a separate process in a way that does not block the UI.
        /// </summary>
        public ICommand RunCodeCommand
        {
            get
            {
                return new RelayCommand(async p =>
                {
                    string argumentString = $@"--noninteractive ""{this.programContent}""";
                    var info = new ProcessStartInfo(this.path, argumentString);

                    try
                    {
                        var process = Process.Start(info);
                        await this.WaitForProcessExit(process);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Process could not be started. The following error occurred: {e.Message}");
                    }
                },
                p => true);
            }
        }

        /// <summary>
        /// Gets the path to the currently selected befunge interpreter.
        /// </summary>
        public string PathToInterpreter
        {
            get
            {
                return this.path.Split(Path.DirectorySeparatorChar).Last();
            }

            private set
            {
                this.path = value;
                this.RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName]string propertyPath = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyPath));
        }

        /// <summary>
        /// Waits for an interpreter process to exit, without blocking the UI.
        /// </summary>
        /// <param name="process">The process to wait for.</param>
        /// <returns>The task object waiting for the process.</returns>
        private Task WaitForProcessExit(Process process)
        {
            var task = new Task(() =>
            {
                if (!process.HasExited)
                    process.WaitForExit();
            });

            task.Start();

            return task;
        }
    }
}
