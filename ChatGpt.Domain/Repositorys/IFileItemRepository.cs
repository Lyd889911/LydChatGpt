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
        Task<FileItem> FirstAsync(Guid id);
        Task<FileItem> FirstAsync(string hash);
        Task<FileItem> AddAsync(FileItem file);
    }
}
