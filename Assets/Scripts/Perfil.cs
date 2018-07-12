using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Perfil {

    public string nome;

    public Sprite imagem, spI, spP;
    public Color cor;
    public int xp, level, limite, vidas;
    public int moedas, cristais, estrelas, corNumber;
    public MundoPlayer mundoAtual;
    public FasePlayer faseAtual;
    public int[] fase_1_1, fase_1_2, fase_1_3, fase_1_4, fase_1_5;



    public Perfil(string n, Sprite img, Color c, Sprite i, Sprite p, int cor)
    {
        SetNome(n);
        SetImagem(img);
        SetColor(c);
        SetXp(0);
        SetLevel(1);
        SetLimite(500);
        SetVidas(4);
        SetMoedas(0);
        SetCristais(0);
        SetEstrelas(0);
        SetSpI(i);
        SetSpP(p);
        SetCorNumber(cor);
        fase_1_1 = new int[3];
        SalvaFases(1, 1, 0, 0, 0);
        fase_1_2 = new int[3];
        SalvaFases(1, 2, -1, -1, -1);
        fase_1_3 = new int[3];
        SalvaFases(1, 3, -1, -1, -1);
        fase_1_4 = new int[3];
        SalvaFases(1, 4, -1, -1, -1);
        fase_1_5 = new int[3];
        SalvaFases(1, 5, -1, -1, -1);
        mundoAtual = MundoPlayer.Madeira;
        faseAtual = FasePlayer.Um;
    }

    public Perfil(string n, Sprite img, Color c, int xp, int level, int limite, int vidas, int moedas, int cristais,
        int estrelas, Sprite i, Sprite p, int cor, MundoPlayer ma, FasePlayer fp, int[] fase11, int[] fase12, int[] fase13, int[] fase14, int[] fase15)
    {
        SetNome(n);
        SetImagem(img);
        SetColor(c);
        SetXp(xp);
        SetLevel(level);
        SetLimite(limite);
        SetVidas(vidas);
        SetMoedas(moedas);
        SetCristais(cristais);
        SetEstrelas(estrelas);
        SetSpI(i);
        SetSpP(p);
        SetCorNumber(cor);
        fase_1_1 = fase11;
        fase_1_2 = fase12;
        fase_1_3 = fase13;
        fase_1_4 = fase14;
        fase_1_5 = fase15;
    }

    public void SalvaFases(int i, int j, int moed, int crist, int complet)
    {
        switch (i)
        {
            case 1:
                {
                    switch (j)
                    {
                        case 1:
                            {
                                fase_1_1[0] = complet;
                                fase_1_1[1] = moed;
                                fase_1_1[2] = crist;
                                break;
                            }
                        case 2:
                            {
                                fase_1_2[0] = complet;
                                fase_1_2[1] = moed;
                                fase_1_2[2] = crist;
                                break;
                            }
                        case 3:
                            {
                                fase_1_3[0] = complet;
                                fase_1_3[1] = moed;
                                fase_1_3[2] = crist;
                                break;
                            }
                        case 4:
                            {
                                fase_1_4[0] = complet;
                                fase_1_4[1] = moed;
                                fase_1_4[2] = crist;
                                break;
                            }
                        case 5:
                            {
                                fase_1_5[0] = complet;
                                fase_1_5[1] = moed;
                                fase_1_5[2] = crist;
                                break;
                            }
                        default:
                            {
                                Debug.LogWarning("Erro ao salvar a fase");
                                break;
                            }
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    public MundoPlayer GetMundoPlayer()
    {
        return mundoAtual;
    }

    public void SetMundoPlayer(MundoPlayer mp)
    {
        mundoAtual = mp;
    }

    public FasePlayer GetFasePlayer()
    {
        return faseAtual;
    }

    public void SetFasePlayer(FasePlayer fp)
    {
        faseAtual = fp;
    }

    public int[] GetFase_1_1()
    {
        return fase_1_1;
    }

    public int[] GetFase_1_2()
    {
        return fase_1_2;
    }

    public int[] GetFase_1_3()
    {
        return fase_1_3;
    }

    public int[] GetFase_1_4()
    {
        return fase_1_4;
    }

    public int[] GetFase_1_5()
    {
        return fase_1_5;
    }

    private void SetCorNumber(int c)
    {
        corNumber = c;
    }

    private void SetEstrelas(int e)
    {
        estrelas = e;
    }

    private void SetCristais(int c)
    {
        cristais = c;
    }

    private void SetMoedas(int m)
    {
        moedas = m;
    }

    private void SetVidas(int v)
    {
        vidas = v;
    }

    private void SetLimite(int l)
    {
        limite = l;
    }

    private void SetLevel(int l)
    {
        level = l;
    }

    private void SetXp(int x)
    {
        xp = x;
    }

    private void SetColor(Color c)
    {
        cor = c;
    }

    private void SetImagem(Sprite img)
    {
        imagem = img;
    }

    private void SetSpI(Sprite i)
    {
        spI = i;
    }

    private void SetSpP(Sprite p)
    {
        spP = p;
    }

    private void SetNome(string n)
    {
        nome = n.ToUpper();
    }

    public string GetNome()
    {
        return nome;
    }
    
    public Sprite GetImagem()
    {
        return imagem;
    }

    public Sprite GetSpI()
    {
        return spI;
    }

    public Sprite GetSpP()
    {
        return spP;
    }

    public int GetCorNumber()
    {
        return corNumber;
    }

    public int GetXp()
    {
        return xp;
    }

    public Color GetCor()
    {
        return cor;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetLimite()
    {
        return limite;
    }

    public int GetVidas()
    {
        return vidas;
    }

    public int GetEstrelas()
    {
        return estrelas;
    }

    public int GetCristais()
    {
        return cristais;
    }

    public int GetMoedas()
    {
        return moedas;
    }

    public void AumentaXp(int val)
    {
        xp += val;

        if(xp >= limite)
        {
            AumentaLevel();
            limite += limite; 
        }
    }

    private void AumentaLevel()
    {
        level += 1;
    }

    public void AumentaVidas()
    {
        if (vidas < 4)
        { 
            vidas++;
        }
    }

    public void DiminuiVida()
    {
        if(vidas > 1)
        {
            vidas--;
        }
    }

    public void RenovaVidas()
    {
        vidas = 4;
    }

}

[Serializable]
public enum MundoPlayer
{
    Madeira,
    Concreto,
    Jade,
    Gelo
}

[Serializable]
public enum FasePlayer
{
    Um,
    Dois,
    Tres,
    Quatro,
    Cinco
}