using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace StringEncryptionVSExtension
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("3539de1d-36ce-4b72-a98d-233931ab3f30")]
    public class XORToolWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XORToolWindow"/> class.
        /// </summary>
        public XORToolWindow() : base(null)
        {
            this.Caption = "XORToolWindow";
            this.Content = new XORToolWindowControl();
        }
    }
}
