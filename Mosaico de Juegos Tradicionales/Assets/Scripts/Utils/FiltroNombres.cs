using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FiltroNombres
{
    static string[] obscenidades = new string[] { "puta", "ano", "pene", "pija", "vrga", "puto", "teta", "culo", "cock", "fuck", "shit",
                                                 "ass", "boob", "cum", "jizz", "cunt", "dick", "cuca", "meos", "pipi", "anus", "tit", "tits", "tapu", "nepe",
                                                    "japi", "topu", "locu", "cacu"};

    static char[] caracteresProhibidos = new char[] {'á', 'é','í', 'ó', 'ú', 'ä', 'ë', 'ï', 'ö', 'ü', 'ã', 'ẽ', 'ĩ', 'õ','ũ','`','´','+','-','*','/','_','.',',',':',';',
                                                      '>','<','?','!','=', '¡', '¿', '@', '#', '$', '%', '^', '&', '(', ')', '~', '[', ']', '{', '}'};

    public static string[] Obscenidades
    {
        get { return obscenidades; }
    }

    public static char[] CaracteresProhibidos
    {
        get { return caracteresProhibidos; }
    }
}
