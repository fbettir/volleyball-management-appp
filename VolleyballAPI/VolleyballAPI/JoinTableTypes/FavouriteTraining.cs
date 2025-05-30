﻿using Microsoft.EntityFrameworkCore;
using VolleyballAPI.Entities;

namespace VolleyballAPI.JoinTableTypes
{
    [PrimaryKey(nameof(TrainingId), nameof(UserId))]
    public class FavouriteTraining
    {
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
        public virtual Training Training { get; set; }
        public virtual User User { get; set; }
    }
}
