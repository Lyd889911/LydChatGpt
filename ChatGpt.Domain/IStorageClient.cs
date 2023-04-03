using ChatGpt.Shared.Enums;

namespace ChatGpt.Domain
{
    public interface IStorageClient
    {
        /// <summary>
        /// 保存文件的类型
        /// </summary>
        StorageType StorageType { get; }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="key">文件路径的一部分</param>
        /// <param name="content">文件内容</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Uri?> SaveAsync(string key, Stream content, CancellationToken cancellationToken = default);
    }
}