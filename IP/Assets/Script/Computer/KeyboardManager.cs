using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    static string letter;
    static string num;

    public CursorRaycast CursorOne;
    public CusorRaycastTwo CusorTwo;

    [Header("Text Input")]
    public TMP_InputField[] textField;

    [Header("UnCap Alpha")]
    public Button a;
    public Button b;
    public Button c;
    public Button d;
    public Button e;
    public Button f;
    public Button g;
    public Button h;
    public Button i;
    public Button j;
    public Button k;
    public Button l;
    public Button m;
    public Button n;
    public Button o;
    public Button p;
    public Button q;
    public Button r;
    public Button s;
    public Button t;
    public Button u;
    public Button v;
    public Button w;
    public Button x;
    public Button y;
    public Button z;

    [Header("Caps Alpha")]
    public Button A;
    public Button B;
    public Button C;
    public Button D;
    public Button E;
    public Button F;
    public Button G;
    public Button H;
    public Button I;
    public Button J;
    public Button K;
    public Button L;
    public Button M;
    public Button N;
    public Button O;
    public Button P;
    public Button Q;
    public Button R;
    public Button S;
    public Button T;
    public Button U;
    public Button V;
    public Button W;
    public Button X;
    public Button Y;
    public Button Z;

    [Header("Symbols and Numbers")]
    public Button NumOne;
    public Button NumTwo;
    public Button NumThree;
    public Button NumFour;
    public Button NumFive;
    public Button NumSix;
    public Button NumSeven;
    public Button NumEight;
    public Button NumNine;
    public Button NumZero;

    public Button At;
    public Button Hash;
    public Button Dollar;
    public Button UnderScore;
    public Button And;
    public Button Minus;
    public Button Plus;
    public Button LeftBracket;
    public Button RightBracket;
    public Button Asterisk;
    public Button DoubleQuote;
    public Button SingleQuote;
    public Button Colon;
    public Button SimiColon;
    public Button ExaclaimationMark;
    public Button QuestionMark;

    private void Awake()
    {
        CursorOne.GetComponent<CursorRaycast>();
        CusorTwo.GetComponent<CusorRaycastTwo>();
    }

    private void Start()
    {
        // Uncap Alpha Button
        a.onClick.AddListener(AInput);
        b.onClick.AddListener(BInput);
        c.onClick.AddListener(CInput);
        d.onClick.AddListener(DInput);
        e.onClick.AddListener(EInput);
        f.onClick.AddListener(FInput);
        g.onClick.AddListener(GInput);
        h.onClick.AddListener(HInput);
        i.onClick.AddListener(IInput);
        j.onClick.AddListener(JInput);
        k.onClick.AddListener(KInput);
        l.onClick.AddListener(LInput);
        m.onClick.AddListener(MInput);
        n.onClick.AddListener(NInput);
        o.onClick.AddListener(OInput);
        p.onClick.AddListener(PInput);
        q.onClick.AddListener(QInput);
        r.onClick.AddListener(RInput);
        s.onClick.AddListener(SInput);
        t.onClick.AddListener(TInput);
        u.onClick.AddListener(UInput);
        v.onClick.AddListener(VInput);
        w.onClick.AddListener(WInput);
        x.onClick.AddListener(XInput);
        y.onClick.AddListener(YInput);
        z.onClick.AddListener(ZInput);
        
        // Caps Alpha Buttons
        A.onClick.AddListener(AInputCaps);
        B.onClick.AddListener(BInputCaps);
        C.onClick.AddListener(CInputCaps);
        D.onClick.AddListener(DInputCaps);
        E.onClick.AddListener(EInputCaps);
        F.onClick.AddListener(FInputCaps);
        G.onClick.AddListener(GInputCaps);
        H.onClick.AddListener(HInputCaps);
        I.onClick.AddListener(IInputCaps);
        J.onClick.AddListener(JInputCaps);
        K.onClick.AddListener(KInputCaps);
        L.onClick.AddListener(LInputCaps);
        M.onClick.AddListener(MInputCaps);
        N.onClick.AddListener(NInputCaps);
        O.onClick.AddListener(OInputCaps);
        P.onClick.AddListener(PInputCaps);
        Q.onClick.AddListener(QInputCaps);
        R.onClick.AddListener(RInputCaps);
        S.onClick.AddListener(SInputCaps);
        T.onClick.AddListener(TInputCaps);
        U.onClick.AddListener(UInputCaps);
        V.onClick.AddListener(VInputCaps);
        W.onClick.AddListener(WInputCaps);
        X.onClick.AddListener(XInputCaps);
        Y.onClick.AddListener(YInputCaps);
        Z.onClick.AddListener(ZInputCaps);

        // Symbol & Number Buttons
        NumOne.onClick.AddListener(One);
        NumTwo.onClick.AddListener(Two);
        NumThree.onClick.AddListener(Three);
        NumFour.onClick.AddListener(Four);
        NumFive.onClick.AddListener(Five);
        NumSix.onClick.AddListener(Six);
        NumSeven.onClick.AddListener(Seven);
        NumEight.onClick.AddListener(Eight);
        NumNine.onClick.AddListener(Nine);
        NumZero.onClick.AddListener(Zero);

        At.onClick.AddListener(at);
        Hash.onClick.AddListener(hash);
        Dollar.onClick.AddListener(dollar);
        UnderScore.onClick.AddListener(underScore);
        And.onClick.AddListener(and);
        Minus.onClick.AddListener(minus);
        Plus.onClick.AddListener(plus);
        LeftBracket.onClick.AddListener(leftBracket);
        RightBracket.onClick.AddListener(rightBracket);
        Asterisk.onClick.AddListener(aterisk);
        DoubleQuote.onClick.AddListener(doubleQuote);
        SingleQuote.onClick.AddListener(singleQuote);
        Colon.onClick.AddListener(colon);
        SimiColon.onClick.AddListener(semiColon);
        ExaclaimationMark.onClick.AddListener(exaclaimationMark);
        QuestionMark.onClick.AddListener(questionMark);
    }


    // Number Row Function
    public void One()
    {
        num = "1";


        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
        
    }

    public void Two()
    {
        num = "2";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }

    public void Three()
    {
        num = "3";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }

    public void Four()
    {
        num = "4";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }

    public void Five()
    {
        num = "5";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }

    public void Six()
    {
        num = "6";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }

    public void Seven()
    {
        num = "7";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }

    public void Eight()
    {
        num = "8";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }

    public void Nine()
    {
        num = "9";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }

    public void Zero()
    {
        num = "0";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += num.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += num.ToString();
        }
    }


    // Alpha Row Function
    public void AInput()
    {
        
        letter = "a";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void BInput()
    {
        letter = "b";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void CInput()
    {
        letter = "c";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void DInput()
    {
        letter = "d";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void EInput()
    {
        letter = "e";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void FInput()
    {
        letter = "f";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void GInput()
    {
        letter = "g";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void HInput()
    {
        letter = "h";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void IInput()
    {
        letter = "i";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void JInput()
    {
        letter = "j";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void KInput()
    {
        letter = "k";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void LInput()
    {
        letter = "l";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void MInput()
    {
        letter = "m";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void NInput()
    {
        letter = "n";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void OInput()
    {
        letter = "o";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void PInput()
    {
        letter = "p";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void QInput()
    {
        letter = "q";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void RInput()
    {
        letter = "r";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void SInput()
    {
        letter = "s";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void TInput()
    {
        letter = "t";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void UInput()
    {
        letter = "u";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void VInput()
    {
        letter = "v";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void WInput()
    {
        letter = "w";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void XInput()
    {
        letter = "x";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void YInput()
    {
        letter = "y";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void ZInput()
    {
        letter = "z";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    // Caps Alpha Row Function
    public void AInputCaps()
    {

        letter = "A";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void BInputCaps()
    {
        letter = "B";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void CInputCaps()
    {
        letter = "C";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void DInputCaps()
    {
        letter = "D";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void EInputCaps()
    {
        letter = "E";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void FInputCaps()
    {
        letter = "F";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void GInputCaps()
    {
        letter = "G";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void HInputCaps()
    {
        letter = "H";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void IInputCaps()
    {
        letter = "I";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void JInputCaps()
    {
        letter = "J";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void KInputCaps()
    {
        letter = "K";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void LInputCaps()
    {
        letter = "L";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void MInputCaps()
    {
        letter = "M";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void NInputCaps()
    {
        letter = "N";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void OInputCaps()
    {
        letter = "O";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void PInputCaps()
    {
        letter = "P";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void QInputCaps()
    {
        letter = "Q";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void RInputCaps()
    {
        letter = "R";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void SInputCaps()
    {
        letter = "S";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void TInputCaps()
    {
        letter = "T";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void UInputCaps()
    {
        letter = "U";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void VInputCaps()
    {
        letter = "V";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void WInputCaps()
    {
        letter = "W";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void XInputCaps()
    {
        letter = "X";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void YInputCaps()
    {
        letter = "Y";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void ZInputCaps()
    {
        letter = "Z";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void BackInput()
    {
        if (CursorOne.triggerEnter == true)
        {
            textField[0].text = textField[0].text.Remove(textField[0].text.Length - 1, 1);
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text = textField[1].text.Remove(textField[1].text.Length - 1, 1);
        }
        //textField.GetComponentInChildren<TMP_InputField>().text = textField.GetComponentInChildren<TMP_InputField>().text.Remove(textField.GetComponentInChildren<TMP_InputField>().text.Length - 1, 1);
    }

    // Symbol Function

    public void at()
    {
        letter = "@";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void hash()
    {
        letter = "#";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void dollar()
    {
        letter = "$";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void underScore()
    {
        letter = "_";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void and()
    {
        letter = "&";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void minus()
    {
        letter = "-";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void plus() 
    {
        letter = "+";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void leftBracket()
    {
        letter = "(";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void rightBracket()
    {
        letter = ")";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void aterisk()
    {
        letter = ".";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void doubleQuote()
    {
        letter = "\"";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void singleQuote()
    {
        letter = "'";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void colon()
    {
        letter = ":";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void semiColon()
    {
        letter = ";";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void exaclaimationMark()
    {
        letter = "!";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text += letter.ToString();
        }
    }

    public void questionMark()
    {
        letter = "?";

        if (CursorOne.triggerEnter == true)
        {
            textField[0].text += letter.ToString();
        }
        else if (CusorTwo.triggerEnter == true)
        {
            textField[1].text = letter.ToString();
        }
    }
}