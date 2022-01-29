﻿namespace Application.ViewModel
{
    public interface IUIContext
    {
        bool IsSynchronized { get; }
        void Invoke(Action action);
        void BeginInvoke(Action action);
    }
}
