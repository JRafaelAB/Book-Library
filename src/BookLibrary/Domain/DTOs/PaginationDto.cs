using Domain.Exceptions;
using Domain.Resources;

namespace Domain.DTOs;

public class PaginationDto<T>
{
    public int TotalOfItems { get; }
    public const int ItemsPerPage = 4;
    public int CurrentPage { get; }
    public int TotalPages { get; private set; }
    public List<T> Items { get; private set; }

    public PaginationDto(List<T> items, int page)
    {
        TotalOfItems = items.Count;
        SetTotalPages();
        CurrentPage = page;
        CheckOutOfRange();
        SetItems(items);
    }

    private void CheckOutOfRange()
    {
        if (CurrentPage < 1 || CurrentPage > TotalPages) throw new PageOutOfRangeException(Messages.PageOutOfRange);
    }

    private void SetTotalPages()
    {
        TotalPages = (int)Math.Ceiling((double)TotalOfItems/ItemsPerPage);
        if (TotalPages == 0) TotalPages = 1;
    }

    private void SetItems(List<T> items)
    {
        if (TotalOfItems == 0) Items = new List<T>();
        else
        {
            var begin = (CurrentPage - 1) * ItemsPerPage;
            var end = (CurrentPage * ItemsPerPage - 1 > TotalOfItems ? TotalOfItems - 1 : CurrentPage * ItemsPerPage - 1) - begin-1;
            Items = items.GetRange(begin, end); 
        }
    }
}
