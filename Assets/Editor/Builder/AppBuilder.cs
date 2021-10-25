using UnityEditor;

namespace Editor.Builder
{
    public static class AppBuilder
    {
        public static void PerformBuild()
        {
            var scenes = new []
            {
                "Assets/Scenes/FirstScene.unity",
                "Assets/Scenes/SecondScene.unity"
            };
            
            BuildPipeline.BuildPlayer(scenes, "", BuildTarget.NoTarget, BuildOptions.None);
        }
    }
}

