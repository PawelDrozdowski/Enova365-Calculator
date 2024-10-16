using Rekrutacja.Workers.Enums;
using Soneta.Business;
using Soneta.Types;

namespace Rekrutacja.Workers.Template
{
    public partial class TemplateWorker
    {
        //Aby parametry działały prawidłowo dziedziczymy po klasie ContextBase
        public class Pkt3WorkerParametry : ContextBase
        {
            [Caption("A")]
            public string A { get; set; }
            [Caption("B")]
            public string B { get; set; }
            [Caption("Data obliczeń")]
            public Date DataObliczen { get; set; }
            [Caption("Figura")]
            public Figura Figura { get; set; }
            public Pkt3WorkerParametry(Context context) : base(context)
            {
                this.DataObliczen = Date.Today;
                this.Figura = Figura.Prostokąt;
            }
        }
    }
}