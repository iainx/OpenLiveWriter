using System;

using OpenLiveWriter.CoreServices;

using AppKit;
using Foundation;

namespace OpenLiveWriter.MacPlatform
{
    [Register ("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public SingleInstanceApplicationManager.LaunchAction LaunchAction { get; set; }
        public string [] Args { get; set; }
        public AppDelegate ()
        {
            
        }

        public override void DidFinishLaunching (Foundation.NSNotification notification)
        {
            Console.WriteLine ("AppDelegate DidFinishLaunching");
            //LaunchAction (Args, true);
        }
    }
}

