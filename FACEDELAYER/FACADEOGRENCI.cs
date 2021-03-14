﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ENTITYLAYER;

namespace FACEDELAYER
{
    public class FACADEOGRENCI
    {
        public static int EKLE(ENTITYOGRENCI deger)
        {
            SqlCommand komut = new SqlCommand("OGRENCIEKLE", SQLBAGLANTISI.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if(komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("ADI", deger.AD);
            komut.Parameters.AddWithValue("SOYAD", deger.SOYAD);
            komut.Parameters.AddWithValue("FOTOGRAF", deger.FOTOGRAF);
            komut.Parameters.AddWithValue("KULUPID", deger.KULUPID);

            return komut.ExecuteNonQuery();
        }

        public static bool SIL(int deger)
        {
            SqlCommand komut = new SqlCommand("OGRENCISIL", SQLBAGLANTISI.Baglanti);
            
            if(komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("ID", deger);
            return komut.ExecuteNonQuery() > 0;
        }

        public static bool GUNCELLE(ENTITYOGRENCI deger)
        {
            SqlCommand komut = new SqlCommand("OGRENCIGUNCELLE", SQLBAGLANTISI.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("AD", deger.AD);
            komut.Parameters.AddWithValue("SOYAD", deger.SOYAD);
            komut.Parameters.AddWithValue("FOTOGRAF", deger.FOTOGRAF);
            komut.Parameters.AddWithValue("KULUPID", deger.KULUPID);
            komut.Parameters.AddWithValue("ID", deger.ID);

            return komut.ExecuteNonQuery() > 0;

        }

        public static List<ENTITYOGRENCI> OGRENCILISTESI()
        {
            List<ENTITYOGRENCI> degerler = new List<ENTITYOGRENCI>();

            SqlCommand komut = new SqlCommand("OGRENCILISTESI", SQLBAGLANTISI.Baglanti);

            if(komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            SqlDataReader dr = komut.ExecuteReader();

            while(dr.Read())
            {
                ENTITYOGRENCI ent = new ENTITYOGRENCI();
                ent.AD = dr["AD"].ToString();
                ent.SOYAD = dr["SOYAD"].ToString();
                ent.FOTOGRAF = dr["FOTOGRAF"].ToString();
                ent.KULUPID = Convert.ToInt16(dr["KULUPID"]);
                ent.ID = Convert.ToInt16(dr["ID"]);

                degerler.Add(ent);
            }
            dr.Close();

            return degerler;

        }
    }
}
