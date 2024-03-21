using chatAppWebApi.Models;

namespace chatAppWebApi.Repositories
{
    //Mock Repository created for initial testing
    public class ChatroomRepository : IChatroomRepository
    {
        // Repository methods 
        public async Task<IEnumerable<MessageModel>> GetAllMessages()
        {
            // establish db connection async
            return _messages;
        }

        public async Task<MessageModel> CreateMessage(MessageModel newMessage)
        {
            // establish db connection async

            _messages.Add(newMessage);

            return newMessage;
        }
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            // establish db connection async

            return _users;
        }
        public async Task<UserModel> CreateUser(UserModel newUser)
        {
            // establish db connection async

            _users.Add(newUser);

            return newUser;
        }
        public async Task<UserModel?> GetUser(int id)
        {
            // establish db connection async

            var matchingUser = _users.SingleOrDefault(user => user.Id == id);

            return matchingUser;
        }
        public int IncrementMessageId()
        {
            int currentId = _messages.Max(message => message.Id);

            int newMessageId = currentId + 1;

            return newMessageId;
        }
        public int IncrementUserId()
        {
            int currentId = _users.Max(message => message.Id);

            int newUserId = currentId + 1;

            return newUserId;
        }

        //Data Store
        public static List<UserModel> _users = new List<UserModel>()
            {
                new UserModel()
                {
                    Id = 1,
                    UserName = "User A",
                },
                new UserModel()
                {
                    Id = 2,
                    UserName = "User B",
                },
                 new UserModel()
                {
                    Id = 3,
                    UserName = "User C",
                },
                 new UserModel()
                {
                    Id = 4,
                    UserName = "User D"
                }
            };

        public static List<MessageModel> _messages = new List<MessageModel>()
            {
                new MessageModel()
                {
                    Id = 1,
                    UserName = "User A",
                    Message = "Greetings everyone!"
                },
                new MessageModel()
                {
                    Id = 2,
                    UserName = "User B",
                    Message = "Welcome User A!"
                },
                new MessageModel()
                {
                    Id = 3,
                    UserName = "User B",
                    Message = "I would like to visit the beach soon"
                },
                new MessageModel()
                {
                    Id = 4,
                    UserName = "User B",
                    Message = "And I won't forget to bring sunscreen"
                },
                 new MessageModel()
                {
                    Id = 5,
                    UserName = "User D",
                    Message = "That's agreed User B"
                },
                new MessageModel()
                {
                    Id = 6,
                    UserName = "User C",
                    Message = "I am looking forward to a good one"
                },
                new MessageModel()
                {
                    Id = 7,
                    UserName = "User D",
                    Message = "Let's have a great summer"
                }
            };
    }
}
