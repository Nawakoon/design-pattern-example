// inspired by instragram

namespace Pattern.Observer
{
    public class User
    {
        public string Name { get; set; }
        public List<User> Following { get; set; } = new List<User>();
        public List<User> Followers { get; set; } = new List<User>();
        public User(string name)
        {
            Name = name;
        }
        public void Post(string message)
        {
            Console.WriteLine($"{Name} posted: {message}");
            NotifyFollowers(message);
        }
        public void Follow(User user)
        {
            Following.Add(user);
            user.Followers.Add(this);
            Console.WriteLine($"{Name} followed {user.Name}");
        }
        public void Unfollow(User user)
        {
            Following.Remove(user);
            user.Followers.Remove(this);
            Console.WriteLine($"{Name} unfollowed {user.Name}");
        }
        private void NotifyFollowers(string message)
        {
            foreach (var follower in Followers)
            {
                follower.Update(message);
            }
        }
        private void Update(string message)
        {
            Console.WriteLine($"{Name} received: {message}");
        }
    }

    public class Observer : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nObserver example\n");

            var BuaThong = new User("BuaThong");
            var Pinn = new User("Pinn");

            BuaThong.Follow(Pinn);
            Pinn.Post("Hello World");
            
            BuaThong.Unfollow(Pinn);
            Pinn.Post("Hello World");
        }
    }
}