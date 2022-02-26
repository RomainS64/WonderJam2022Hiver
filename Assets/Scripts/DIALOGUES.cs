using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class DIALOGUES
{
    ///PIECE VIDE
    static public string pieceVide = "Cette piece est vide... Je ne m'y sens pas tr�s � l'aise...";

    ///PIECE DU CHIEN
    static public string chienDocile1 = "Oh ! Un chien ! Il semble plut�t amical.";

    static public string chienDocileCaresse1 = "�a fait vraiment du bien de le caresser.";
    static public string chienDocileCaresse2 = "�a fait vraiment du bien de le caresser. Il semble vouloir me suivre.";

    static public string chienDocileAttaque1 = "AH ! Il m'a mordu !!";
    static public string chienDocileAttaque2 = "Je n'aurais jamais imagin� faire �a un jour.";

    static public string chienMechant1 = "Oh ! Un chien ! Il n'a pas l'air commode...";

    static public string chienMechantCaresse1 = "AH ! Il m'a mordu !!";
    static public string chienMechantAttaque1 = "Il l'a m�rit�.";

    ///PIECE SQUELETTE
    static public string squeletteQuestion = "Ce squelette porte une armure. peut-�tre qu'elle pourra m'�tre utile.";
    static public string squeletteRep1 = "Prendre l'armure";
    static public string squeletteRep2 = "Laisser l'armure";

    static public string squelettePrendre = "C'est humide et tr�s us�... mais �a devrait suffir pour me prot�ger.";
    static public string squeletteLaisser = "Pas question que je touche � cette chose.";

    //TRESOR
    static public string tresorParTerre = "Il y a quelque chose par terre...";

    static public string tresorRep1 = "Prendre";
    static public string tresorRep2 = "Laisser";

    //Cristal
    static public string cristalTrouveDisabled =
        "Un imposant cristal rouge tr�ne au milieu de la pi�ce. En m'approchant du cristal il me semble voir " +
        "un amas de chair remuer lentement en son centre.";

    static public string cristalTrouveEnabled =
        "J'ai d�j� vu ce cristal. Mais je ne me souviens pas d'une lumi�re aussi intense...";

    static public string cristalToucheToEnable =
        "Ahh.. Ahh.. Ma t�te... Je me sens... si faible...";

    static public string cristalToucheToDisable =
        "HHHHHHHH !! AH ! Je... Je me sens rajeunit !";

    static public string cristalRep1 = "Toucher";
    static public string cristalRep2 = "Ne pas toucher";

}
