using UnityEditor;

public static class BuildApp
{
    [MenuItem("Build/BuildApp")]
    public static void Build()
    {
        //windows64�̃v���b�g�t�H�[���ŃA�v�����r���h����
        BuildPipeline.BuildPlayer(
            new string[] { "Assets/Scenes/Stage1Scene.unity" },
            "Builds/App/�A�`�R�`���r�����X.exe",
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
}
