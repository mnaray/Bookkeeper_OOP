﻿namespace Bookkeeper.Model
{
    public class Buchungssatz
    {
        private readonly int? _id;
        private string _buchungstetxt;
        private int _buchungsdatum; // Unix Timestamp
        private Konto _sollKonto;
        private Konto _habenKonto;
        private decimal _betrag;
        public int? Id { get { return _id; } }
        public string Buchungstext { get { return _buchungstetxt; } }
        public Konto SollKonto { get { return _sollKonto; } }
        public Konto HabenKonto { get { return _habenKonto; } }
        public decimal Betrag { get { return _betrag; } }

        public Buchungssatz(int? id, string buchungstext, Konto sollKonto,
            Konto habenKonto, decimal betrag)
        {
            _id = id;
            _buchungstetxt = buchungstext;
            _buchungsdatum = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            _sollKonto = sollKonto;
            _habenKonto = habenKonto;
            _betrag = betrag;
        }

        public void Ausfuehren()
        {
            throw new NotImplementedException();
        }
    }
}