// inspired by Gather

namespace Pattern.Mediator
{
    public class User
    {
        public string Name { get; set; }
        public ChatRoom ChatRoom { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public void JoinChatRoom(ChatRoom chatRoom)
        {
            ChatRoom = chatRoom;
            ChatRoom.AddUser(this);
        }

        public void SendAllMessage(string message)
        {
            ChatRoom.SendMessage(this, message);
        }

        public void SendPrivateMessage(User receiver, string message)
        {
            ChatRoom.SendPrivateMessage(this, receiver, message);
        }

        public void ReceiveMessage(User sender, string message)
        {
            Console.WriteLine($"{Name} received message from {sender.Name}: {message}");
        }
    }

    public class ChatRoom
    {
        private List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(User sender, string message)
        {
            Console.WriteLine($"{sender.Name} (to all): {message}");
            foreach (var user in _users) {
                if (user != sender) {
                    user.ReceiveMessage(sender, message);
                }
            }
            Console.WriteLine();
        }

        public void SendPrivateMessage(User sender, User receiver, string message)
        {
            Console.WriteLine($"{sender.Name} (to {receiver.Name}): {message}");
            receiver.ReceiveMessage(sender, message);
            Console.WriteLine();
        }
    }

    public class Mediator : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nMediator Example\n");

            var mineCraftRoom = new ChatRoom();
            var Jack = new User("Jack");
            var Dream = new User("Dream");
            var George = new User("George");

            Jack.JoinChatRoom(mineCraftRoom);
            Dream.JoinChatRoom(mineCraftRoom);
            George.JoinChatRoom(mineCraftRoom);

            Jack.SendAllMessage("Hello everyone!");
            Dream.SendPrivateMessage(Jack, "Hi Jack!");
        }
    }
}