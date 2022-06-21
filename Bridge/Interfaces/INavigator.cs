using Bridge.ViewModels;
using System;

namespace Bridge.Interfaces
{
    internal interface INavigator
    {
        event Action CurrentViewModelChanged;
        ViewModelBase CurrentViewModel { get; set; }
    }
}
