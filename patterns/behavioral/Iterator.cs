// inspired by SQL

namespace Pattern.Iterator
{
    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    public interface IContainer
    {
        IIterator GetIterator(string filter);
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UserCollection : IContainer
    {
        private List<User> _users;

        public UserCollection()
        {
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }

        public IIterator GetIterator(string filter )
        {
            Console.WriteLine($"\nuse {filter} iterator");

            switch (filter)
            {
                case "create":
                    return new CreateIterator(this);
                case "random":
                    return new RandomIterator(this);
                default:
                    return new CreateIterator(this);
            }
        }

        private class CreateIterator : IIterator
        {
            private UserCollection _collection;
            private int _index;

            public CreateIterator(UserCollection collection)
            {
                _collection = collection;
                _index = 0;
            }

            public bool HasNext()
            {
                return _index < _collection._users.Count;
            }

            public object Next()
            {
                return _collection._users[_index++];
            }
        }

    private class RandomIterator : IIterator
    {
        private UserCollection _userCollection;
        private int _totalUsers;
        private int _countUsers;

        public RandomIterator(UserCollection userCollection)
        {
            _userCollection = userCollection;
            _totalUsers = _userCollection._users.Count;
        }

        public bool HasNext()
        {
            return _countUsers < _totalUsers;
        }

        public object Next()
        {
            Random random = new Random();
            int index = random.Next(0, _userCollection._users.Count - 1);
            _countUsers++;
            User user = _userCollection._users[index];
            _userCollection._users.RemoveAt(index);
            return user;
        }
    }
    }

    public class Iterator : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nIterator example\n");

            UserCollection userCollection = new UserCollection();
            userCollection.AddUser(new User { Name = "John", Email = "mail 1" });
            userCollection.AddUser(new User { Name = "Jane", Email = "mail 2" });
            userCollection.AddUser(new User { Name = "Joe", Email = "mail 3" });

            IIterator iterator = userCollection.GetIterator("create");
            while (iterator.HasNext())
            {
                User user = (User)iterator.Next();
                Console.WriteLine($"User: {user.Name}, Email: {user.Email}");
            }

            iterator = userCollection.GetIterator("random");
            while (iterator.HasNext())
            {
                User user = (User)iterator.Next();
                Console.WriteLine($"User: {user.Name}, Email: {user.Email}");
            }
        }
    }
}