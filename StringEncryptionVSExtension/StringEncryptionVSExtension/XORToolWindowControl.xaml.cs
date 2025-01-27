using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace StringEncryptionVSExtension
{
    /// <summary>
    /// Interaction logic for XORToolWindowControl.
    /// </summary>
    public partial class XORToolWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XORToolWindowControl"/> class.
        /// </summary>
        public XORToolWindowControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "XORToolWindow");
        }

        private void GenerateDecryptionCode(string key)
        {
         
           string cplusplusCode = @"std::string XorEncryptDecrypt(const std::string& input, const std::string& key) {
    std::string output = input;
    for (size_t i = 0; i < input.length(); ++i) {
        output[i] = input[i] ^ key[i % key.length()];
    }
    return output;
}
std::string key = ""{0}"";
std::string decrypted = XorEncryptDecrypt(encryptedString, key);";

            key = key.Replace("\"", "\\\"");

            cplusplusCode = cplusplusCode.Replace("{0}", key);

            string encryptedStringHex = XorEncryptDecryptinHex(plainTextBox.Text);

            cplusplusCode = cplusplusCode.Replace("<ENCRYPTED_STRING>", encryptedStringHex);

            code.AppendText(cplusplusCode);
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        string XorEncryptDecryptinHex(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            else
            {
                StringBuilder hexOutput = new StringBuilder();
                foreach (char c in input)
                {
                    hexOutput.Append(@"\x");
                    hexOutput.Append(((int)c).ToString("X2")); // Convierte cada carácter a su representación hexadecimal.
                }
                return hexOutput.ToString();
            }
        }

        string XorEncryptDecrypt(string input, string key)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            } else
            {
                char[] output = new char[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    output[i] = (char)(input[i] ^ key[i % key.Length]);
                }
                return string.Join(string.Empty, output);
            }
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string stringToEncrpyt = stringEnc.Text;
            string key = keyBox.Text;
            string encrypted = XorEncryptDecrypt(stringToEncrpyt, key);
            plainTextBox.Text = encrypted;
            hexResult.Text = XorEncryptDecryptinHex(encrypted);
            GenerateDecryptionCode(key);
        }
    }
}