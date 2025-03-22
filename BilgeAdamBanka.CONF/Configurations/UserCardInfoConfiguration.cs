using BilgeAdamBanka.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdamBanka.CONF.Configurations
{
    public class UserCardInfoConfiguration : BaseEntityConfiguration<UserCardInfo>
    {
        public override void Configure(EntityTypeBuilder<UserCardInfo> builder)
        {
            base.Configure(builder);
        }
    }
}
