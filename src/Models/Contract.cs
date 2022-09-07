namespace api_dev_week.src.Models
{
    public class Contract
    {
        public Contract()
        {
            this.DateCreate = DateTime.Now;
            this.Valor = 0;
            this.TokenId = "00000";
        }
        public Contract(string TokenID, double Valor)
        {
            this.DateCreate = DateTime.Now;
            this.TokenId = TokenID;
            this.Valor = Valor;
        }

        public DateTime DateCreate { get; set; }
        public string TokenId { get; set; }
        public double Valor { get; set; }

    }
}
