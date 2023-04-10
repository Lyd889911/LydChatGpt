using ChatGpt.Shared.Enums;

namespace ChatGpt.Domain
{
    public interface IStorageClient
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="name">文件名</param>
        /// <param name="stream">文件内容</param>
        /// <returns></returns>
        string? SaveAsync(string name, Stream stream);
    }
}