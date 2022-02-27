using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class DIALOGUES
{
    //FIRST PIECE
    static public string firstPiece = "Ceci est le premier dialogue";
    ///PIECE VIDE
    static public string pieceVide = "Cette piece est vide... Je ne m'y sens pas très à l'aise...";

    ///PIECE DU CHIEN
    static public string chienDocile1 = "Tu m'as l'air bien gentil petit CH1-3n. Qu'est-ce que tu fais icitte tout seul ?";

    static public string chienDocileCaresse1 = "Te câliner est réellement réconfortant.";
    static public string chienDocileCaresse2 = "C'est un bon robot qui aime les caresses ça ! Oh, tu m'accompagnes ?";

    static public string chienDocileAttaque1 = "Saleté de robot ! Il m'a frappé !";
    static public string chienDocileAttaque2 = "Pourquoi ai-je fait ça, c'était même pas déstressant...";

    static public string chienMechant1 = "Ce CH1-3n m'a vraiment l'air agressif...";

    static public string chienMechantCaresse1 = "AIE IL M'A FRAPPÉ ! J'aurais dû m'en douter aussi...";
    static public string chienMechantAttaque1 = "Prends ça sale robot, c'est ça dégage !";

    ///PIECE SQUELETTE
    static public string squeletteQuestion = "L'armure de ce squelette me serait sûrement plus utile qu'à ce dernier...";
    static public string squeletteRep2 = "Prendre l'armure";
    static public string squeletteRep1 = "Laisser le cadavre";

    static public string squelettePrendre = "Je suppose que je vais devoir faire avec l'odeur de putréfaction...";
    static public string squeletteLaisser = "Je ferais mieux de laisser cette pauvre âme reposer en paix.";

    //TRESOR
    static public string tresorParTerre = "Il y a quelque chose par terre...";

    static public string tresorRep1 = "Ramasser";
    static public string tresorRep2 = "Laisser";

    //Cristal
    static public string cristalTrouveDisabled =
        "Un imposant cristal rouge trône au milieu de la pièce. En m'approchant du cristal il me semble voir " +
        "un amas de chair remuer lentement en son centre.";

    static public string cristalTrouveEnabled =
        "Encore ce cristal... J'ai l'impression qu'il émet une lumière plus intense.";

    static public string cristalToucheToEnable =
        "Ahh.. Ahh.. Ma tête... Je me sens... si faible...";

    static public string cristalToucheToDisable =
        "HHHHHHHH !! AH ! Je... Je me sens revitalisé !";

    static public string cristalRep1 = "Toucher";
    static public string cristalRep2 = "Ne pas toucher";

}
