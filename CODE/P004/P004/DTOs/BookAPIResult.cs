﻿namespace P0004.DTOs
{
    public class BookAPIResult
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public List<int> Authors { get; set; }
            public List<string> Genres { get; set; }
            public int Year { get; set; }
    }
}
