using Application.ViewModel;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace UI.View
{
    public sealed class WPFContext : IUIContext
    {
        private readonly Dispatcher dispatcher;

        public bool IsSynchronized
        {
            get
            {
                return dispatcher.Thread == Thread.CurrentThread;
            }
        }

        public WPFContext() : this(System.Windows.Application.Current.Dispatcher)
        {
        }

        public WPFContext(Dispatcher dispatcher)
        {
            Debug.Assert(dispatcher != null);
            this.dispatcher = dispatcher;
        }

        public void Invoke(Action action)
        {
            Debug.Assert(action != null);
            dispatcher.Invoke(action);
        }

        public void BeginInvoke(Action action)
        {
            Debug.Assert(action != null);
            dispatcher.BeginInvoke(action);
        }
    }
}
