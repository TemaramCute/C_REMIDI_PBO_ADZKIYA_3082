using System;
using System.Collections.Generic;

class Nasabah
{
    public string Nama;
    public string NoRekening;
    public double Saldo;

    public Nasabah(string nama, string noRekening, double saldo)
    {
        Nama = nama;
        NoRekening = noRekening;
        Saldo = saldo;
    }

    public void TampilkanData()
    {
        Console.WriteLine($"Nama: {Nama}, No Rekening: {NoRekening}, Saldo: {Saldo}");
    }
}

class BankPelita
{
    List<Nasabah> daftarNasabah = new List<Nasabah>();

    public void TambahNasabah()
    {
        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan No Rekening: ");
        string norek = Console.ReadLine();

        Console.Write("Masukkan Saldo Awal: ");
        double saldo = Convert.ToDouble(Console.ReadLine());

        Nasabah n = new Nasabah(nama, norek, saldo);
        daftarNasabah.Add(n);

        Console.WriteLine("Nasabah berhasil ditambahkan.\n");
    }

    public void TampilkanSemuaNasabah()
    {
        if (daftarNasabah.Count == 0)
        {
            Console.WriteLine("Belum ada data nasabah.\n");
            return;
        }

        Console.WriteLine("== Data Semua Nasabah ==");
        foreach (Nasabah n in daftarNasabah)
        {
            n.TampilkanData();
        }
        Console.WriteLine();
    }

    public void TampilkanNasabahByRekening()
    {
        Console.Write("Masukkan No Rekening: ");
        string cari = Console.ReadLine();

        bool ditemukan = false;

        foreach (Nasabah n in daftarNasabah)
        {
            if (n.NoRekening == cari)
            {
                n.TampilkanData();
                ditemukan = true;
                break;
            }
        }

        if (!ditemukan)
        {
            Console.WriteLine("Data tidak ditemukan.\n");
        }
    }

    public void Menabung()
    {
        Console.Write("Masukkan No Rekening: ");
        string cari = Console.ReadLine();

        foreach (Nasabah n in daftarNasabah)
        {
            if (n.NoRekening == cari)
            {
                Console.Write("Masukkan jumlah tabungan: ");
                double tambah = Convert.ToDouble(Console.ReadLine());
                n.Saldo += tambah;
                Console.WriteLine("Tabungan berhasil ditambahkan.\n");
                return;
            }
        }

        Console.WriteLine("Data tidak ditemukan.\n");
    }

    public void TarikUang()
    {
        Console.Write("Masukkan No Rekening: ");
        string cari = Console.ReadLine();

        foreach (Nasabah n in daftarNasabah)
        {
            if (n.NoRekening == cari)
            {
                Console.Write("Masukkan jumlah tarik tunai: ");
                double tarik = Convert.ToDouble(Console.ReadLine());

                if (tarik > n.Saldo)
                {
                    Console.WriteLine("Saldo tidak cukup.\n");
                }
                else
                {
                    n.Saldo -= tarik;
                    Console.WriteLine("Tarik tunai berhasil.\n");
                }

                return;
            }
        }

        Console.WriteLine("Data tidak ditemukan.\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankPelita bank = new BankPelita();
        int pilihan;

        do
        {
            Console.WriteLine("=== Sistem Layanan Digital Bank Pelita ===");
            Console.WriteLine("1. Tambah Nasabah");
            Console.WriteLine("2. Tampilkan Semua Nasabah");
            Console.WriteLine("3. Tampilkan Nasabah Berdasarkan No Rekening");
            Console.WriteLine("4. Menabung");
            Console.WriteLine("5. Tarik Uang");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih menu (1-6): ");
            pilihan = Convert.ToInt32(Console.ReadLine());

            switch (pilihan)
            {
                case 1:
                    bank.TambahNasabah();
                    break;
                case 2:
                    bank.TampilkanSemuaNasabah();
                    break;
                case 3:
                    bank.TampilkanNasabahByRekening();
                    break;
                case 4:
                    bank.Menabung();
                    break;
                case 5:
                    bank.TarikUang();
                    break;
                case 6:
                    Console.WriteLine("Terima kasih karena telah menggunakan layanan Bank Pelita.");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid!\n");
                    break;
            }

        } while (pilihan != 6);
    }
}