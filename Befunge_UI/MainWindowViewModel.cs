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
        }

        public string ProgramContent
        {
            get
            {
                return this.programContent;
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
                p => true);
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
                    //var testInfo = new ProcessStartInfo("CMD.exe", $"\"{this.path} --noninteractive\"");
                    string argumentString = $"--noninteractive \"{this.ProgramContent}\"";
                    File.WriteAllText("test.txt", this.ProgramContent);
                    var info = new ProcessStartInfo(this.path, argumentString);
                    info.UseShellExecute = true;
                    info.ErrorDialog = true;
                    info.CreateNoWindow = true;
                    
                    var process = Process.Start(info);
                    await this.WaitForProcessExit(process);
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
                process.WaitForExit();
            });

            task.Start();

            return task;
        }
    }
}
