using Rekrutacja.Workers.Enums;
using Soneta.Business;
using Soneta.Types;

namespace Rekrutacja.Workers.Template
{
    public partial class TemplateWorker
    {
        //Aby parametry działały prawidłowo dziedziczymy po klasie ContextBase
        public class Pkt2WorkerParametry : ContextBase
        {
            [Caption("A")]
            public int A { get; set; }
            [Caption("B")]
            public int B { get; set; }
            [Caption("Data obliczeń")]
            public Date DataObliczen { get; set; }
            [Caption("Figura")]
            public Figura Figura { get; set; }
            public Pkt2WorkerParametry(Context context) : base(context)
            {
                this.DataObliczen = Date.Today;
                this.Figura = Figura.Prostokąt;
            }
        }
    }
}