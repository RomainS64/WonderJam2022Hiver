using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class DIALOGUES
{
    ///PIECE VIDE
    static public string pieceVide = "Cette piece est vide... Je ne m'y sens pas très à l'aise...";

    ///PIECE DU CHIEN
    static public string chienDocile1 = "Oh ! Un chien ! Il semble plutôt amical.";

    static public string chienDocileCaresse1 = "Ça fait vraiment du bien de le caresser.";
    static public string chienDocileCaresse2 = "Ça fait vraiment du bien de le caresser. Il semble vouloir me suivre.";

    static public string chienDocileAttaque1 = "AH ! Il m'a mordu !!";
    static public string chienDocileAttaque2 = "Je n'aurais jamais imaginé faire ça un jour.";

    static public string chienMechant1 = "Oh ! Un chien ! Il n'a pas l'air commode...";

    static public string chienMechantCaresse1 = "AH ! Il m'a mordu !!";
    static public string chienMechantAttaque1 = "Il l'a mérité.";

    ///PIECE SQUELETTE
    static public string squeletteQuestion = "Ce squelette porte une armure. peut-être qu'elle pourra m'être utile.";
    static public string squeletteRep2 = "Prendre l'armure";
    static public string squeletteRep1 = "Laisser l'armure";

    static public string squelettePrendre = "C'est humide et très usé... mais ça devrait suffir pour me protéger.";
    static public string squeletteLaisser = "Pas question que je touche à cette chose.";

    //TRESOR
    static public string tresorParTerre = "Il y a quelque chose par terre...";

    static public string tresorRep1 = "Prendre";
    static public string tresorRep2 = "Laisser";

    //Cristal
    static public string cristalTrouveDisabled =
        "Un imposant cristal rouge trône au milieu de la pièce. En m'approchant du cristal il me semble voir " +
        "un amas de chair remuer lentement en son centre.";

    static public string cristalTrouveEnabled =
        "J'ai déjà vu ce cristal. Mais je ne me souviens pas d'une lumière aussi intense...";

    static public string cristalToucheToEnable =
        "Ahh.. Ahh.. Ma tête... Je me sens... si faible...";

    static public string cristalToucheToDisable =
        "HHHHHHHH !! AH ! Je... Je me sens rajeunit !";

    static public string cristalRep1 = "Toucher";
    static public string cristalRep2 = "Ne pas toucher";

}
