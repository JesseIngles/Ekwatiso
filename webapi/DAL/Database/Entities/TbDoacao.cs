namespace webapi.DAL.Database.Entities
{
    public class TbDoacao
    {
        public long Id { get; set; }
        public virtual TbUser Doador { get; set; }
        public virtual TbCampanha Campanha { get; set; }
        public decimal Quantia { get; set; }
        public DateTime Data { get; set; }
        public bool Confirmado { get; set; }

    }
}