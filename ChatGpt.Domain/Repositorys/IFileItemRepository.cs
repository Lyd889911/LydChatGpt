using ChatGpt.Domain.Entities.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Repositorys
{
    public interface IFileItemRepository
    {
        Task<Avatar> FirstAsync(Guid id);
        Task<Avatar> FirstAsync(string hash);
        Task<Avatar> AddAsync(Avatar file);
    }
}
