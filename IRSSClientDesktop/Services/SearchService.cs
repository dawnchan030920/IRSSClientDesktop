using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.Services;

public class SearchService : ISearchService
{
    private readonly List<SuggestedItemData> _sample = new()
    {
        new SuggestedItemData()
            { Title = "Start", Description = "This is the start description", SourceCategory = SourceCategory.Article },
        new SuggestedItemData() { Title = "Hello?", SourceCategory = SourceCategory.Message },
        new SuggestedItemData()
            { Title = "Ask Zhihu...", Description = "Go to Answer page", SourceCategory = SourceCategory.Answer }
    };

    public List<SuggestedItemData> GetData(string? input)
    {
        if (string.IsNullOrEmpty(input)) return _sample;

        var result =
            from item in _sample
            where item.Title.ToLower().Contains(input.ToLower())
                || item.Description != null && item.Description.ToLower().Contains(input.ToLower())
            select item;
        return result.ToList();
    }
}
