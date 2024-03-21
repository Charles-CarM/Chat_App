using chatAppWebApi.Models;

namespace chatAppWebApi.Repositories
{
    public interface IChatroomRepository
    {
        Task<MessageModel> CreateMessage(MessageModel newMessage);
        Task<UserModel> CreateUser(UserModel newUser);
        Task<IEnumerable<MessageModel>> GetAllMessages();
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel?> GetUser(int id);
        int IncrementMessageId();
        int IncrementUserId();
    }
}