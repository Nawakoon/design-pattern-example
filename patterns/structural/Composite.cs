// inspired by Linux

namespace Pattern.Composite
{
    public class File
    {
        private string _name;
        private string _data;

        public File(string name)
        {
            _name = name;
            _data = "";
        }

        public int GetSize()
        {
            return _data.Length * 8;
        }

        public void Write(string data)
        {
            _data = data;
        }

        public override string ToString()
        {
            return _name;
        }
    }

    public class Directory
    {
        private string _name;
        private Directory _parentDir;
        public List<Directory> _directories;
        public List<File> _files;

        public Directory(string name, Directory parentDir = null)
        {
            _name = name;
            _directories = new List<Directory>();
            _files = new List<File>();
            _parentDir = parentDir;
        }

        public void AddFile(File file)
        {
            _files.Add(file);
        }

        public void AddDirectory(Directory directory)
        {
            _directories.Add(directory);
        }

        public int GetSize()
        {
            int size = 0;
            foreach (var file in _files)
            {
                size += file.GetSize();
            }
            foreach (var directory in _directories)
            {
                size += directory.GetSize();
            }
            return size;
        }

        public Directory GetParent()
        {
            return _parentDir;
        }

        public override string ToString()
        {
            return _name;
        }
    }

    public class MyOS
    {
        private Directory _currentDir;

        public MyOS()
        {
            _currentDir = new Directory("root");
        }

        public void Cmd(string command)
        {
            Console.WriteLine($"$ {command}");
            if (command == "ls")
            {
                foreach (var file in _currentDir._files)
                {
                    Console.WriteLine(file);
                }
                foreach (var directory in _currentDir._directories)
                {
                    Console.WriteLine($"/{directory}");
                }
            }
            else if (
                command.Length > 5 &&
                command.Substring(0, 5) == "mkdir"
            )
            {
                var directoryName = command.Substring(6);
                _currentDir.AddDirectory(new Directory(directoryName, _currentDir));
            }
            else if (
                command.Length > 5 &&
                command.Substring(0, 5) == "touch"
            )
            {
                var fileName = command.Substring(6);
                var newFile = new File(fileName);
                newFile.Write("hahaha");
                _currentDir.AddFile(newFile);

            }
            else if (command == "du")
            {
                Console.WriteLine(_currentDir.GetSize());
            }
            else if (
                command.Length > 2 &&
                command.Substring(0, 2) == "cd"
            )
            {
                if (command == "cd ..")
                {
                    _currentDir = _currentDir.GetParent();
                }
                var directoryName = command.Substring(3);
                foreach (var directory in _currentDir._directories)
                {
                    if (directory.ToString() == directoryName)
                    {
                        _currentDir = directory;
                    }
                }
            }
        }
    }

    public class Composite : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nComposite example\n");
            MyOS os = new MyOS();
            os.Cmd("mkdir home");
            os.Cmd("touch file1.py");
            os.Cmd("touch file2.cs");
            os.Cmd("du");
            os.Cmd("ls");
            os.Cmd("cd home");
            os.Cmd("touch file3.js");
            os.Cmd("ls");
            os.Cmd("du");
            os.Cmd("cd ..");
            os.Cmd("ls");
            os.Cmd("du");

            Console.WriteLine("\nhell yeah! mother fucker I write the file system\n");
        }
    }
}