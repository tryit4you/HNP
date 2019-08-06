
using HNP.DATA.DI.Interfaces;
using HNP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNP.DATA.DI.Repositories
{
    public class FeedbackRepository:Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DataDbContext context):base(context)
        {

        }
    }
}
