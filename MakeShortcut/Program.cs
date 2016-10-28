using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using IWshRuntimeLibrary;
class Sample
{
    public static void Main(String[] args)
    {

        if (args.Length != 3)
        {
            System.Console.WriteLine("Invalid command Line options");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine("Creates a shortcut on the all users desktop to a desired location");
            System.Console.WriteLine("");
            System.Console.WriteLine("Usage MakeShortcut.exe <application or URL> <Name of shortcut> <location of Icon to use>");
            System.Console.WriteLine("");
            System.Console.WriteLine("Example:");
            System.Console.WriteLine("");
            System.Console.WriteLine("to create a shortcut to notepad.exe");
            System.Console.WriteLine("");
            System.Console.WriteLine(@"MakeShortcut.exe c:\windows\notepad Notepad c:\Windows\notepad.exe");
            System.Console.WriteLine("");
            System.Console.WriteLine("to create a shortcut to CNN.com called CNN using the IE icon");
            System.Console.WriteLine("MakeShortcut.exe http:\\cnn.com CNN " + "\"C:\\Program Files(x86)\\Internet Explorer\\iexplore.exe\"");
            System.Console.WriteLine("");
            System.Console.WriteLine("NOTE: If you want to use spaces in the names you must put the the string in quotes");
            System.Environment.Exit(1);
        }

        WshShell Shell = new WshShell();
        IWshShortcut MyDesktopShortcut;
        MyDesktopShortcut = (IWshShortcut)Shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + "\\" + args[1] + ".lnk");
        MyDesktopShortcut.TargetPath = args[0];
        MyDesktopShortcut.IconLocation = args[2];
        MyDesktopShortcut.Description = args[1] + MyDesktopShortcut.TargetPath;
        MyDesktopShortcut.Save();
        System.Environment.Exit(0);
    }
}