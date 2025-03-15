﻿using ReactiveUI;

namespace EgoPrimer.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _title = "EgoPrimer";
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    public MainWindowViewModel()
    {
        if (Constants.DataDirNameOverwrite != string.Empty)
        {
            Title += $" (using {Constants.DataDirNameOverwrite})";
        }
    }
}
