﻿namespace api_dev_week.src.Models
{
    public class Contract
    {
        public Contract()
        {
            this.DateCreate = DateTime.Now;
            this.Valor = 0;
            this.TokenId = "00000";
            this.Paid = false;
        }
        public Contract(string TokenID, double Valor)
        {
            this.DateCreate = DateTime.Now;
            this.TokenId = TokenID;
            this.Valor = Valor;
        }
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string TokenId { get; set; }
        public double Valor { get; set; }
        public bool Paid { get; set; }
        public int PersonId { get; set; }

    }
}
