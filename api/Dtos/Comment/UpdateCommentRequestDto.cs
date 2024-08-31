using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(4, ErrorMessage = " Title must be 4 characters at least")]
        [MaxLength(280, ErrorMessage = " Title cannot be over 280 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(4, ErrorMessage = " Content must be 4 characters at least")]
        [MaxLength(280, ErrorMessage = " Content cannot be over 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}