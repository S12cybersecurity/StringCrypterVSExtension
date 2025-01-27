using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;

namespace StringEncryptionVSExtension
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class XORCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 4129;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("5154be85-9da9-481b-a9a1-b98e92ef54d4");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="XORCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private XORCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static XORCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in XORCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new XORCommand(package, commandService);
        }

        public static string XorEncryptDecrypt(string input, string key)
        {
            char[] output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (char)(input[i] ^ key[i % key.Length]);
            }
            return string.Join(string.Empty, output.Select(c => ((int)c).ToString("X2")));
        }

        public static string GetUserInput(string prompt)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox(prompt, "Encriptación XOR");
            return input;
        }

        private void ShowXORToolWindow(object sender, EventArgs e)
        {
            // Buscar la ToolWindow
            var window = this.package.FindToolWindow(typeof(XORToolWindow), 0, true);
            if (window == null || window.Frame == null)
            {
                throw new NotSupportedException("Tool window not found.");
            }

            // Mostrar la ToolWindow usando el Frame
            var windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }




        private void CommandHandler(object sender, EventArgs e)
        {
            var inputString = GetUserInput("Enter string to encrypt:");
            var key = GetUserInput("Enter encryption key:");

            if (string.IsNullOrEmpty(inputString) || string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Both string and key are required.");
                return;
            }

            var encrypted = XorEncryptDecrypt(inputString, key);
            MessageBox.Show($"Encrypted string: {encrypted}");
        }


        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            var inputString = GetUserInput("Introduce la cadena para encriptar:");
            var key = GetUserInput("Introduce la clave de encriptación:");

            if (string.IsNullOrEmpty(inputString) || string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Se requiere una cadena y una clave.");
                return;
            }

            var encrypted = XorEncryptDecrypt(inputString, key);
            MessageBox.Show($"Cadena encriptada: {encrypted}");
        }
    }
}
