using UnityEditor;

public static class BuildApp
{
    [MenuItem("Build/BuildApp")]
    public static void Build()
    {
        //windows64のプラットフォームでアプリをビルドする
        BuildPipeline.BuildPlayer(
            new string[] { "Assets/Scenes/Stage1Scene.unity" },
            "Builds/App/アチコチラビリンス.exe",
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
}
