using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Requests
{
    public class BookRequestSpecificationsDTO
    {
        public string? OriginallyPublished { get; set; }
        public string? Author { get; set; }
        public int? PageCount { get; set; }
        public string Illustrator { get; set; }
        public string Genres { get; set; }
    }
}
