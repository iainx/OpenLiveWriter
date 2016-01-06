using System;
using System.Diagnostics;
using OpenLiveWriter;
using OpenLiveWriter.CoreServices;

using AppKit;
using Foundation;

namespace OpenLiveWriter.MacPlatform
{
    public class MacPlatform : IMainPlatform
    {
        static AppDelegate appDelegate;

        public MacPlatform ()
        {
            Console.WriteLine ("Mac Platform created");

            NSApplication.Init ();

            var app = NSApplication.SharedApplication;

            Console.WriteLine ("Shared application {0} - {1}", app, NSApplication.SharedApplication);
            appDelegate = new AppDelegate ();

            NSApplication.SharedApplication.Delegate = appDelegate;

            // If NSPrincipalClass is not set, set it now. This allows running
            // the application without a bundle
            var info = NSBundle.MainBundle.InfoDictionary;
            if (info.ValueForKey ((NSString)"NSPrincipalClass") == null)
                info.SetValueForKey ((NSString)"NSApplication", (NSString)"NSPrincipalClass");
        }

        public void Run (SingleInstanceApplicationManager.LaunchAction launchAction, string[] args)
        {
            //pool.Dispose ();

            appDelegate.LaunchAction = launchAction;
            appDelegate.Args = args;

            NSApplication.Main (args);
        }
    }
}

