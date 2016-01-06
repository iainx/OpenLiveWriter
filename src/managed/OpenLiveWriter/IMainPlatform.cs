using System;
using OpenLiveWriter.CoreServices;

namespace OpenLiveWriter
{
    public interface IMainPlatform
    {
        void Run (SingleInstanceApplicationManager.LaunchAction launchAction, string [] args);
    }
}

