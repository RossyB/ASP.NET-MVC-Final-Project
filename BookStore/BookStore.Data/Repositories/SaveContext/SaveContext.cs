using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repositories.SaveContext
{
    public class SaveContext : ISaveContext
    {
        private readonly MsSqlDbContext context;

        public SaveContext(MsSqlDbContext context)
        {
            Guard.WhenArgument(context, nameof(MsSqlDbContext)).IsNull().Throw();

            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
