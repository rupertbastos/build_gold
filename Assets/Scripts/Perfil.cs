﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfil{

    public string nome;
    public Sprite imagem;
    public Color cor;
    public int xp, level, limite, vidas;
    public int moedas, cristais, estrelas;

    public Perfil(string n, Sprite img, Color c)
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

}