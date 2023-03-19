using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StringHelper
{
    public static class Matcher
    {
        /*
         *  Busca la mejor coincidencia de una cadena en una lista de cadenas.
         */
        public static string BuscarMejor(string cadenaBuscada, IEnumerable<string> cadenas)
        {
            var busquedaExacta = BusquedaExacta(cadenaBuscada, cadenas);
            if (busquedaExacta != null) return busquedaExacta;

            var busquedaPorProbabilidad = BusquedaPorProbabilidad(cadenaBuscada, cadenas);
            if (busquedaPorProbabilidad != null) return busquedaPorProbabilidad;

            return null;
        }

        /*
         *  Busca la cadena exacta en una lista de cadenas.
         *  Devuelve null si no la encuentra.
         */
        public static string BusquedaExacta(string cadenaBuscada, IEnumerable<string> cadenas)
        {
            if (cadenas == null) return null;
            cadenaBuscada = Normalizar(cadenaBuscada);
            foreach (var cadena in cadenas)
            {
                if (Normalizar(cadena) == cadenaBuscada) return cadena;
            }
            return null;
        }

        /*
         *  Busca una cadena en una lista de cadenas asignandole una probabilidad. 
         *  Devuelve la de mayor probabilidad, es decir la que mayor coincidencia de secuencias tiene.
         */
        public static string BusquedaPorProbabilidad(string cadenaBuscada, IEnumerable<string> cadenas)
        {
            if(cadenas == null) return null;
            cadenaBuscada = Normalizar(cadenaBuscada);
            if (cadenaBuscada == null) return null;
            var encontrados = new List<Cadena>();
            foreach (var cadena in cadenas)
            {
                var cadenaConProbabilidad = new Cadena { Valor = cadena, Probabilidad = 0 };
                var cadenaNormalizada = Normalizar(cadena);
                cadenaConProbabilidad.Probabilidad += ObtenerProbabilidad(cadenaBuscada, cadenaNormalizada);
                encontrados.Add(cadenaConProbabilidad);
            }
            var ordenados = (from e in encontrados orderby e.Probabilidad descending select e).ToList();
            return (from o in ordenados select o.Valor).FirstOrDefault();
        }

        /*
         *  Obtiene la probabilidad de una cadena en un texto. 
         *  Cuanto mayor es la coincidencia de secuencias dentro de un texto, mayor es la probabilidad.
         */
        public static double ObtenerProbabilidad(string cadenaBuscada, string texto)
        {
            double puntaje = 0;
            if (cadenaBuscada == null || texto == null) return puntaje;
            for (int inicio = 0; inicio < cadenaBuscada.Length; inicio++)
            {
                for (int fin = inicio + 1; fin <= cadenaBuscada.Length; fin++)
                {
                    var largo = fin - inicio;
                    var fragmento = cadenaBuscada.Substring(inicio, largo);
                    var match = Regex.Matches(texto, fragmento);
                    if (match.Count == 0) break;
                    puntaje += 1.0 / match.Count;
                }
            }
            var maxPuntaje = MaxPuntaje(cadenaBuscada);
            return maxPuntaje == 0 ? 0 : puntaje / maxPuntaje;
        }
        
        /*
         *  El máximo puntaje que puede tener una cadena.
         */
        public static double MaxPuntaje(string cadena)
        {
            if(cadena == null) return 0;
            double n = cadena.Length;
            return (n * n + n) / 2;
        }

        /*
         * Normaliza una cadena:
         * - Pone todo en uppercase
         * - Remueve todo lo que no es A-Z 0-9
         * - Remueve todos los espacios multiples
         * - Saca espacios anteriores y posteriores de la cadena
         */
        public static string Normalizar(string cadena)
        {
            if(cadena == null) return null;
            cadena = cadena.ToUpper();
            //valor = StringHelper.Unificar(valor);
            //valor = valor.Replace(".", " ");
            cadena = Regex.Replace(cadena, @"[^A-Z0-9 ]+", "");
            cadena = Regex.Replace(cadena, @"\s+", " ");
            return " " + cadena.Trim() + " ";
        }

        /*
         * Unifica los caracteres de un texto evitando variantes en la codificación del mismo.
         * De esta manera se puede garantizar que Río es lo mismo que Rio
         * Ejemplo: Reemplaza Ñ por N o Ó por O
         */
        public static string Unificar(string texto)
        {
            if (texto == null) return null;
            return new String(
                    texto.Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    .ToArray()
                ).Normalize(NormalizationForm.FormC);
        }

        private class Cadena
        {
            public string Valor { get; set; }
            public double Probabilidad { get; set; } = 0;
        }
    }
}
