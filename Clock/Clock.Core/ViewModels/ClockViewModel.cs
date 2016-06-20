// --------------------------------------------------------------------------------------------------------------------
// <summary>
//  Defines the ClockViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using MvvmCross.Plugins.Messenger;

namespace Clock.Core.ViewModels
{ 
    /// <summary>
    /// Define the ClockViewModel type.
    /// </summary>
    public class ClockViewModel : BaseViewModel, IDisposable
    {
        private IMvxMessenger _messenger;

        private MvxSubscriptionToken _subscriptionToken;

        public ClockViewModel(IMvxMessenger messenger)
        {
            _messenger = messenger;

            _subscriptionToken = _messenger.Subscribe<ClockMessage>(x =>
            {
                DateTime = DateTime.UtcNow;
            });
        }

        private DateTime _dateTime = DateTime.UtcNow;

        public DateTime DateTime
        {
            get { return _dateTime; }
            set { SetProperty(ref _dateTime, value); }
        }

        public void Dispose()
        {
            _subscriptionToken?.Dispose();
        }
    }
}

