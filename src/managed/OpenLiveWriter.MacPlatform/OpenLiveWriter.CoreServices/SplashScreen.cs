using System;
using System.Diagnostics;
using OpenLiveWriter.CoreServices;
using OpenLiveWriter.Localization;

using AppKit;
using CoreGraphics;

namespace OpenLiveWriter.MacPlatform
{
    public class SplashScreen : NSWindow, ISplashScreen
    {
        public SplashScreen () : base (CGRect.Empty, NSWindowStyle.Borderless, NSBackingStore.Buffered, false)
        {
            Debug.WriteLine ("Created Mac Splashscreen");

            BackgroundColor = NSColor.Clear;

            var backgroundImage = NSImage.ImageNamed ("SplashScreen.png");
            var logoImage = NSImage.ImageNamed ("SplashScreenLogo.jpg");

            SetContentSize (backgroundImage.Size);
            Center ();

            var background = new NSImageView ();
            background.TranslatesAutoresizingMaskIntoConstraints = false;
            background.Image = backgroundImage;

            ContentView.AddSubview (background);

            var constraints = NSLayoutConstraint.FromVisualFormat ("|[background]|", NSLayoutFormatOptions.None, "background", background);
            ContentView.AddConstraints (constraints);

            constraints = NSLayoutConstraint.FromVisualFormat ("V:|[background]|", NSLayoutFormatOptions.None, "background", background);
            ContentView.AddConstraints (constraints);

            var logo = new NSImageView ();
            logo.TranslatesAutoresizingMaskIntoConstraints = false;
            logo.Image = logoImage;

            background.AddSubview (logo);

            var constraint = NSLayoutConstraint.Create (logo, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal,
                                                        background, NSLayoutAttribute.CenterX, 1, 0);
            background.AddConstraint (constraint);

            constraint = NSLayoutConstraint.Create (logo, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal,
                                                    background, NSLayoutAttribute.Top, 1, 120);
            background.AddConstraint (constraint);

            var label = new NSTextField ();
            label.TranslatesAutoresizingMaskIntoConstraints = false;
            label.StringValue = Res.Get(StringId.SplashScreenCopyrightNotice);
            label.Bezeled = false;
            label.DrawsBackground = false;
            label.Selectable = false;
            label.Editable = false;
            label.Font = NSFont.SystemFontOfSize (7.5f);
            background.AddSubview (label);

            label.SizeToFit ();

            const int TEXT_PADDING_H = 36;
            const int TEXT_PADDING_V = 26;
            constraint = NSLayoutConstraint.Create (label, NSLayoutAttribute.Leading, NSLayoutRelation.Equal,
                                                    background, NSLayoutAttribute.Leading, 1, TEXT_PADDING_H);
            background.AddConstraint (constraint);

            constraint = NSLayoutConstraint.Create (label, NSLayoutAttribute.Baseline, NSLayoutRelation.Equal,
                                                    background, NSLayoutAttribute.Bottom, 1, -TEXT_PADDING_V);
            background.AddConstraint (constraint);

            constraint = NSLayoutConstraint.Create (label, NSLayoutAttribute.Width, NSLayoutRelation.Equal,
                                                    null, NSLayoutAttribute.NoAttribute, 1, label.Frame.Width);
            label.AddConstraint (constraint);

            constraint = NSLayoutConstraint.Create (label, NSLayoutAttribute.Height, NSLayoutRelation.Equal,
                                                    null, NSLayoutAttribute.NoAttribute, 1, label.Frame.Height);
            label.AddConstraint (constraint);
        }

        public void Show ()
        {
            MakeKeyAndOrderFront (this);
        }

        public new void Close ()
        {
            base.Close ();
        }
    }
}

