using UnityEditor;

namespace Editor.Builder
{
    public static class LauncherBuilder
    {
        public static void PerformBuild()
        {
            var scenes = new []
            {
                "Assets/Scenes/MyScene.unity"
            };
            
            BuildPipeline.BuildPlayer(scenes, "/Users/runner/work/unity-ci/unity-ci/builds/windows/launcher", BuildTarget.NoTarget, BuildOptions.None);
        }
    }
}
