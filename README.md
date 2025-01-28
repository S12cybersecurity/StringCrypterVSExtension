# StringCrypterVSExtension

**StringCrypterVSExtension** is a Visual Studio extension that provides a simple XOR-based encryption and decryption tool. It allows developers to encrypt strings using a key and generate C++ code to decrypt the encrypted string. This extension is designed to integrate seamlessly into Visual Studio, making string manipulation easier.

![stringcryptervsexte2](https://github.com/user-attachments/assets/75a4f1ce-523c-4805-967f-230e984600da)


## Features

- Encrypts strings using XOR encryption with a provided key.
- Displays the encrypted string both in plain text and in hexadecimal format.
- Automatically generates C++ code to decrypt the encrypted string with the given key.
- Easily copy the decryption code for use in C++ projects.

## Installation

1. Clone this repository to your local machine or download it as a ZIP file.
2. Open the project in Visual Studio.
3. Build the project.
4. Install the extension in Visual Studio.

You can also find the extension in the Visual Studio extensions list [here](https://marketplace.visualstudio.com/items?itemName=0x12DarkDevelopment.stringcrypter).

## Usage

1. Open the `StringCrypterVSExtension` tool window in Visual Studio.
2. Enter the string you wish to encrypt in the input text box.
3. Enter the encryption key in the key text box.
4. Click the **Encrypt** button.
5. The encrypted string will be shown in both plain text and hexadecimal format.
6. The corresponding C++ decryption code will be generated and displayed in the code output section.

### Example

- **Plain Text**: `HelloWorld`
- **Key**: `mykey`
- **Encrypted**: `ƔƨƧƪƔƨ`
- **Hexadecimal**: `\x1A\x2C\x31\x5A\x1A\x2C`

The generated C++ decryption code would look like this:

```cpp
std::string XorEncryptDecrypt(const std::string& input, const std::string& key) {
    std::string output = input;
    for (size_t i = 0; i < input.length(); ++i) {
        output[i] = input[i] ^ key[i % key.length()];
    }
    return output;
}
std::string key = "mykey";
std::string decrypted = XorEncryptDecrypt(encryptedString, key);
