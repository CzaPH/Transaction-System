﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction_System.Domain
{
    public class ApprovalStatus :Auditable
    {
        public bool? Approved { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}
