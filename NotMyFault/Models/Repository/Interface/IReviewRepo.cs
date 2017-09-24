﻿using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IReviewRepo
    {
        List<Review> GetRevByUserId(int id);
    }
}
