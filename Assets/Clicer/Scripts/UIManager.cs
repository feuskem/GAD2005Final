using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public SpawnUnits spawnUnits;

    public void SelectUnitIndex(int index)
    {
        spawnUnits.SelectUnit(index);
    }
}