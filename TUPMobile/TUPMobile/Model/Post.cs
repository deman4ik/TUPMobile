﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tupapi.Shared.Enums;
using tupapi.Shared.Interfaces;
using Microsoft.WindowsAzure.MobileServices;

namespace TUPMobile.Model
{
    public class PostTable : IPost
    {
        public string Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        [Version]
        public byte[] Version { get; set; }
        public bool Deleted { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public PhotoType Type { get; set; }
        public PhotoStatus Status { get; set; }
        public int Likes { get; set; }
    }
}
