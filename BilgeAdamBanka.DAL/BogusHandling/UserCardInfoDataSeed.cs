using BilgeAdamBanka.ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.DAL.BogusHandling
{
    public static class UserCardInfoDataSeed
    {
        public static void SeedUserCardInfos(ModelBuilder modelBuilder)
        {
            List<UserCardInfo> userCardInfos = new List<UserCardInfo>
            {
                new UserCardInfo
                {
                    Id = 1,
                    CardUserName = "John Doe",
                    CardNumber = "4355084355084358",
                    CVC = "123",
                    ExpiryYear = 2025,
                    ExpiryMonth = 11,
                    CardLimit = 8600,
                    Balance = 8600
                },
                new UserCardInfo
                {
                    Id = 2,
                    CardUserName = "Jane Sue",
                    CardNumber = "5400617049774124",
                    CVC = "321",
                    ExpiryYear = 2023,
                    ExpiryMonth = 10,
                    CardLimit = 5000,
                    Balance = 5000
                },
                new UserCardInfo
                {
                    Id = 3,
                    CardUserName = "Kevin Neo",
                    CardNumber = "4716081467305766",
                    CVC = "601",
                    ExpiryYear = 2023,
                    ExpiryMonth = 1,
                    CardLimit = 4000,
                    Balance = 4000
                },
                new UserCardInfo
                {
                    Id = 4,
                    CardUserName = "Sue Mayre",
                    CardNumber = "4289450187923330",
                    CVC = "922",
                    ExpiryYear = 2023,
                    ExpiryMonth = 6,
                    CardLimit = 3200,
                    Balance = 3200
                }
            };

            modelBuilder.Entity<UserCardInfo>().HasData(userCardInfos);
        }
    }
}
