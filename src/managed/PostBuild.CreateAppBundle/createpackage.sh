#!/bin/sh

XM_PATH=/Library/Frameworks/Xamarin.Mac.framework/Versions/Current
XM_LIB_PATH=$XM_PATH/lib
XM_BIN_PATH=$XM_PATH/bin
DLL_PATH=$XM_LIB_PATH/mono/4.5
MONO_PATH=/Library/Frameworks/Mono.framework
MONO_DLL_PATH=$MONO_PATH/Libraries/mono/4.5
OLW_OBJ_PATH=src/managed/obj/DebugMac
OLW_DLL_PATH=src/managed/bin/DebugMac/i386/Writer
APP_NAME=OpenLiveWriter
OLW_EXE=$OLW_DLL_PATH/$APP_NAME.exe

SYSTEM_ASSEMBLIES="/assembly:$MONO_DLL_PATH/System.dll /assembly:$MONO_DLL_PATH/System.Xml.dll /assembly:$MONO_DLL_PATH/System.Data.dll /assembly:$MONO_DLL_PATH/System.Drawing.dll /assembly:$MONO_DLL_PATH/System.Web.dll /assembly:$MONO_DLL_PATH/System.Windows.Forms.dll /assembly:$MONO_DLL_PATH/System.Design.dll /assembly:$MONO_DLL_PATH/System.Web.Services.dll /assembly:$MONO_DLL_PATH/System.Core.dll /assembly:$XM_LIB_PATH/mono/4.5/Xamarin.Mac.dll /assembly:$MONO_DLL_PATH/mscorlib.dll /assembly:$DLL_PATH/Mono.Security.dll /assembly:$MONO_DLL_PATH/Mono.WebBrowser.dll /assembly:$MONO_DLL_PATH/Accessibility.dll /assembly:$MONO_DLL_PATH/System.Web.ApplicationServices.dll /assembly:$MONO_DLL_PATH/System.DirectoryServices.dll /assembly:$MONO_DLL_PATH/Novell.Directory.Ldap.dll /assembly:$MONO_DLL_PATH/System.ServiceModel.Discovery.dll"

OLW_ASSEMBLIES="/assembly:$OLW_DLL_PATH/OpenLiveWriter.Api.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.ApplicationFramework.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.BlogClient.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.BrowserControl.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.Controls.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.CoreServices.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.Extensibility.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.FileDestinations.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.HtmlEditor.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.HtmlParser.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.InternalWriterPlugin.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.Interop.Mshtml.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.Interop.SHDocVw.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.Interop.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.Localization.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.MacPlatform.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.Mshtml.dll /assembly:$OLW_DLL_PATH/OpenLiveWriter.PostEditor.dll"

NATIVE_REFERENCES="/native-reference:$MONO_PATH/Libraries/libgdiplus.dylib"

MMP_OPTIONS="/verbose /debug /output:. /name:$APP_NAME /arch:x86_64 /sgen /new-refcount /profiling /nolink /profile:4.5 --embed-mono=false"

$XM_BIN_PATH/mmp $MMP_OPTIONS $SYSTEM_ASSEMBLIES $OLW_ASSEMBLIES $NATIVE_REFERENCES $OLW_EXE /sdkroot /Applications/Xcode.app/Contents/Developer --cache $OLW_OBJ_PATH/mmp-cache

cp src/managed/OpenLiveWriter.MacPlatform/Info.plist $APP_NAME.app/Contents/
mkdir -p $APP_NAME.app/Contents/Resources
cp src/managed/OpenLiveWriter.MacPlatform/Resources/Writer.icns $APP_NAME.app/Contents/Resources/
