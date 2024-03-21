using chatAppWebApi.Models;
using chatAppWebApi.Repositories;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace chatAppWebApi.Services
{
    public class ChatroomService : IChatroomService
    {
        private readonly IChatroomRepository _chatroomRepository;
        public ChatroomService(IChatroomRepository chatroomRepository)
        {
            _chatroomRepository = chatroomRepository;
        }
        public async Task<IEnumerable<MessageModel>> GetAllMessages()
        {
            var allMessages = await _chatroomRepository.GetAllMessages();

            if (allMessages is not null)
                {
                    return allMessages;
                }
                else
                {
                    throw new Exception();
                };
        }
        public async Task<MessageModel> CreateMessage(string user, string message)
        {
            var newMessage = new MessageModel
            {
                Id = IncrementMessageId(),
                UserName = user,
                Message = message
            };

            var response = await _chatroomRepository.CreateMessage(newMessage);

                if (response is not null)
                {
                    return response;
                }
                else
                {
                    throw new Exception();
                };
        }
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var allUsers = await _chatroomRepository.GetAllUsers();

            if (allUsers is not null)
            {
                return allUsers;
            }
            else
            {
                throw new Exception();
            };
        }
        public async Task<UserModel> CreateUser(string username)
        {
            var newUser = new UserModel
            {
                Id = IncrementUserId(),
                UserName = username,
            };

            var response = await _chatroomRepository.CreateUser(newUser);

                if (response is not null)
                {
                    return response;
                }
                else
                {
                    throw new Exception();
                };
        }
        public async Task<UserModel?> GetUser(int id)
        {
            var matchingUser = await _chatroomRepository.GetUser(id);

                if (matchingUser is not null)
                {
                    return matchingUser;
                }
                else
                {
                    throw new Exception();
                };
        }
        private int IncrementMessageId()
        {
            var nextId = _chatroomRepository.IncrementMessageId();

            return nextId;
        }
        private int IncrementUserId()
        {
            var nextId = _chatroomRepository.IncrementUserId();

            return nextId;
        }
    }
}
