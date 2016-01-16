using System;
using System.Diagnostics;
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
 
        public override void DidFinishLaunching (Foundation.NSNotification notification)
        {
            Trace.WriteLine ("AppDelegate DidFinishLaunching");
            LaunchAction (Args, true);
        }
    }
}

