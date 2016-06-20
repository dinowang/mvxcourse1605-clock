using System;
using System.Threading;
using Android.Content;
using Clock.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.Messenger;

namespace Clock.Droid
{
    public class Setup : MvxAndroidSetup
    {
        private IMvxMessenger _messenger;

        private readonly object _timerState = new object();
        private Timer _timer;

        public Setup(Context applicationContext) : base(applicationContext)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            _messenger = Mvx.Resolve<IMvxMessenger>();

            _timer = new Timer(x =>
            {
                _messenger.Publish(new ClockMessage(_messenger));
            },
            _timerState,
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(1));

            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
