using System;
using System.Collections.Generic;
using System.Linq;


namespace Canil
{
    public class CalculaMenorPreco 
    {
        public DateTime data { get; set; }
        public int qtcaespequenos { get; set; }
        public int qtcaesgrandes { get; set; }
        public string diasemana { get; set; }
        private static List<CanilDados> dados;

        public string CalculaMelhorOferta() 
        {
            CarregaDados();

            return RetornaResultado();
        }
        private string RetornaResultado()
        {
            List<CanilTotalizador> precodia = (from d in dados
                                               where d.Dias.Contains(diasemana)
                                               select new CanilTotalizador(d.Canil, d.Distancia, (d.Pequeno * qtcaespequenos) + (d.Grande * qtcaesgrandes))).ToList();

            CanilTotalizador precodiafiltrado = (from p in precodia
                                                 orderby p.Total, p.Distancia descending
                                                 select p).FirstOrDefault();

            return (precodiafiltrado.Canil + "  R$ " + precodiafiltrado.Total.ToString("####0.00"));
        }

        private void CarregaDados()
        {
            string json = System.IO.File.ReadAllText("dados.json");
            dados = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CanilDados>>(json);
        }

    }
}
