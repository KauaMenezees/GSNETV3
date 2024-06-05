namespace GSNETV3.Models {
    public class ItemLixeira {

        public int ItemLixeiraId { get; set; }
        public string ItemTipo { get; set; } 
        public int PontosGanhos { get; set; } 
        public int LixeiraId { get; set; } 
        public Lixeira Lixeira { get; set; } 

    }
}
