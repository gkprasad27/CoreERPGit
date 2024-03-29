﻿using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class MenuAccesses
    {
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }
        public string? OperationCode { get; set; }
        public string? CompCode { get; set; }
        public string? BranchCode { get; set; }
        public string? RoleId { get; set; }
        public string? Ext1 { get; set; }
        public string? Ext2 { get; set; }
        public string? UserId { get; set; }
        public string? Ext4 { get; set; }
        public int? Access { get; set; }
        public bool? Active { get; set; }
        public DateTime? AddDate { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanView { get; set; }
        public string? screenName { get; set; }
    }
}
