// inspired by git

using Pattern.Composite;

namespace Pattern.Memento
{
    class Repository
    {
        private List<Composite.File> _trackFiles = new List<Composite.File>();

        public Repository()
        {
            Console.WriteLine("\n$ git init");
        }

        public void MakeChange(Composite.File file, string data)
        {
            file.Write(data);
            _trackFiles.Add(file);
            // Console.WriteLine($"file {file.ToString()} edited");
            Console.WriteLine($"$ git add {file.ToString()}");
        }

        public ICommit MakeCommit(string message)
        {
            return new Commit(message, _trackFiles);
        }

        public void Restore(ICommit commit)
        {
            if (!(commit is Commit))
            {
                throw new Exception("Unknow commit " + commit.ToString());
            }

            _trackFiles = commit.GetState();
        }
    }

    public interface ICommit
    {
        string GetName();

        List<Composite.File> GetState();

        DateTime GetDate();
    }

    // memento
    class Commit : ICommit
    {
        private string _message;
        private List<Composite.File> _trackFiles;
        private DateTime _date;

        public Commit(string message, List<Composite.File> files)
        {
            _message = message;
            _trackFiles = files;
            _date = DateTime.Now;
        }

        public List<Composite.File> GetState()
        {
            return _trackFiles;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public string GetName()
        {
            return $"{_date} {_message}";
        }
    }

    // caretaker
    class Git
    {
        private List<ICommit> _commits = new List<ICommit>();
        private Repository? _repo = null;

        public void Init()
        {
            Repository repo = new Repository();
            _repo = repo;
        }

        public void Add(Composite.File file, string data)
        {
            if (_repo == null) {
                Console.WriteLine("no git repository found, please run $ git init");
                return;
            }
            _repo.MakeChange(file, data);
        }

        public void CommitCmd(string message)
        {
            if (_repo == null) {
                Console.WriteLine("no git repository found, please run $ git init");
                return;
            }
            Console.WriteLine($"$ git commit -m {message}\n");
            _commits.Add(_repo.MakeCommit(message));
        }

        public void ResetHardHead()
        {
            if (_repo == null) {
                Console.WriteLine("no git repository found, please run $ git init");
                return;
            }
            if (_commits.Count == 0)
            {
                return;
            }

            var memento = _commits.Last();
            _commits.Remove(memento);

            Console.WriteLine("\n$ git reset --hard HEAD^");

            try
            {
                _repo.Restore(memento);
            }
            catch (Exception)
            {
                ResetHardHead();
            }
        }

        public void Log()
        {
            if (_repo == null) {
                Console.WriteLine("no git repository found, please run $ git init");
                return;
            }
            Console.WriteLine("\n$ git log");

            foreach (var commit in _commits)
            {
                Console.WriteLine(commit.GetName());
            }

            Console.WriteLine();
        }
    }

    public class Memento : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nMemento example");

            Git git = new Git();

            Composite.File file1 = new Composite.File("file1.py");
            Composite.File file2 = new Composite.File("file2.json");
            
            git.Init();

            git.Add(file1, "print('hello world')");
            git.CommitCmd("feat: add simple python file");

            git.Add(file1, "print('hello world')\n x = 1");
            git.Add(file2, "{ data: 1}");
            git.CommitCmd("chore: I love json");

            git.Add(file1, "print('hello girl')\n x = 2");

            git.Log();

            git.ResetHardHead();
            git.Log();
            
            git.ResetHardHead();
            git.Log();
        }
    }
}