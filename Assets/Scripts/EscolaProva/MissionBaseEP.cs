using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public enum MissionTypeEP
{
    Geral, Historia
}


public abstract class MissionBaseEP : MonoBehaviour
{
    public string missao;

    public abstract void CreatedEP();
    public abstract string GetMissionDescriptionEP();
}

public class Geral : MissionBaseEP
{

    public override void CreatedEP()
    {
        #region Missao Geral
        string[] maxValues = { "Introdução a informática \n \t O 1",
        "Definição da Informática \n \t A 2",
        "Computador \n \t O 3"};

        #endregion
        int randomMaxValue = Random.Range(0, maxValues.Length);
        missao = maxValues[randomMaxValue];

    }

    public override string GetMissionDescriptionEP()
    {
        return "Cultura Geral \n \n" + missao;
    }

}

public class Historia : MissionBaseEP
{
    public override void CreatedEP()
    {
        #region Historia
        string[] maxValues = { "Conceitos básicos sobre Software \n \t 4",
        "Linguagem de Programação \n \t É 5",
        "Tipos de linguagem de programação \n \t 6"};

        #endregion
        int randomMaxValue = Random.Range(0, maxValues.Length);
        missao = maxValues[randomMaxValue];
    }

    public override string GetMissionDescriptionEP()
    {
        return "História \n \n" + missao;
    }
}
