# Sa7ka

**Sa7ka** is a simple Windows application that allows you to use hotkeys (Ctrl + F2 or F3) to capture the text that the user is typing in a wrong language selected (and another language wanted) from AR and EN only.
and convert it to the correct language depending on the captured hotkey. It’s designed to make it easier to fix typos and annoying required changes for language when typing some stuff.

## Features

- **Global Hotkey Support**: Use hotkeys (like Ctrl+F2) to capture clipboard content from anywhere.
- **Clipboard Text Detection**: Automatically detect text copied to your clipboard and display it.
- **System Tray Integration**: Minimize the app to the system tray and easily interact with it via balloon notifications.
- **Arabic To English**: Ctrl+F3 will change the typed characters from Arabic language to Englsih 
- **English To Arabic**: Ctrl+F2 will change the typed characters from English language to Arabic
- **Automatically language change**: After killing the Sa7ka (Fix the typo), the app will automatically change the keyboard language to the targeted language to let you complete typing without any other needed actions.
- **Startup abiliity**: Can be added to startup path with one click so the app will run when you start your PC up. 

## Requirements

- Windows 10 or 11 (Tested on both)
- .NET 6.0 or higher (For building from source)

## Installation

1. **Download the ZIP** containing the Release build from the [Releases section](https://github.com/MuntajabAlAni/Sa7ka/releases/download/v1.0/Sa7ka-v1.0.zip).
2. **Extract the ZIP** to a folder of your choice.
3. **Run the application** by double-clicking on `Sa7kaWin.exe`.
4. The app will start running in the system tray. Use the hotkey `Ctrl+F2` to test it!

## Building from Source

If you want to build the app yourself:
1. Clone this repository.
2. Open the solution in **Visual Studio** (VS 2022 or higher).
3. Set the **build configuration** to **Release**.
4. Build the project.
5. After building, you can find the executable in the `bin\Release` folder.

## Contributing

Feel free to fork this repository and submit issues or pull requests with improvements, bug fixes, or new features!

## License

This project is open-source and available under the MIT License.
