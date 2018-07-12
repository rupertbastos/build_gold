using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Perfil {

    public string nome;

    public Sprite imagem, spI, spP;
    public int imagemNumero, spINumero, spPNumero;
    public Color cor;
    public int xp, level, limite, vidas;
    public int moedas, cristais, estrelas, corNumber;
    public MundoPlayer mundoAtual;
    public FasePlayer faseAtual;

    

    public int[] fase_1_1, fase_1_2, fase_1_3, fase_1_4, fase_1_5;

    public Sprite GetImagemSprite(int i)
    {
        Sprite imag = null;
        switch (i)
        {
            case 1:
                {
                    imag = GameController.instance.imagem1;
                    break;
                }
            case 2:
                {
                    imag = GameController.instance.imagem2;
                    break;
                }
            case 3:
                {
                    imag = GameController.instance.imagem3;
                    break;
                }
            case 4:
                {
                    imag = GameController.instance.imagem4;
                    break;
                }
            case 5:
                {
                    imag = GameController.instance.imagem5;
                    break;
                }
            case 6:
                {
                    imag = GameController.instance.imagem6;
                    break;
                }
            default:
                {
                    imag = GameController.instance.imagem1;
                    break;
                }
        }
        return imag;
    }

    public Sprite GetSpISprite(int i)
    {
        Sprite spi;
        switch (i)
        {
            case 1:
                {
                    spi = GameController.instance.spI1;
                    break;
                }
            case 2:
                {
                    spi = GameController.instance.spI2;
                    break;
                }
            case 3:
                {
                    spi = GameController.instance.spI3;
                    break;
                }
            case 4:
                {
                    spi = GameController.instance.spI4;
                    break;
                }
            case 5:
                {
                    spi = GameController.instance.spI5;
                    break;
                }
            case 6:
                {
                    spi = GameController.instance.spI6;
                    break;
                }
            default:
                {
                    spi = GameController.instance.spI1;
                    break;
                }
        }
        return spi;
    }

    public Sprite GetSpPSprite(int i)
    {
        Sprite spp;
        switch (i)
        {
            case 1:
                {
                    spp = GameController.instance.spP1;
                    break;
                }
            case 2:
                {
                    spp = GameController.instance.spP2;
                    break;
                }
            case 3:
                {
                    spp = GameController.instance.spP3;
                    break;
                }
            case 4:
                {
                    spp = GameController.instance.spP4;
                    break;
                }
            case 5:
                {
                    spp = GameController.instance.spP5;
                    break;
                }
            case 6:
                {
                    spp = GameController.instance.spP6;
                    break;
                }
            default:
                {
                    spp = GameController.instance.spP1;
                    break;
                }
        }
        return spp;
    }


    public Perfil(string n, int img, Color c, int i, int p, int cor)
    {
        SetNome(n);
        SetImagemNumero(img);
        imagem = GetImagemSprite(img);
        SetColor(c);
        SetXp(0);
        SetLevel(1);
        SetLimite(500);
        SetVidas(4);
        SetMoedas(0);
        SetCristais(0);
        SetEstrelas(0);
        SetSpINumero(i);
        spI = GetSpISprite(i);
        SetSpPNumero(p);
        spP = GetSpPSprite(p);
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

    public Perfil(string n, int img, Color c, int xp, int level, int limite, int vidas, int moedas, int cristais,
        int estrelas, int i, int p, int cor, MundoPlayer ma, FasePlayer fp, int[] fase11, int[] fase12, int[] fase13, int[] fase14, int[] fase15)
    {
        SetNome(n);
        imagem = GetImagemSprite(img);
        SetColor(c);
        SetXp(xp);
        SetLevel(level);
        SetLimite(limite);
        SetVidas(vidas);
        SetMoedas(moedas);
        SetCristais(cristais);
        SetEstrelas(estrelas);
        spI = GetSpISprite(i);
        spP = GetSpPSprite(p);
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

    public int GetImagemNumero()
    {
        return imagemNumero;
    }

    public int GetSpINumero()
    {
        return spINumero;
    }

    public int GetSpPNumero()
    {
        return spPNumero;
    }

    public void SetImagemNumero(int inu)
    {
        imagemNumero = inu;
    }

    public void SetSpINumero(int sn)
    {
        spINumero = sn;
    }

    public void SetSpPNumero(int sn)
    {
        spPNumero = sn;
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