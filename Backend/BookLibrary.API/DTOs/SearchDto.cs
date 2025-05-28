﻿namespace BookLibrary.API.DTOs
{
    public record class SearchDto(string? Author, string? Isbn, short MarkAs)
    {
        private int _page = 1;
        public int Page { get => _page; set => _page = value < 1 ? 1 : value; }

        private int _pageSize = 10;
        public int PageSize { get => _pageSize; set => _pageSize = value < 1 ? 1 : value; }
    }
}
