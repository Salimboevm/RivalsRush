#if UNITU_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class AutoSetPrefabPath : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }

    public void OnPreprocessBuild(BuildReport report)
    {
        Master.PopulateNetworkPrefabs();
    }
}
#endif