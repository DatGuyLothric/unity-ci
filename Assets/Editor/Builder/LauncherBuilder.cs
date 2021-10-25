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
            
            BuildPipeline.BuildPlayer(scenes, "", BuildTarget.NoTarget, BuildOptions.None);
        }
    }
}
