using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public enum MissionType
{
    Informatica, Programacao
}


public abstract class MissionBase : MonoBehaviour
{
    public string missao;

    public abstract void Created();
    public abstract string GetMissionDescription();


}

public class Informatica : MissionBase
{

    public override void Created()
    {
        #region Missao Informatica
        string[] maxValues = { "Introdução a informática \n \t O termo 'informática' deriva da aglutinação de duas palavras, que são: \n \n \t 'informação' e 'Automática' \n \n \t Este termo foi introduzido pela primeira vez em 1962, pelo Francês Philipe Dreyfus, professor de Química Industrial na escola superior de Física e Química na Inglaterra. ",
        "Definição da Informática \n \t A informática é a ciênçia que estuda e regulamenta os métodos de tratamento automático da informação, tendo como suporte básico e indispensável o computador.",
        "Computador \n \t O computador é um conjunto de circuitos electrónicos de incrivel complexidade, que ajuda o homem na realização das suas tarefas"};

        #endregion
        int randomMaxValue = Random.Range(0, maxValues.Length);
        missao = maxValues[randomMaxValue];

    }

    public override string GetMissionDescription()
    {
        return "Informática \n \n" + missao;
    }

}

public class Programacao : MissionBase
{
    public override void Created()
    {
        #region Missao Programacao
        string[] maxValues = { "Conceitos básicos sobre Software \n \t É um conjunto de ordens ou instruções que tornam possivel o computador realizar determinadas tarefas. \n \t O software refere-se à unidade lógica do computador e aos seus componentes imateriais.",
        "Linguagem de Programação \n \t É um método padronizado para expressar instruções para um computador. \n \t A linguagem de programação é o meio que temos para comunicarmo-nos ou levarmos as nossas ideias para o computador.",
        "Tipos de linguagem de programação \n \t Linguagem de Máquina; \n \t Linguagem de Baixo Nível; \n \t Linguagem de Alto Nível."};

        #endregion
        int randomMaxValue = Random.Range(0, maxValues.Length);
        missao = maxValues[randomMaxValue];
    }

    public override string GetMissionDescription()
    {
        return "Programação \n \n" + missao;
    }
}


