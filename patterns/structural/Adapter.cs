// inspired by docker

namespace Pattern.Adapter
{
    public interface LinuxFunctions
    {
        void RunBash(string script);
    }

    public class MacOS : LinuxFunctions
    {
        public void RunBash(string script)
        {
            Console.WriteLine($"Running bash script: {script}");
        }
    }

    public class Windows
    {
        public void RunPowerShell(string script)
        {
            Console.WriteLine($"Running PowerShell script: {script}");
        }
    }

    public class DockerForWindows : LinuxFunctions
    {
        private Windows _windows;

        public DockerForWindows(Windows windows)
        {
            _windows = windows;
        }

        public void RunBash(string script)
        {
            Console.WriteLine($"Running bash script: {script}");
        }
    }

    public class Adapter : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nAdapter example\n");

            var PC1 = new MacOS();
            var PC2 = new Windows();
            var PC2_VirtualMachine = new DockerForWindows(PC2);

            PC1.RunBash("echo 'Hello, world!' from MacOS");
            PC2_VirtualMachine.RunBash("echo 'Hello, world!' from Windows");
        }
    }
}