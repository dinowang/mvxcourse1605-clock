using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;

namespace Clock.Core.ViewModels
{
    public class ClockMessage : MvxMessage
    {
        public ClockMessage(object sender) : base(sender)
        {
        }
    }
}
