using UnityEditor;

namespace Editor.Builder
{
    public static class LauncherBuilder
    {
        public static void PerformBuild()
        {
            var scenes = new []
            {
                "Assets/Scenes/Launcher.unity"
            };
            
            BuildPipeline.BuildPlayer(scenes, "/Users/runner/work/unity-ci/unity-ci/builds/osx/Launcher", BuildTarget.StandaloneOSX, BuildOptions.None);
        }
    }
}
