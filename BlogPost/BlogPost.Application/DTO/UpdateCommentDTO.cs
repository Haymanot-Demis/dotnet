﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.DTO
{
    public class UpdateCommentDTO
    {
        public int PostId { get; set; }
        public string? Text { get; set; }
    }
}
