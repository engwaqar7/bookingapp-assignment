using System;
namespace BookingApp.Services
{
    public interface ISearchService<T>
    {
        Task SearchAsync();
    }
}
