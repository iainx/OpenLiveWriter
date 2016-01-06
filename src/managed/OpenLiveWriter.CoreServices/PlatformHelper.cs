// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System;
using System.IO;
using System.Reflection;

namespace OpenLiveWriter.CoreServices
{
    public sealed class PlatformHelper
    {
        /// <summary>
        /// Determines if the application is running on Windows 7
        /// </summary>
        public static bool RunningOnWin7OrHigher()
        {
            Version version = Environment.OSVersion.Version;
            return (version.Major >= 7) || (version.Major == 6 && version.Minor >= 1);
        }

        /// <summary>
        /// Throws PlatformNotSupportedException if the application is not running on Windows 7
        /// </summary>
        public static void ThrowIfNotWin7OrHigher()
        {
            if (!RunningOnWin7OrHigher())
            {
                throw new PlatformNotSupportedException("Only supported on Windows 7 or newer.");
            }
        }

        static Assembly platformAssembly = null;
        public static T GetPlatform<T> () where T:class
        {
            if (platformAssembly == null) {
                var assemblyPath = Path.GetDirectoryName (Assembly.GetEntryAssembly ().Location);
                Console.WriteLine ("Assembly Path: {0}", assemblyPath);
#if WINDOWS
#elif MAC
                var platformAssemblyPath = Path.Combine (assemblyPath, "OpenLiveWriter.MacPlatform.dll");
                Console.WriteLine ("Platform path: {0}", platformAssemblyPath);
                platformAssembly = Assembly.LoadFrom (platformAssemblyPath);

                /*
                Type platformType = platformAssembly.GetType ("OpenLiveWriter.MacPlatform.MacPlatform");
                platform = Activator.CreateInstance (platformType);
                */
#else
                throw new NotSupportedException ();
#endif
            }

            foreach (var type in platformAssembly.GetTypes ()) {
                if (type != typeof (T) && typeof (T).IsAssignableFrom (type)) {
                    return (T) Activator.CreateInstance (type);
                }
            }

            throw new NotImplementedException ();
        }
    }

}
