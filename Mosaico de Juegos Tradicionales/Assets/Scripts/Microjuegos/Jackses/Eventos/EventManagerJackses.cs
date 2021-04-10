using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManagerJackses
{
    //Bola soltada
    static Bola invocadorBolaSoltada;
    static List<UnityAction> listenersBolaSoltada = new List<UnityAction>();

    //Perder al segundo rebote
    static Bola invocadorPerderSegundoRebote;
    static UnityAction listenerPerderSegundoRebote;

    //Revisar victoria al agarrar la pelota
    static Bola invocadorRevisarVictoria;
    static UnityAction listenerRevisarVictoria;

    //Aumentar numero de Jacks recolectados
    static List<Jack> invocadoresAgarrarJack = new List<Jack>();
    static UnityAction listenerAgarrarJack;

    //Bola soltada
    public static void AgregarInvocadorBolaSoltada(Bola invocador)
    {
        invocadorBolaSoltada = invocador;
        foreach (UnityAction listener in listenersBolaSoltada)
        {
            invocador.AgregarBolaSoltadaListener(listener);
        }
    }

    public static void AgregarBolaSoltadaListener(UnityAction handler)
    {
        listenersBolaSoltada.Add(handler);
        if (invocadorBolaSoltada != null)
        {
            invocadorBolaSoltada.AgregarBolaSoltadaListener(handler);
        }
    }

    //Perder al segundo rebote
    public static void AgregarInvocadorPerderSegundoRebote(Bola invocador)
    {
        invocadorPerderSegundoRebote = invocador;
        if (listenerPerderSegundoRebote != null)
        {
            invocadorPerderSegundoRebote.AgregarPerderSegundoReboteListener(listenerPerderSegundoRebote);
        }
    }

    public static void AgregarListenerPerderSegundoRebote(UnityAction handler)
    {
        listenerPerderSegundoRebote = handler;
        if (invocadorPerderSegundoRebote != null)
        {
            invocadorPerderSegundoRebote.AgregarPerderSegundoReboteListener(listenerPerderSegundoRebote);
        }
    }

    //Revisar victoria al agarrar la pelota
    public static void AgregarInvocadorRevisarVictoria(Bola invocador)
    {
        invocadorRevisarVictoria = invocador;
        if (listenerRevisarVictoria != null)
        {
            invocadorRevisarVictoria.AgregarRevisarVictoriaListener(listenerRevisarVictoria);
        }
    }

    public static void AgregarListenerRevisarVictoria(UnityAction handler)
    {
        listenerRevisarVictoria = handler;
        if (invocadorRevisarVictoria != null)
        {
            invocadorRevisarVictoria.AgregarRevisarVictoriaListener(listenerRevisarVictoria);
        }
    }

    //Aumentar numero de Jacks recolectados
    public static void AgregarInvocadorAgarrarJack(Jack invocador)
    {
        invocadoresAgarrarJack.Add(invocador);
        if (listenerAgarrarJack != null)
        {
            invocador.AgregarAgarrarJackListener(listenerAgarrarJack);
        }
    }

    public static void AgregarListenerAgarrarJack(UnityAction handler)
    {
        listenerAgarrarJack = handler;
        foreach(Jack jack in invocadoresAgarrarJack)
        {
            jack.AgregarAgarrarJackListener(listenerAgarrarJack);
        }
    }

}
