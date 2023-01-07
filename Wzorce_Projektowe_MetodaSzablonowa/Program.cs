using System;

abstract class ZamowienieTemplatka
{
    protected static bool _czyGratis;

    abstract public void DoKoszyk();
    abstract public void DoDostawa();
    abstract public void DoPlatnosc();
    protected static void DodanieGratisu() => Console.WriteLine("Dodano gratis...");

    public void PrzetwarzajZamowienie(bool czyGratis)
    {
        _czyGratis = czyGratis;
        DoKoszyk();
        DoPlatnosc();
        DoDostawa();
    }
}

internal class ZamowienieStacjonarne : ZamowienieTemplatka
{
    override public void DoKoszyk() => Console.WriteLine("Wybranie produktów...");

    override public void DoPlatnosc()
    {
        Console.WriteLine("Płatność w kasie (karta/gotówka)...");
        if (_czyGratis)
            DodanieGratisu();
    }

    override public void DoDostawa() => Console.WriteLine("Wydanie produktów (odbiór osobisty)...");
}

class ZamowienieOnline : ZamowienieTemplatka
{
    override public void DoKoszyk()
    {
        Console.WriteLine("Kompletowanie zamówienia...");
        Console.WriteLine("Ustawiono parametry wysyłki...");
    }

    override public void DoPlatnosc()
    {
        Console.WriteLine("Płatność...");
        if (_czyGratis)
            DodanieGratisu();
    }

    override public void DoDostawa() => Console.WriteLine("Wysyłka...");
}


class Program
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ZamowienieTemplatka zamowienieOnline = new ZamowienieOnline();
        zamowienieOnline.przetwarzajZamowienie(true);

        Console.WriteLine();

        ZamowienieTemplatka zamowienieStacjonarne = new ZamowienieStacjonarne();
        zamowienieStacjonarne.przetwarzajZamowienie(false);

    }
}