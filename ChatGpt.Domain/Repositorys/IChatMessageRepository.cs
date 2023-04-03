using ChatGpt.Domain.Entities.Chats.ChatGpt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Repositorys
{
    public interface IChatMessageRepository
    {
        Task<List<ChatMessage>> ListAsync(Expression<Func<ChatMessage, bool>> predicate);
        Task<ChatMessage> AddAsync(ChatMessage chatMessage);
    }
}
