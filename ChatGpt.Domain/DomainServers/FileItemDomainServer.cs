using ChatGpt.Domain.Entities.Files;
using ChatGpt.Domain.Repositorys;
using ChatGpt.Shared;
using ChatGpt.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.DomainServers
{
    public class FileItemDomainServer
    {
        private readonly IFileItemRepository _fileItemRepository;
        private readonly IStorageClient _backupClient;
        private readonly IStorageClient _remoteClient;
        public FileItemDomainServer(IFileItemRepository fileItemRepository, IEnumerable<IStorageClient> storageClients)
        {
            this._fileItemRepository = fileItemRepository;
            this._backupClient = storageClients.First(s => s.StorageType == StorageType.Backup);
            this._remoteClient = storageClients.First(s => s.StorageType == StorageType.Public);
        }
        public async Task<FileItem> UploadAsync(Stream stream, string fileName, CancellationToken cancellationToken=default)
        {
            string hash = HashHelper.ComputeSha256Hash(stream);
            long length = stream.Length;
            DateTime today = DateTime.Now;
            //文件的目录,路径
            string key = $"{today.Year}/{today.Month}/{today.Day}/{hash}/{fileName}";
            //查找是否存在这个文件,如果存在就不用上传了,直接更改一个修改日期就行了
            var fileItem = await _fileItemRepository.FirstAsync(hash);
            if (fileItem != null)
                return fileItem;
            //每次都要把指针的位置归零
            stream.Position = 0;
            //先备份
            Uri? backupUrl = await _backupClient.SaveAsync(key, stream, cancellationToken);
            stream.Position = 0;
            Uri? remoteUrl = await _remoteClient.SaveAsync(key, stream, cancellationToken);
            stream.Position = 0;
            //领域服务并不会真正的执行数据库插入，只是把实体对象生成，然后由应用服务和基础设施配合来真正的插入数据库！
            return new FileItem(fileName, hash, length,new FileAddress(remoteUrl,backupUrl));
        }
    }
}
