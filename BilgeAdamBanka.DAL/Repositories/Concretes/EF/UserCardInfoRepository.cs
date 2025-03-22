using BilgeAdamBanka.DAL.ContextClasses;
using BilgeAdamBanka.DAL.Repositories.Abstracts;
using BilgeAdamBanka.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.DAL.Repositories.Concretes.EF
{
    public class UserCardInfoRepository : BaseRepository<UserCardInfo>, IUserCardInfoRepository
    {
        public UserCardInfoRepository(MyContext db) : base(db)
        {
        }
    }
}
