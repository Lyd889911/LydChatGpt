using ChatGpt.Domain.Entities.Files;
using ChatGpt.Shared;
using ChatGpt.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Domain.Entities.Users
{
    public class User:AggregateRoot
    {
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public Guid AvatarId { get; private set; }
        public int MaxUseCountDaily { get; private set; }
        public int SurplusUserCountDaily { get; private set; }

        private User()
        {

        }
        public User(string userName, string password, Guid avatarId,int maxUseCountDaily)
        {
            UserName = userName;
            PasswordHash = HashHelper.ComputeSha256Hash(password);
            AvatarId = avatarId;
            MaxUseCountDaily = maxUseCountDaily;
            SurplusUserCountDaily = maxUseCountDaily;
        }

        public bool CheckPassword(string password)
        {
            return PasswordHash == HashHelper.ComputeSha256Hash(password) ? true : false;
        }
        public void UpdatePassword(string newPassword)
        {
            PasswordHash = HashHelper.ComputeSha256Hash(newPassword);
        }
        public void UpdateAvatar(Guid avatarId)
        {
            AvatarId = avatarId;
        }
        public void UpdateUserName(string userName)
        {
            UserName = userName;
        }
        public void UseAI()
        {
            if (SurplusUserCountDaily<=0)
                throw new ArgumentException("每天次数已经使用完成");
            else
                SurplusUserCountDaily--;
        }
        public void ResumeAICount()
        {
            SurplusUserCountDaily=MaxUseCountDaily;
        }

    }
}
