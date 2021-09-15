using UnityEngine;
using IJunior.TypedScenes;

public class StartSession : MonoBehaviour
{
    [SerializeField] 

    private int _sessionCount = 0;

    private const string SessionCount = "Session_Count";
    private const string FirstDate = "Reg_Day";
    private const string DaysInGame = "Days_In_Game";

    private void Awake()
    {
        _sessionCount++;

        if (PlayerPrefs.GetInt(SessionCount) != _sessionCount)
            PlayerPrefs.SetInt(SessionCount, _sessionCount);
    }
}
