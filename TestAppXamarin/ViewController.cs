using Foundation;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AppCenter.Analytics.iOS.Bindings;
using ObjCRuntime;
using UIKit;
using Xamarin.Essentials;


namespace TestAppXamarin
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        private ulong GetDiskSpace()
        {
            ulong totalSpace = 0;
            NSError error = null;
            string[] paths = NSSearchPath.GetDirectories(NSSearchPathDirectory.UserDirectory, NSSearchPathDomain.All);
            var defManager = NSFileManager.DefaultManager;
            var dicAttributes = defManager.
                GetFileSystemAttributes(paths.First()
                    , out error);
            totalSpace = dicAttributes.Size;
            return totalSpace;
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            fullabel.Text =
                $"{Xamarin.Essentials.DeviceInfo.Model}{Environment.NewLine}{NSProcessInfo.ProcessInfo.PhysicalMemory}{Environment.NewLine}{GetDiskSpace()}";
            MSAnalytics.TrackEvent($"{Xamarin.Essentials.DeviceInfo.Model}|{NSProcessInfo.ProcessInfo.PhysicalMemory}|{GetDiskSpace()}");
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}