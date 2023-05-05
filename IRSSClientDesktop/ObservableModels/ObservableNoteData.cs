using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using IRSSClientDesktop.Core.Models;

namespace IRSSClientDesktop.ObservableModels;

public class ObservableNoteData : ObservableObject
{
    private readonly NoteData _note;

    public ObservableNoteData(NoteData note) => this._note = note;

    public string Content
    {
        get => _note.Content;
        set => SetProperty(_note.Content, value, _note, (u, n) => u.Content = n);
    }

    public DateTime Time
    {
        get => _note.Time;
        set => SetProperty(_note.Time, value, _note, (u, n) => u.Time = n);
    }

    public string Id
    {
        get => _note.Id;
        set => SetProperty(_note.Id, value, _note, (u, n) => u.Id = n);
    }

    public string ArticleTitle => _note.ArticleTitle;
}