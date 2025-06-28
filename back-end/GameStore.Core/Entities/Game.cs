using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Entities
{
    public class Game
    {
        public virtual int Id { get; protected set; }
        public virtual string Titulo { get; set; }
        public virtual string Plataforma { get; set; }
        public virtual string Categoria { get; set; }
        public virtual int? AnoLancamento { get; set; }
        public virtual decimal? PrecoVenda { get; set; }
        public virtual decimal? PrecoAluguel { get; set; }
        public virtual int QuantidadeEstoque { get; set; }
        public virtual string CapaUrl { get; set; }
    }
}
