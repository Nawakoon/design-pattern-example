// inspired by vscode

namespace Pattern.Command
{   
    public class VscodeEditor
    {
        public bool IsExtensionSidebarVisible { get; set; }
        public string SelectingExtension { get; set; }
        public List<Button> Buttons { get; set; }
        public List<Shortcut> Shortcuts { get; set; }

        public VscodeEditor()
        {
            IsExtensionSidebarVisible = false;
            SelectingExtension = "Explorer";
            Buttons = new List<Button>();
            Shortcuts = new List<Shortcut>();
        }

        public void ClickButton(string buttonName)
        {
            var button = Buttons.FirstOrDefault(b => b.GetName() == buttonName);
            if (button != null) {
                button.Click();
            } else {
                Console.WriteLine("Button not found");
            }
        }

        public void PressShortcut(string key)
        {
            Console.WriteLine($"Shortcut {key} pressed");
            var shortcut = Shortcuts.FirstOrDefault(s => s.GetKey() == key);
            if (shortcut != null) {
                shortcut.Press();
            } else {
                Console.WriteLine("Shortcut not found");
            }
        }

        public void AddButton(Button button)
        {
            Buttons.Add(button);
        }

        public void AddShortcut(Shortcut shortcut)
        {
            Shortcuts.Add(shortcut);
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class ToggleExplorerCmd : ICommand
    {
        private VscodeEditor _editor;

        public ToggleExplorerCmd(VscodeEditor editor)
        {
            _editor = editor;
        }

        public void Execute()
        {
            _editor.IsExtensionSidebarVisible = !_editor.IsExtensionSidebarVisible;
            _editor.SelectingExtension = "Explorer";
        }
    }

    public class Button
    {
        private string _name;
        private ICommand _command;

        public Button(string name, ICommand command)
        {
            _name = name;
            _command = command;
        }

        public string GetName()
        {
            return _name;
        }

        public void Click()
        {
            Console.WriteLine($"Button {_name} clicked");
            _command.Execute();
        }
    }

    public class Shortcut
    {
        private string _name;
        private string _key;
        private ICommand _command;

        public Shortcut(string name, string key, ICommand command)
        {
            _name = name;
            _key = key;
            _command = command;
        }

        public string GetKey()
        {
            return _key;
        }

        public void Press()
        {
            Console.WriteLine($"Shortcut {_name} pressed");
            _command.Execute();
        }
    }

    public class Command : ExamplePattern
    {
        public void CheckExtensionSidebar(VscodeEditor editor)
        {
            Console.WriteLine("Is extension sidebar open: " + editor.IsExtensionSidebarVisible);
            Console.WriteLine("Current extension: " + editor.SelectingExtension + "\n");
        }

        public void RunExample()
        {
            Console.WriteLine("\nCommand example\n");

            var editor = new VscodeEditor();
            var toggleExplorerCmd = new ToggleExplorerCmd(editor);
            
            var toggleExplorerButton = new Button("toggle explorer", toggleExplorerCmd);
            var toggleExplorerKey = new Shortcut("toggle explorer", "cmd + b", toggleExplorerCmd);
            
            editor.AddButton(toggleExplorerButton);
            editor.AddShortcut(toggleExplorerKey);

            CheckExtensionSidebar(editor);
            
            editor.ClickButton("toggle explorer");
            CheckExtensionSidebar(editor);

            editor.PressShortcut("cmd + b");
            CheckExtensionSidebar(editor);
        }
    }
}