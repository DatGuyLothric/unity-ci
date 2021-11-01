using UnityEditor;

namespace Editor
{
    public static class BuildHelper
    {
        private const string BasePath = "/Users/runner/work/unity-ci/unity-ci/builds";
        private const string OSXPath = "osx";
        private const string WindowsPath = "windows";
        private const string Launcher = "Launcher";
        private const string App = "App";
        
        private static readonly string[] ScenesForLauncher = {"Assets/Scenes/Launcher.unity"};
        private static readonly string[] ScenesForApp = {"Assets/Scenes/FirstScene.unity", "Assets/Scenes/SecondScene.unity"};

        public static void PerformBuild()
        {
            BuildLauncherOSX();
            BuildAppOSX();
            BuildLauncherWindows();
            BuildAppWindows();
        }
        
        public static void PerformBuildAppOnly()
        {
            BuildLauncherWindows();
            BuildAppWindows();
        }

        private static void BuildLauncherOSX()
        {
            BuildPipeline.BuildPlayer(ScenesForLauncher, $"{BasePath}/{OSXPath}/{Launcher.ToLower()}/{Launcher}", BuildTarget.StandaloneOSX, BuildOptions.None);
        }

        private static void BuildAppOSX()
        {
            BuildPipeline.BuildPlayer(ScenesForApp, $"{BasePath}/{OSXPath}/{App.ToLower()}/{App}", BuildTarget.StandaloneOSX, BuildOptions.None);
        }

        private static void BuildLauncherWindows()
        {
            BuildPipeline.BuildPlayer(ScenesForLauncher, $"{BasePath}/{WindowsPath}/{Launcher.ToLower()}/{Launcher}.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
        }

        private static void BuildAppWindows()
        {
            BuildPipeline.BuildPlayer(ScenesForApp, $"{BasePath}/{WindowsPath}/{App.ToLower()}/{App}.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
        }
    }
}
