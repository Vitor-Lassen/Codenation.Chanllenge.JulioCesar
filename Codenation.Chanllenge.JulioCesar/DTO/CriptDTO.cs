using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Models
{
    public class CriptDTO
    {
        [JsonProperty("numero_casas")]
        public int Key { get; set; }
        
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [JsonProperty("cifrado")]
        public string TextCript { get; set; }
        
        [JsonProperty("decifrado")]
        public string Textdecript { get; set; }
        
        [JsonProperty("resumo_criptografico")]
        public string ResumoCript { get; set; }

    }
}
