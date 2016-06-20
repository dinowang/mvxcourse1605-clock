// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the ClockView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Clock.Droid.Views
{
    using Android.App;
    using Android.OS;

    /// <summary>
    /// Defines the ClockView type.
    /// </summary>
    [Activity(Label = "View for ClockView")]
    public class ClockView : BaseView
    {

        protected override int LayoutResource => Resource.Layout.ClockView;

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(LayoutResource);
        }
    }
}
