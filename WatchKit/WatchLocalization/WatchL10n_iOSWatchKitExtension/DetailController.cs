using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WatchL10n_iOSWatchKitExtension
{
	partial class DetailController : WatchKit.WKInterfaceController
	{
		public DetailController (IntPtr handle) : base (handle)
		{
		}

		public override void WillActivate ()
		{
			base.WillActivate ();

			var hour = DateTime.Now.Hour;

			var display = "zzzz";
			if (hour < 6) {
			// zzz
			} else if (hour < 10) {
				display = "Breakfast time";
			} else if (hour < 16) {
				display = "Lunch time";
			} else if (hour < 21) {
				display = "Dinner time";
			} else if (hour < 23) {
				display = "Bed time";
			}
			var localizedDisplay = NSBundle.MainBundle.LocalizedString (display, comment:"greeting");
			displayText.SetText (localizedDisplay);

			// "language@2x.png" is located in the Watch Extension
			// multiple times: once for each language .lproj directory
			using (var image = UIImage.FromBundle ("language")) {
				displayImage.SetImage (image);
			}	
		
		}
	}
}
