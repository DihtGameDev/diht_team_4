using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings File", menuName = "Game Settings File", order = 51)]
public class Settings : ScriptableObject
{
    [SerializeField]
    private int farmsBuildCount;
    [SerializeField]
    private int goldIncome;
    [SerializeField]
    public int[] farmsIncome;
    
    public int FarmsBuildCount => farmsBuildCount;

    
    public int[] FarmsIncome => farmsIncome;


    public int GoldIncome => goldIncome;

}
