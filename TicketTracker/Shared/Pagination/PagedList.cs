﻿namespace TicketTracker.Shared.Pagination;

public class PagedList<T> : List<T>
{
    public MetaData MetaData { get; set; }

    public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        MetaData = new MetaData
        {
            TotalCount = count,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };

        AddRange(items);
    }

    public static PagedList<T> ToPagedList(int totalItem, IEnumerable<T> source, int pageNumber, int pageSize)
    {

        return new PagedList<T>(source, totalItem, pageNumber, pageSize);
    }
}