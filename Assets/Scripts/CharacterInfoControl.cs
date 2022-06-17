using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInfoControl : MonoBehaviour
{
    public CanvasGroup hastaUi;
    public CanvasGroup dialogUi;
    public TMP_Text chracterName;
    public TMP_Text chracterHistory;
    public TMP_Text chracterHealth;
    public TMP_Text chracterExitDialog;
    public Button chracterDialog1;
    public Button chracterDialog2;
    public string chracterDialog1Exit;
    public string chracterDialog2Exit;
    public bool dialogSucces;
    public bool chracterDialog1Succes;
    public bool chracterDialog2Succes;
    public Image chracterIcon;
    public Sprite[] allImages;
    public float dialogShowTime = 5f;
    public CharacterInfoControl[] allCharacters=new CharacterInfoControl[2];
    string name, history, health, dialog1, dialog2, dialog1Exit, dialog2Exit;
    bool dialog1Succes, dialog2Succes;
    int index;
    int currentDialog=0;
     void Start()
    {

        allCharacters[0]=NewChracter("Hasta1", " Hasta ya�� 16. Hasta Kan Grubu A rh- .Hasta saat 11.30 gibi okula giderken.Kar��dan kar��ya ge�ereken son h�zla gelen araban�n alt�nda kald�.", "Hastan�n durumu giderek k�t�le�iyor Hastaya bir an �nce kan nakli yapmam�z ve bacag�n� koparmam�z gereketme. Hasta baccag� koptuktan sonra ag�r bir deprosyana girebilir karar�n ?","Karakterin bacag�n� kesmeliyiz ne olursa olsun ya�am �nemlidir","Hastan�n durumu �ok kotu bu durumdayken hastan�n bacag�n� kesersek kan kayb�ndan �lcek ailesi bildirip organ bag���na te�vik etmeliyiz","Hasta ameliyat esnans�nda �ld� ba�aramad�n","Hastan�n organlar� ba�ka bir beden i�in can oldu acaba durumu o kadar k�t�m�yd�",false,true,0);
        allCharacters[1] = NewChracter("Hasta2", " Hasta ya�� 56. Hasta Kan GrubuB rh- .Hasta saat  gece 4.30 gibi okula giderken.Kar��dan kar��ya ge�ereken son h�zla gelen araban�n alt�nda kald�.", "Hastan�n durumu giderek k�t�le�iyor Hastaya bir an �nce kan nakli yapmam�z ve bacag�n� koparmam�z gereketme. Hasta baccag� koptuktan sonra ag�r bir deprosyana girebilir karar�n ?", "Karakterin bacag�n� kesmeliyiz ne olursa olsun ya�am �nemlidir", "Hastan�n durumu �ok kotu bu durumdayken hastan�n bacag�n� kesersek kan kayb�ndan �lcek ailesi bildirip organ bag���na te�vik etmeliyiz", "Hasta ameliyat esnans�nda �ld� ba�aramad�n", "Hasta tedaviye reddeti ve baska bir hastaneye gidereken �ld�",false,false, 0);

        NextDialog();
    }
    CharacterInfoControl NewChracter(string _name,string _history,string _health,string _dialog1,string _dialog2,string _dialog1Exit,string _dialog2Exit,bool _dialog1Succes,bool _dialog2Succes, int _index)
    {
        name = _name;
        history = _history;
        health = _health;
        dialog1 = _dialog1;
        dialog2 = _dialog2;
        dialog1Exit = _dialog1Exit;
        dialog2Exit = _dialog2Exit;
        dialog1Succes = _dialog1Succes;
        dialog2Succes = _dialog2Succes;
        index = _index;
        return this;
    }
    public void Dialog1Button()
    {
        Debug.Log("Buton tiklama");
        DialogSet(chracterDialog1Exit);
        dialogSucces = chracterDialog1Succes;
    }
    public void Dialog2Button()
    {
        Debug.Log("Buton tiklama");
        DialogSet(chracterDialog2Exit);
        dialogSucces = chracterDialog2Succes;

    }
    void DialogSet(string value)
    {
        
        hastaUi.alpha = 0;
        dialogUi.alpha = 1;
        chracterExitDialog.text=value;
        Invoke("DialogExit",dialogShowTime);
    }
    void DialogExit()
    {
        hastaUi.alpha = 1;
        //hastaUi.alpha = 0;
        dialogUi.alpha = 0;
        //
        NextDialog();
    }
    void NextDialog()
    {
        if(currentDialog<allCharacters.Length)
        {
            allCharacters[currentDialog].ChracterGet();
            currentDialog++;
        }
    }
    void ChracterGet()
    {
        chracterName.text = name;
        chracterHistory.text = history;
        chracterHealth.text = health;
        chracterDialog1Exit = dialog1Exit;
        chracterDialog2Exit = dialog2Exit;
        chracterDialog1.GetComponentInChildren<TMP_Text>().text = dialog1;
        chracterDialog2.GetComponentInChildren<TMP_Text>().text = dialog2;
        chracterDialog1Succes = dialog1Succes;
        chracterDialog2Succes = dialog2Succes;
        chracterIcon.sprite = allImages[index];
        hastaUi.alpha = 1;
        dialogUi.alpha = 0;
    }
}
