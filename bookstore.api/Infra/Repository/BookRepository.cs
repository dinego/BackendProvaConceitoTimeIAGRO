using Common;
using Domain.DTO.Request;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Domain.Enum;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Infra.Repository
{
    public class BookRepository: IBookRepository
    {
        readonly string bookFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "books.json");

        public IEnumerable<BookResponseDTO> GetAll()
        {
            string jsonContent = File.ReadAllText(bookFilePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<IEnumerable<BookResponseDTO>>(jsonContent, options);

            return data;
        }

        public BookResponseDTO GetById(int id)
        {
            var allData = GetAll();
            return allData.Any(x => x.Id == id) ? 
                allData.FirstOrDefault(x => x.Id == id) : 
                null;
        }

        public IEnumerable<BookResponseDTO> GetBySpecifications(BookRequestSpecificationsDTO request)
        {
        
            var allData = GetAll();

            var dataFiltered = allData.Where(w =>
                (request.PageCount == null || w.Specifications.PageCount == request.PageCount) &&
                (request.OriginallyPublished == null || VerifyOriginalPublished(w.Specifications.OriginallyPublished, request.OriginallyPublished)) &&
                (request.Author == null || w.Specifications.Author.ToLower().Contains(request.Author.ToLower())) &&
                (request.Illustrator == null || HasStringInObjectList(request.Illustrator, (JsonElement)w.Specifications.Illustrator)) &&
                (request.Genres == null || HasStringInObjectList(request.Genres, (JsonElement)w.Specifications.Genres)));

            return dataFiltered;
        }

        private bool VerifyOriginalPublished(string originallyPublished, string request)
        {
            if (string.IsNullOrEmpty(originallyPublished))
                return false;
            
            return originallyPublished.ToLower().Contains(request.ToLower());
        }

        private bool HasStringInObjectList(string illustrator, JsonElement illustratorsArray)
        {
            
            if (illustratorsArray.ValueKind == JsonValueKind.String)
            {
                return illustratorsArray.GetString().ToString().ToLower().Contains(illustrator.ToLower());
            }

            if (illustratorsArray.EnumerateArray().Any())
            {
                var finded = illustratorsArray.EnumerateArray().ToList().Select(s => s.GetString().ToLower());
                var contains = finded.ToList().Any(a => a.ToLower().Contains(illustrator.ToLower()));
                return contains;
            }

            return false;
        }

        public IEnumerable<BookResponseDTO> SortByPrice(EOrdination request)
        {
            var allData = GetAll();
            return request == EOrdination.DESC ? 
                allData.OrderByDescending(x => x.Price) : 
                allData.OrderBy(x => x.Price);
        }

        public IEnumerable<BookResponseDTO> GetBySpecification(string request)
        {
            var allData = GetAll();

            if (string.IsNullOrEmpty(request))
                return null;

            request = request.ToLower();

            var dataFiltered = allData.Where(w =>
                HasStringInObjectList(request, (JsonElement)w.Specifications.Illustrator) ||
                HasStringInObjectList(request, (JsonElement)w.Specifications.Genres) ||
                GetPropertyByString(request, w.Specifications.PageCount.ToString()) ||
                GetPropertyByString(request, w.Specifications.OriginallyPublished?.ToLower()) ||
                GetPropertyByString(request, w.Specifications.Author?.ToLower())
                );

            return dataFiltered;
        }

        private bool GetPropertyByString(string request, string v)
        {
            if (string.IsNullOrEmpty(v)) return false;
            var contains = v.Contains(request);
            return contains;
        }
    }
}
